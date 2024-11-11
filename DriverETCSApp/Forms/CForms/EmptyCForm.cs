using DriverETCSApp.Communication.Server;
using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Forms.EForms;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DriverETCSApp.Forms.CForms
{
    public partial class EmptyCForm : BorderLessForm
    {

        private bool IsAckActiveToClick;
        private bool IsBorderVisible;
        private bool IsAfterMissionStarted;
        private bool IsTimerStoped;

        private System.Threading.Timer Timer;
        private System.Threading.Timer TimerStop;
        private System.Threading.Timer TimerLevelChange;

        private AckInfo LastAckInfo;
        private ModeInfo LastModeInfo;
        private ServerSender ServerSender;
        private static EmptyCForm instance = null;

        public EmptyCForm(ServerSender serverSender)
        {
            InitializeComponent();

            IsAckActiveToClick = false;
            IsBorderVisible = false;
            IsAfterMissionStarted = false;
            IsTimerStoped = true;

            if (instance == null)
            {
                instance = this;
            }

            ServerSender = serverSender;

            Timer = new System.Threading.Timer(TimerBorderTick, null, Timeout.Infinite, Timeout.Infinite);

            TimerStop = new System.Threading.Timer(StopTrain, null, Timeout.Infinite, Timeout.Infinite);

            TimerLevelChange = new System.Threading.Timer(ChangeLevel, null, Timeout.Infinite, Timeout.Infinite);

            ETCSEvents.AckChanged += AnnounceChangeLevel;
            ETCSEvents.LevelChanged += ForceToChangeLevel;
            ETCSEvents.ChangeLevelIcon += ChangeLevelByMenu;
            ETCSEvents.MisionStarted += MisionStarted;
            ETCSEvents.PostTripAck += PostTripAck;
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e)
        {
            if (IsAckActiveToClick)
            {
                IsTimerStoped = true;
                if (!IsAfterMissionStarted)
                {
                    IsAckActiveToClick = false;
                    Timer.Change(Timeout.Infinite, Timeout.Infinite);
                    TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
                    IsBorderVisible = false;

                    if (!TrainData.ActiveMode.Equals(ETCSModes.TR))
                    {
                        ETCSEvents.OnBrakeChange(new BrakeChangeInfo(false));
                        TimerLevelChange.Change(5000, 5000);
                        levelAnnouncementPicture.Image = LastAckInfo.Bitmap;
                        levelAnnouncementPicture.Invalidate();
                        levelAnnouncementPicture.Update();
                        if (LastAckInfo.WillBeActive)
                        {
                            ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Poziom 2 potwierdzony"));
                        }
                        else
                        {
                            ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "Poziom SHP potwierdzony"));
                        }
                    }
                    else
                    {
                        TrainData.ActiveMode = ETCSModes.PT;
                        levelAnnouncementPicture.Image = Resources.PostTrip;
                        ETCSEvents.OnModeChanged(new ModeInfo(Resources.PostTrip, ETCSModes.PT));
                        levelAnnouncementPicture.Invalidate();
                        levelAnnouncementPicture.Update();
                    }
                }
                else
                {
                    IsAfterMissionStarted = false;
                    levelAnnouncementPicture.Invalidate();
                    levelAnnouncementPicture.Update();
                    Change();
                    if (LastModeInfo.Mode.Equals(ETCSModes.STM))
                    {
                        ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "SN zatwierdzony"));
                        TrainData.ActiveMode = ETCSModes.STM;
                    }
                    else //OS
                    {
                        ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "OS zatwierdzony"));
                        TrainData.ActiveMode = ETCSModes.OS;
                    }
                    ETCSEvents.OnModeChanged(LastModeInfo);
                }
                IsBorderVisible = false;
                levelAnnouncementPicture.Invalidate();
                levelAnnouncementPicture.Update();
            }
        }

        private async void AnnounceChangeLevel(object sender, AckInfo e)
        {
            levelAnnouncementPicture.Image = e.Bitmap;
            LastAckInfo = e;
            await Task.Delay(15000);
            WaitToChangeLevel(e);
        }

        private void WaitToChangeLevel(AckInfo e)
        {
            IsAckActiveToClick = true;
            IsTimerStoped = false;
            levelAnnouncementPicture.Image = e.FlashingBitmap;

            Timer.Change(0, 250);
            TimerStop.Change(5000, 5000);
        }

        private void TimerBorderTick(object sender)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed && !Disposing)
                    {
                        IsBorderVisible = !IsBorderVisible;
                        if (!IsTimerStoped)
                        {
                            levelAnnouncementPicture.Invalidate();
                            levelAnnouncementPicture.Update();
                        }
                    }
                }));
            }
        }

        private void levelAnnouncementPicture_Paint(object sender, PaintEventArgs e)
        {
            if (IsBorderVisible && !IsTimerStoped)
            {
                Rectangle rectangle = new Rectangle(0, 0, levelAnnouncementPicture.Width - 1, levelAnnouncementPicture.Height - 1);

                using (Pen pen = new Pen(DMIColors.Yellow, 5))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }
        }

        private void StopTrain(object sender)
        {
            ETCSEvents.OnBrakeChange(new BrakeChangeInfo(true));
            Console.WriteLine("TRAIN STOP!");
            TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private async void ChangeLevel(object sender)
        {
            Change();
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                TrainData.IsETCSActive = LastAckInfo.WillBeActive;
                levelPicture.Image = LastAckInfo.Level;
                if (LastAckInfo.WillBeActive)
                {
                    TrainData.ETCSLevel = ETCSLevel.Poziom2;
                    TrainData.ActiveMode = ETCSModes.FS;
                    ETCSEvents.OnModeChanged(new ModeInfo(Resources.FS, ETCSModes.FS));
                    if (ServerSender != null)
                        await ServerSender?.SendMARequest();
                }
                else
                {
                    TrainData.ETCSLevel = ETCSLevel.SHP;
                    TrainData.ActiveMode = ETCSModes.STM;
                    ETCSEvents.OnModeChanged(new ModeInfo(Resources.STM, ETCSModes.STM));
                }
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }

        private async void ForceToChangeLevel(object sender, LevelInfo e)
        {
            Change();
            await TrainData.TrainDataSemaphofe.WaitAsync();
            try
            {
                TrainData.IsETCSActive = e.WillBeActive;
                levelPicture.Image = e.Bitmap;
                if (e.WillBeActive)
                {
                    TrainData.ETCSLevel = ETCSLevel.Poziom2;
                    TrainData.ActiveMode = ETCSModes.FS;
                    ETCSEvents.OnModeChanged(new ModeInfo(Resources.FS, ETCSModes.FS));
                    if (ServerSender != null)
                        await ServerSender?.SendMARequest();
                }
                else
                {
                    TrainData.ETCSLevel = ETCSLevel.SHP;
                    TrainData.ActiveMode = ETCSModes.STM;
                    ETCSEvents.OnModeChanged(new ModeInfo(Resources.STM, ETCSModes.STM));
                }
            }
            finally
            {
                TrainData.TrainDataSemaphofe.Release();
            }
        }

        private void Change()
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
            TimerLevelChange.Change(Timeout.Infinite, Timeout.Infinite);
            levelAnnouncementPicture.Image = null;
            IsBorderVisible = false;
            IsAckActiveToClick = false;
            if (IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed && !Disposing)
                    {
                        levelAnnouncementPicture.Invalidate();
                        levelAnnouncementPicture.Update();
                    }
                }));
            }
        }

        private void ChangeLevelByMenu(object sender, ChangeLevelIcon e)
        {
            levelPicture.Image = e.Icon;
        }

        private async void MisionStarted(object sender, EventArgs e)
        {
            IsAckActiveToClick = true;
            IsBorderVisible = true;
            IsAfterMissionStarted = true;
            IsTimerStoped = false;

            if (TrainData.ETCSLevel.Equals(ETCSLevel.SHP))
            {
                levelAnnouncementPicture.Image = Resources.STMAck;
                LastModeInfo = new ModeInfo(Resources.STM, ETCSModes.STM);
            }
            else
            {
                await ServerSender.SendTrainData();
                if (TrainData.IsTrainRegisterOnServer && TrainData.IsConnectionWorking)
                {
                    levelAnnouncementPicture.Image = Resources.OSAck;
                    LastModeInfo = new ModeInfo(Resources.OS, ETCSModes.OS);
                }
                else
                {
                    levelAnnouncementPicture.Image = Resources.STMAck;
                    LastModeInfo = new ModeInfo(Resources.STM, ETCSModes.STM);
                    levelPicture.Image = Resources.SHP;
                }
            }
            Timer.Change(0, 250);
        }

        private void PostTripAck(object sender, EventArgs e)
        {
            IsAckActiveToClick = true;
            IsBorderVisible = true;
            IsAfterMissionStarted = false;
            IsTimerStoped = false;
            levelAnnouncementPicture.Image = Resources.TripAck;
            Timer.Change(0, 250);
        }

        public static void BrakingImage(bool braking)
        {
            if (braking)
            {
                instance.brakePicture.Image = Resources.Brakes;
            }
            else
            {
                instance.brakePicture.Image = null;
            }
        }

        private void EmptyCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ETCSEvents.AckChanged -= AnnounceChangeLevel;
            ETCSEvents.LevelChanged -= ForceToChangeLevel;
            ETCSEvents.ChangeLevelIcon -= ChangeLevelByMenu;
            ETCSEvents.MisionStarted -= MisionStarted;
        }
    }
}
