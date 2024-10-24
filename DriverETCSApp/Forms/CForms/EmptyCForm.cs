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
        }

        private void levelAnnouncementPicture_Click(object sender, EventArgs e) {
            levelAnnouncementPicture.Hide();
        }

        private void AnnounceLevel2() {
            levelAnnouncementPicture.Image = Resources.L2;
        }
    }
}
