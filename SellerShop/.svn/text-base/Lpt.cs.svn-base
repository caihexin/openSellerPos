using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
namespace NativeSeller
{
    public class Lpt
    {


    
        //imports inpout32.dll

        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value);
        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern void Input(int adress);


        private int _portaddr;
        public int portaddr
        {
            set
            {
                _portaddr = value;
            }
            get
            {
                return _portaddr;
            }
        }

        private string _portName;
        public string portName
        {
            set
            {
                _portName = value;
            }
            get
            {
                return _portName;
            }
        }

         public  Lpt( string  PortName)
        {
            switch (PortName.ToUpper ())
            {
                case "LPT1" :
                    portaddr = 888;
                    break ;
                case "LPT2" :
                    portaddr = 632;
                    break ; 
                case "LPT3" :
                    portaddr = 956;
                    break ;
                default :
                    portaddr = 888;
                    break;
            }


        }
        #region input32.dll

        public void lptCmd(string cmd)
        {
            byte[] sn = StringToHex(cmd);
            foreach (byte _sn in sn)
            {

                Output(portaddr, _sn);
                Thread.Sleep(1);
                Output(portaddr + 2, 0xCD);
                Thread.Sleep(1);
                Output(portaddr + 2, 0xCC);
                Thread.Sleep(1);
            }

        }

        public void moveGoPage()
        {
            lptCmd("1B 4A C1");
        }

        public void moveBackPage()
        {
            lptCmd("1B 6A C1");
        }


        public void lptCmd(int cmd)
        {
            Output(portaddr, cmd);
            Thread.Sleep(1);
            Output(portaddr + 2, 0xCD);
            Thread.Sleep(1);
            Output(portaddr + 2, 0xCC);
            Thread.Sleep(1);


        }



        public void lptPrint(string str)
        {
            byte[] sn = System.Text.Encoding.Default.GetBytes(str);
            foreach (byte _sn in sn)
            {

                Output(portaddr, _sn);
                Thread.Sleep(1);
                Output(portaddr + 2, 0xCD);
                Thread.Sleep(1);
                Output(portaddr + 2, 0xCC);
                Thread.Sleep(1);
              
               
            }

           

            lptCmd(0x0A);
            lptCmd(0x0A);



        }

        public void openDoor()
        {

            lptCmd(27);
            lptCmd(112);
            lptCmd (0);
            lptCmd (60);
            lptCmd (255);
        }

        public void openDoor2()
        {

            lptCmd(0x1B);
            lptCmd(0x70);
            lptCmd(0x00);
            lptCmd(0x3C);
            lptCmd(0xFF);
        }


        public byte[] StringToHex(string str)
        {

            string[] temp;
            char[] Sc = new char[] { ' ' };
            temp = str.Split(Sc);
            int i = temp.Length;
            byte[] b = new byte[i];

            for (int j = 0; j < i; j++)
            {

                b[j] = byte.Parse(temp[j].ToString(), System.Globalization.NumberStyles.HexNumber);

            }

            return b;

        }



        #endregion
       






    }
}
