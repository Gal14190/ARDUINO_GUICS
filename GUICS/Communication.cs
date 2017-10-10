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
using System.IO.Ports;

namespace GUICS
{
    public partial class Communication : Form
    {
        static main mainForm;

        public static SerialPort serialPort;

        public Communication()
        {
            InitializeComponent();

            COM_NAME.Items.Clear();
            string[] COM = SerialPort.GetPortNames();
            COM_NAME.Items.AddRange(COM);
        }

        private void REF_BTN_Click(object sender, EventArgs e)
        {
            COM_NAME.Items.Clear();

            string[] COM = SerialPort.GetPortNames();
            COM_NAME.Items.AddRange(COM);
        }

        private void RUN_BTN_Click(object sender, EventArgs e)
        {
            if (!serialCOM.IsOpen)
            {
                serialCOM.PortName = COM_NAME.Text;
                try
                {
                    serialCOM.Open();
                    STATUS_PANEL.BackColor = System.Drawing.Color.Green;
                    RUN_BTN.Enabled = false;
                    CLOSE_BTN.Enabled = true;

                    serialPort = serialCOM;

                    mainForm = new main();
                    mainForm.Show();
                }
                catch { MessageBox.Show("בעיה בחיבור"); }
            }
        }

        private void CLOSE_BTN_Click(object sender, EventArgs e)
        {
            if (serialCOM.IsOpen)
            {
                try
                {
                    serialCOM.Close();
                    STATUS_PANEL.BackColor = System.Drawing.Color.Red;
                    RUN_BTN.Enabled = true;
                    CLOSE_BTN.Enabled = false;

                    mainForm.Hide();
                }
                catch { MessageBox.Show("בעיה בחיבור"); }
            }
        }
    }
}
