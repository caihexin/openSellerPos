using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IcRw
{
    class IcDc:IcInterface 
    {

        private int _icdev;
        public int icdev
        {
            set
            {
                _icdev = value;
            }
            get
            {
                return _icdev;
            }

        }
        private short st;
        private byte[] data;
        private bool devTag = false;
        public bool  IIcInit()
        {
            icdev = 0;
            st = 0;
            data = new byte[1024];
            icdev = Ic.IC_InitComm(100);
            if (icdev > 0)
            {
                devTag = true;
            }
            st = Ic.IC_Status(icdev);
            if (st == 1)
            {
          //      MessageBox.Show("Ã»ÓÐ²å¿¨","¾¯¸æ£¡",MessageBoxButtons.OK ,MessageBoxIcon.Information );
                return false;
            }
            return true;
        }

        public string  IIcRead()
        {
            if (!devTag)
            {
                IIcInit();
            }
           st= Ic.IC_Read(icdev, 30, 10, data);
           return System.Text.Encoding.Default.GetString(data);

        }
        public bool  IIcWrite(string str)
        {
            if (!devTag)
            {
                IIcInit();
            }
          st=  Ic.IC_Write(icdev, 30, 10, str);
          if (st == 0)
              return true;
          else
              return false;


        }

        public bool  IIcCheckPass(string pwd)
        {
            if (!devTag)
            {
                IIcInit();
            }
            st = Ic.IC_CheckPass_4442hex(icdev ,pwd );
            if (st == 0)
                return true;
            else
                return false;


        }
 
        public bool IIcChangePass(string pwd)
        {
            if (!devTag)
            {
                IIcInit();
            }
            st = Ic.IC_ChangePass_4442hex (icdev, pwd);
            if (st == 0)
                return true;
            else
                return false;
           


        }

        public bool  IIcClose()
        {
            st = Ic.IC_Down(icdev);
            st = Ic.IC_ExitComm(icdev);
            if (st == 0)
                return true;
            else
                return false;

        }
        public string IIcReadVer()
        {
            if (!devTag)
            {
                IIcInit();
            }
            st = Ic.IC_ReadVer(icdev, data);
            return System.Text.Encoding.Default.GetString(data);
        }

    }
}
