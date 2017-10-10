using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICS
{
    public partial class main : Form
    {
        GUICS_LIB ARDUINO;

        public main()
        {
            InitializeComponent();

            ARDUINO = new GUICS_LIB(Communication.serialPort);
        }

        private void main_Load(object sender, EventArgs e)
        {
            //init mutiTask
        }
    }
}
