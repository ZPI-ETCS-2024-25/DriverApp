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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp.Forms.CForms {
    public partial class EmptyCForm : BorderLessForm {

        private bool IsAckActiveToClick;
        private bool IsBorderVisible;
        private Timer Timer;
        private Timer TimerStop;
        private Timer TimerLevelChange;

        public EmptyCForm() {
            InitializeComponent();

            IsAckActiveToClick = false;
            IsBorderVisible = false;

            Timer = new Timer();
            Timer.Interval = 250;
            Timer.Tick += TimerTick;

            TimerStop = new Timer();
            TimerStop.Interval = 5000;
            TimerStop.Tick += StopTrain;

            TimerLevelChange = new Timer();
            TimerLevelChange.Interval = 5000;
            TimerLevelChange.Tick += ChangeLevel;

            ETCSEvents.AckChanged += AnnounceChangeLevel;
            //ETCSEvents.LevelChanged +=
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e) {
            if (IsAckActiveToClick)
            {
                IsAckActiveToClick = false;
                Timer.Stop();
                TimerStop.Stop();
                TimerLevelChange.Start();
                levelAnnouncementPicture.Image = Resources.L2AckWhite;
            }
        }

        public async void AnnounceChangeLevel(object sender, AckInfo e) {
            levelAnnouncementPicture.Image = e.Bitmap;
            await Task.Delay(17500);
            IsAckActiveToClick = true;
            levelAnnouncementPicture.Image = e.FlashingBitmap;
            Timer.Start();
            Timer.Enabled = true;
            TimerStop.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            levelAnnouncementPicture.Invalidate();
            levelAnnouncementPicture.Update();
        }

        private void levelAnnouncementPicture_Paint(object sender, PaintEventArgs e)
        {
            if (IsBorderVisible)
            {
                Rectangle rectangle = new Rectangle(levelAnnouncementPicture.Location.X, levelAnnouncementPicture.Location.Y, levelAnnouncementPicture.Width - 1, levelAnnouncementPicture.Height - 1);

                using (Pen pen = new Pen(DMIColors.Yellow, 3))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }

            IsBorderVisible = !IsBorderVisible;
        }

        private void StopTrain(object sender, EventArgs e)
        {
            Console.WriteLine("TRAIN STOP!");
        }

        private void ChangeLevel(object sender, EventArgs e)
        {
            Timer.Stop();
            TimerStop.Stop();
            TimerLevelChange.Stop();
            levelAnnouncementPicture.Image = null;
        }
    }
}
