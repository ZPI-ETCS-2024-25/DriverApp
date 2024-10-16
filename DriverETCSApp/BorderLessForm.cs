using DriverETCSApp.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverETCSApp
{
    public class BorderLessForm : Form
    {
        //private BufferedGraphicsContext BufferedGraphicsContext;
        //private BufferedGraphics BufferedGraphics;

        public BorderLessForm() : base()
        {
            FormBorderStyle = FormBorderStyle.None;
            /*SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);*/
            /*BufferedGraphicsContext = BufferedGraphicsManager.Current;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Paint += new PaintEventHandler(PaintForm);*/
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BorderLessForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BorderLessForm";
            this.Activated += new System.EventHandler(this.BorderLessForm_Activated);
            this.Load += new System.EventHandler(this.BorderLessForm_Load);
            this.ResumeLayout(false);

        }

        private void BorderLessForm_Load(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void BorderLessForm_Activated(object sender, EventArgs e)
        {
            Visible = true;
        }

        /*protected void CreateBuffer()
        {
            if (BufferedGraphics != null)
            {
                BufferedGraphics.Dispose();
            }
            BufferedGraphics = BufferedGraphicsContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected void PaintForm(object sender, PaintEventArgs e)
        {
            if (BufferedGraphics == null)
            {
                CreateBuffer();
            }
            Graphics g = BufferedGraphics.Graphics;
            g.Clear(DMIColors.DarkBlue);
        }*/
    }
}
