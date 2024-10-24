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
        public EmptyCForm() {
            InitializeComponent();
            levelAnnouncementPicture.Hide();
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e) {
            levelAnnouncementPicture.Image = Resources.L2AckWhite;
        }

        private void buttonLevel2_Click(object sender, EventArgs e) {
            AnnounceLevel2();
        }

        public void AnnounceLevel2() {
            levelAnnouncementPicture.Show();
            levelAnnouncementPicture.Image = Resources.L2AckYellow;
        }

        public void Level2Acquired() {
            levelAnnouncementPicture.Hide();
        }
    }
}
