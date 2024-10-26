using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.CForms {
    public partial class EmptyCForm : BorderLessForm {

        private bool IsAckActiveToClick;
        private bool IsBorderVisible;
        private bool IsAfterMissionStarted;

        private System.Threading.Timer Timer;
        private System.Threading.Timer TimerStop;
        private System.Threading.Timer TimerLevelChange;

        private AckInfo LastAckInfo;
        private ModeInfo LastModeInfo;

        public EmptyCForm() {
            InitializeComponent();

            IsAckActiveToClick = false;
            IsBorderVisible = false;
            IsAfterMissionStarted = false;

            Timer = new System.Threading.Timer(TimerBorderTick, null, Timeout.Infinite, Timeout.Infinite);

            TimerStop = new System.Threading.Timer(StopTrain, null, Timeout.Infinite, Timeout.Infinite);

            TimerLevelChange = new System.Threading.Timer(ChangeLevel, null, Timeout.Infinite, Timeout.Infinite);

            ETCSEvents.AckChanged += AnnounceChangeLevel;
            ETCSEvents.LevelChanged += ForceToChangeLevel;
            ETCSEvents.ChangeLevelIcon += ChangeLevelByMenu;
            ETCSEvents.MisionStarted += MisionStarted;
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e) {
            if (IsAckActiveToClick)
            {
                if (!IsAfterMissionStarted)
                {
                    IsAckActiveToClick = false;
                    Timer.Change(Timeout.Infinite, Timeout.Infinite);
                    TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
                    TimerLevelChange.Change(5000, 5000);
                    levelAnnouncementPicture.Image = LastAckInfo.Bitmap;
                    IsBorderVisible = false;
                    levelAnnouncementPicture.Invalidate();
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
                    IsAfterMissionStarted = false;
                    levelAnnouncementPicture.Invalidate();
                    Change();
                    if(LastModeInfo.Mode.Equals(ETCSModes.STM))
                    {
                        ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "SN zatwierdzony"));
                        TrainData.ActiveMode = ETCSModes.STM;
                    }
                    else
                    {
                        ETCSEvents.OnNewSystemMessage(new MessageInfo(DateTime.Now.ToString("HH:mm"), "OS zatwierdzony"));
                        TrainData.ActiveMode = ETCSModes.OS;
                    }
                    ETCSEvents.OnModeChanged(LastModeInfo);
                }
            }
        }

        private async void AnnounceChangeLevel(object sender, AckInfo e) {
            levelAnnouncementPicture.Image = e.Bitmap;
            LastAckInfo = e;
            await Task.Delay(17500);
            WaitToChangeLevel(e);
        }

        private void WaitToChangeLevel(AckInfo e)
        {
            IsAckActiveToClick = true;
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
                        levelAnnouncementPicture.Invalidate();
                        levelAnnouncementPicture.Update();
                    }
                }));
            }
        }

        private void levelAnnouncementPicture_Paint(object sender, PaintEventArgs e)
        {
            if (IsBorderVisible)
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
            //In the future add code to stop train
            Console.WriteLine("TRAIN STOP!");
            TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void ChangeLevel(object sender)
        {
            Change();
            TrainData.IsETCSActive = LastAckInfo.WillBeActive;
            levelPicture.Image = LastAckInfo.Level;
            if(LastAckInfo.WillBeActive)
            {
                TrainData.ETCSLevel = ETCSLevel.Poziom2;
                TrainData.ActiveMode = ETCSModes.FS;
                ETCSEvents.OnModeChanged(new ModeInfo(Resources.FS, ETCSModes.FS));
            }
            else
            {
                TrainData.ETCSLevel = ETCSLevel.SHP;
                TrainData.ActiveMode = ETCSModes.STM;
                ETCSEvents.OnModeChanged(new ModeInfo(Resources.STM, ETCSModes.STM));
            }
        }

        private void ForceToChangeLevel(object sender, LevelInfo e)
        {
            Change();
            TrainData.IsETCSActive = e.WillBeActive;
            levelPicture.Image = e.Bitmap;
            if (e.WillBeActive)
            {
                TrainData.ETCSLevel = ETCSLevel.Poziom2;
                TrainData.ActiveMode = ETCSModes.FS;
                ETCSEvents.OnModeChanged(new ModeInfo(Resources.FS, ETCSModes.FS));
            }
            else
            {
                TrainData.ETCSLevel = ETCSLevel.SHP;
                TrainData.ActiveMode = ETCSModes.STM;
                ETCSEvents.OnModeChanged(new ModeInfo(Resources.STM, ETCSModes.STM));
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
        }

        private void ChangeLevelByMenu(object sender, ChangeLevelIcon e)
        {
            levelPicture.Image = e.Icon;
        }

        private void MisionStarted(object sender, EventArgs e)
        {
            IsAckActiveToClick = true;
            IsBorderVisible = true;
            IsAfterMissionStarted = true;

            if (TrainData.ETCSLevel.Equals(ETCSLevel.SHP))
            {
                levelAnnouncementPicture.Image = Resources.STMAck;
                LastModeInfo = new ModeInfo(Resources.STM, ETCSModes.STM);
            }
            else
            {
                levelAnnouncementPicture.Image = Resources.OSAck;
                LastModeInfo = new ModeInfo(Resources.OS, ETCSModes.OS);
            }
            Timer.Change(0, 250);
        }
    }
}
