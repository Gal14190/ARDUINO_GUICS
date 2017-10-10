using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GUICS
{
    enum SET { INPUT, OUTPUT, HIGH, LOW }

    class GUICS_LIB
    {
        SerialPort SerialCOM;
        public GUICS_LIB(SerialPort SerialCOM_TEMP)
        {
            SerialCOM = SerialCOM_TEMP;
        }

        private struct TOKEN
        {
            public const string DIGITAL_SET = "M";
            public const string SET_INPUT = "I";
            public const string SET_OUTPUT = "O";

            public const string DIGITAL_INPUT = "I";

            public const string DIGITAL_OUTPUT = "O";
            public const string SET_HIGH = "H";
            public const string SET_LOW = "L";

            public const string ANALOG_INPUT = "A";

            public const char END_CHAR = '@';
        }

        public void DIGITAL_MODE(int DIGITAL_PIN, SET _SET)
        {
            char PIN = Convert.ToChar(DIGITAL_PIN);
            if (SerialCOM.IsOpen)
            {
                try
                {
                    string IO = "";
                    if (_SET == SET.INPUT)
                    {
                        IO = TOKEN.SET_INPUT;
                    }
                    else if (_SET == SET.OUTPUT)
                    {
                        IO = TOKEN.SET_OUTPUT;
                    }

                    SerialCOM.Write(TOKEN.DIGITAL_SET + IO + PIN);
                }
                catch
                {
                    MessageBox.Show("בעיה בחיבור");
                }
            }
        }

        public bool DIGITAL_GET(int DIGITAL_PIN)
        {
            char PIN = Convert.ToChar(DIGITAL_PIN);

            if (SerialCOM.IsOpen)
            {
                try
                {
                    SerialCOM.Write(TOKEN.DIGITAL_INPUT + PIN);
                }
                catch
                {
                    MessageBox.Show("בעיה בחיבור");
                }


                if (SerialCOM.ReadChar() == '1') return true;
                else return false;
            }
            return false;
        }

        public void DIGITAL_SET(int DIGITAL_PIN, SET _SET)
        {
            char PIN = Convert.ToChar(DIGITAL_PIN);

            if (SerialCOM.IsOpen)
            {
                try
                {
                    string IO = "";
                    if (_SET == SET.HIGH)
                    {
                        IO = TOKEN.SET_HIGH;
                    }
                    else if (_SET == SET.LOW)
                    {
                        IO = TOKEN.SET_LOW;
                    }

                    SerialCOM.Write(TOKEN.DIGITAL_OUTPUT + IO + PIN);
                }
                catch
                {
                    MessageBox.Show("בעיה בחיבור");
                }
            }
        }

        public string ANALOG_GET(int ANALOG_PIN)
        {
            char PIN = Convert.ToChar(ANALOG_PIN);
            string dataReturn = "";

            if (SerialCOM.IsOpen)
            {
                try
                {
                    SerialCOM.Write(TOKEN.ANALOG_INPUT + PIN);

                    int dataRead = 0;

                    while (dataRead != TOKEN.END_CHAR)
                    {
                        dataRead = SerialCOM.ReadChar();
                        if(dataRead != TOKEN.END_CHAR)
                        {
                            dataReturn += Convert.ToChar(dataRead);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("בעיה בחיבור");
                }
            }
            return dataReturn;
        }
    }

    class GUI
    {
        public static void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public static void text(Control ctl, string content)
        {
            ctl.Invoke(new Action(() => ctl.Text = content));
        }

        public static void color(Control ctl, System.Drawing.Color color)
        {
            ctl.Invoke(new Action(() => ctl.BackColor = color));
        }
    }

    class MultiTask 
    {
        public MultiTask( Action setup, Action loop)
        {
            setup();

            Task.Run(() => { while(true) loop(); });
        }
    }
}
