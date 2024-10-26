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

        private System.Threading.Timer Timer;
        private System.Threading.Timer TimerStop;
        private System.Threading.Timer TimerLevelChange;

        private AckInfo LastAckInfo;

        public EmptyCForm() {
            InitializeComponent();

            IsAckActiveToClick = false;
            IsBorderVisible = false;

            Timer = new System.Threading.Timer(TimerBorderTick, null, Timeout.Infinite, Timeout.Infinite);

            TimerStop = new System.Threading.Timer(StopTrain, null, Timeout.Infinite, Timeout.Infinite);

            TimerLevelChange = new System.Threading.Timer(ChangeLevel, null, Timeout.Infinite, Timeout.Infinite);

            ETCSEvents.AckChanged += AnnounceChangeLevel;
            //ETCSEvents.LevelChanged +=
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e) {
            if (IsAckActiveToClick)
            {
                IsAckActiveToClick = false;
                Timer.Change(Timeout.Infinite, Timeout.Infinite);
                TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
                TimerLevelChange.Change(5000, 5000);
                levelAnnouncementPicture.Image = LastAckInfo.Bitmap;
                IsBorderVisible = false;
                levelAnnouncementPicture.Invalidate();
            }
        }

        private async void AnnounceChangeLevel(object sender, AckInfo e) {
            levelAnnouncementPicture.Image = e.Bitmap;
            LastAckInfo = e;
            await Task.Delay(1750);
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
            Console.WriteLine("TRAIN STOP!");
            TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void ChangeLevel(object sender)
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            TimerStop.Change(Timeout.Infinite, Timeout.Infinite);
            TimerLevelChange.Change(Timeout.Infinite, Timeout.Infinite);
            levelAnnouncementPicture.Image = null;
            IsBorderVisible = false;
            IsAckActiveToClick = false;
        }
    }
}
