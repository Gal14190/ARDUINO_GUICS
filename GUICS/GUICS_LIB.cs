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

        /// <summary>
        /// Setup GPIO mode (Input / Output).
        /// </summary>
        /// <param name="DIGITAL_PIN">GPIO number</param>
        /// <param name="_SET">SET.INPUT or SET.OUTPUT</param>
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

        /// <summary>
        /// Return GPIO status (ex. switch or trigger) for GPIO mode [SET.INPUT].
        /// </summary>
        /// <param name="DIGITAL_PIN">GPIO number</param>
        /// <returns>true for HIGH logic level OR false for LOW logic level</returns>
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


        /// <summary>
        /// Set GPIO status for mode [SET.OUTPUT].
        /// </summary>
        /// <param name="DIGITAL_PIN">GPIO number</param>
        /// <param name="_SET">SET.HIGH for high logic level OR SET.LOW for low logic level</param>
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

        /// <summary>
        /// Sleep program for while
        /// </summary>
        /// <param name="ms">milli seconds</param>
        public static void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }


        /// <summary>
        /// Set the text associared with this control
        /// </summary>
        /// <param name="ctl">Control object</param>
        /// <param name="content">Set text</param>
        public static void Text(Control ctl, string content)
        {
            ctl.Invoke(new Action(() => ctl.Text = content));
        }

        /// <summary>
        /// Set the background associared with this control
        /// </summary>
        /// <param name="ctl">Control object</param>
        /// <param name="content">Set color [Color.(color name)]</param>
        public static void Color(Control ctl, System.Drawing.Color color)
        {
            ctl.Invoke(new Action(() => ctl.BackColor = color));
        }
    }

    class MultiTask 
    {
        public bool Enable = true;
        /// <summary>
        /// Run task in background. Call it like new object.
        /// </summary>
        /// <param name="loop">Insert function structure:() => Func()</param>
        public MultiTask(Action loop)
        {
            Task.Run(() => { while(Enable) loop(); });
        }
    }
}
