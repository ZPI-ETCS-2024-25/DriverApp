using DriverETCSApp.Data;
using DriverETCSApp.Design;
using DriverETCSApp.Forms;
using DriverETCSApp.Forms.DForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace DriverETCSApp.UnitTests.Forms.FullScreenForms
{
    public class TrainDataFormTest : IDisposable
    {
        private MainForm MainForm;
        private TrainDataForm TrainDataForm;

        public TrainDataFormTest()
        {
            TrainData.Reset();
        }

        public void Dispose()
        {
            TrainDataForm?.Dispose();
            MainForm?.Dispose();
        }

        private void Create()
        {
            MainForm = new MainForm(false);
            var formField = typeof(MainForm).GetField("dForm", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(MainForm, TrainDataForm);
        }

        private void Stop()
        {
            var stopMethod = typeof(MainForm).GetMethod("MainForm_FormClosing", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = stopMethod.Invoke(MainForm, parameters);
        }

        [Fact]
        [STAThread]
        public void TestLabels()
        {
            Create();
            TrainData.TrainCat = "PASS 3";
            TrainData.Length = "100";
            TrainData.BrakingMass = "111";
            TrainData.VMax = "1";
            TrainDataForm = new TrainDataForm(MainForm);

            var label1 = (Label)typeof(TrainDataForm).GetField("infoLabelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var label2 = (Label)typeof(TrainDataForm).GetField("infoLabelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var label3 = (Label)typeof(TrainDataForm).GetField("infoLabelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var label4 = (Label)typeof(TrainDataForm).GetField("infoLabelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);

            Stop();
            Assert.Equal("PASS 3", label1.Text);
            Assert.Equal("100", label2.Text);
            Assert.Equal("111", label3.Text);
            Assert.Equal("1", label4.Text);
        }

        [Fact]
        [STAThread]
        public void TestClose()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var method = typeof(TrainDataForm).GetMethod("closeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            Stop();
            Assert.True(TrainDataForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void TestChangeDisplay()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var method = typeof(TrainDataForm).GetMethod("buttonChangeDisplay_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            Stop();
            Assert.True(TrainDataForm.IsDisposed);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel1Empty()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "";

            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            
            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(0, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[1].BackColor);
            Assert.Equal(DMIColors.Grey, l1[1].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[0].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[0].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel1()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";

            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(1, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[0].BackColor);
            Assert.Equal(DMIColors.Grey, l1[0].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[1].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[1].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel2Empty()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(1, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[2].BackColor);
            Assert.Equal(DMIColors.Grey, l1[2].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[1].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[1].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel2()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "1234";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(2, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[1].BackColor);
            Assert.Equal(DMIColors.Grey, l1[1].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[2].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[2].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel3Empty()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label3 = (Label)typeof(TrainDataForm).GetField("labelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label3.Text = "";
            method = typeof(TrainDataForm).GetMethod("labelData3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(2, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[3].BackColor);
            Assert.Equal(DMIColors.Grey, l1[3].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[2].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[2].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel3()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "1234";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label3 = (Label)typeof(TrainDataForm).GetField("labelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label3.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(3, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[2].BackColor);
            Assert.Equal(DMIColors.Grey, l1[2].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[3].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[3].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel4Empty()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label3 = (Label)typeof(TrainDataForm).GetField("labelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label3.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label4 = (Label)typeof(TrainDataForm).GetField("labelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label4.Text = "";
            method = typeof(TrainDataForm).GetMethod("labelData4_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(3, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[0].BackColor);
            Assert.Equal(DMIColors.Grey, l1[0].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[3].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[3].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestClickLabel4()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";
            var method = typeof(TrainDataForm).GetMethod("labelData1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label2 = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "1234";
            method = typeof(TrainDataForm).GetMethod("labelData2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label3 = (Label)typeof(TrainDataForm).GetField("labelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label3.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label4 = (Label)typeof(TrainDataForm).GetField("labelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label4.Text = "123";
            method = typeof(TrainDataForm).GetMethod("labelData4_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal(0, ID);
            Assert.Equal(DMIColors.DarkGrey, l1[3].BackColor);
            Assert.Equal(DMIColors.Grey, l1[3].ForeColor);
            Assert.Equal(DMIColors.DarkGrey, l1[0].ForeColor);
            Assert.Equal(DMIColors.Grey, l1[0].BackColor);
        }

        [Fact]
        [STAThread]
        public void TestLabelConfirmation()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);
            var label1 = (Label)typeof(TrainDataForm).GetField("infoLabelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label1.Text = "123";

            var label2 = (Label)typeof(TrainDataForm).GetField("infoLabelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label2.Text = "1234";

            var label3 = (Label)typeof(TrainDataForm).GetField("infoLabelData3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label3.Text = "123";

            var label4 = (Label)typeof(TrainDataForm).GetField("infoLabelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            label4.Text = "123";

            var formField = typeof(TrainDataForm).GetField("IsConfirmationActive", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(TrainDataForm, true);

            var method = typeof(TrainDataForm).GetMethod("labelConfirmation_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label = (Label)typeof(TrainDataForm).GetField("infoLabelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);

            var ID = (int)typeof(TrainDataForm).GetField("ID", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            var l1 = (List<Label>)typeof(TrainDataForm).GetField("labelsList", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.True(TrainDataForm.IsDisposed);
            Assert.Equal("123", label.Text);
        }

        [Fact]
        [STAThread]
        public void TestLabelConfirmation1()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);

            var formField = typeof(TrainDataForm).GetField("IsConfirmationActive", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(TrainDataForm, false);

            var method = typeof(TrainDataForm).GetMethod("labelConfirmation_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);

            var label = (Label)typeof(TrainDataForm).GetField("infoLabelData4", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);

            Stop();
            Assert.False(TrainDataForm.IsDisposed);
            Assert.Equal("", label.Text);
        }

        [Fact]
        [STAThread]
        public void TestDataInput()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);

            var method = typeof(TrainDataForm).GetMethod("button4_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button5_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button6_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button7_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal("456", label.Text);
        }

        [Fact]
        [STAThread]
        public void TestDataInput1()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);

            var method = typeof(TrainDataForm).GetMethod("button7_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button8_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button9_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            method = typeof(TrainDataForm).GetMethod("button11_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);

            var label = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Stop();
            Assert.Equal("789", label.Text);
        }

        [Fact]
        [STAThread]
        public void TestDataInput2()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);

            var method = typeof(TrainDataForm).GetMethod("button1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            var label = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Assert.Equal("PASS 3", label.Text);

            method = typeof(TrainDataForm).GetMethod("button2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            label = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Assert.Equal("FP 4", label.Text);

            method = typeof(TrainDataForm).GetMethod("button3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            label = (Label)typeof(TrainDataForm).GetField("labelData1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);

            Stop();
            Assert.Equal("FG 4", label.Text);
        }

        [Fact]
        [STAThread]
        public void TestDataInput3()
        {
            Create();
            TrainDataForm = new TrainDataForm(MainForm);

            var l = (Label)typeof(TrainDataForm).GetField("labelData2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);

            var formField = typeof(TrainDataForm).GetField("activeLabel", BindingFlags.NonPublic | BindingFlags.Instance);
            formField.SetValue(TrainDataForm, l);

            var method = typeof(TrainDataForm).GetMethod("button1_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, null };
            var result = method.Invoke(TrainDataForm, parameters);
            var label = (Label)typeof(TrainDataForm).GetField("activeLabel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Assert.Equal("1", label.Text);

            method = typeof(TrainDataForm).GetMethod("button2_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            label = (Label)typeof(TrainDataForm).GetField("activeLabel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Assert.Equal("12", label.Text);

            method = typeof(TrainDataForm).GetMethod("button3_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            label = (Label)typeof(TrainDataForm).GetField("activeLabel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            Assert.Equal("123", label.Text);

            method = typeof(TrainDataForm).GetMethod("button10_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            result = method.Invoke(TrainDataForm, parameters);
            label = (Label)typeof(TrainDataForm).GetField("activeLabel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(TrainDataForm);
            
            Stop();
            Assert.Equal("12", label.Text);
        }
    }
}
