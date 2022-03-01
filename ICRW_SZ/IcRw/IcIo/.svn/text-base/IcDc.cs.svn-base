using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IcIo
{
   public  class IcDc:IIc 
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
            icdev = IcApi.IC_InitComm(100);
            if (icdev > 0)
            {
                devTag = true;
            }
            st = IcApi.IC_InitType(icdev, 0x10);
            st = IcApi.IC_Status(icdev);
            if (st == 1)
            {
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
            

           st= IcApi.IC_Read(icdev, 30, 10, data);
           return System.Text.Encoding.Default.GetString(data);

        }
        public bool  IIcWrite(string str)
        {
            if (!devTag)
            {
                IIcInit();
            }
           
          st=  IcApi.IC_Write(icdev, 30, 10, str);
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

            st = IcApi.IC_CheckPass_4442hex(icdev ,pwd );
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

            st = IcApi.IC_ChangePass_4442hex (icdev, pwd);
            if (st == 0)
                return true;
            else
                return false;
           


        }

        public bool  IIcClose()
        {
            st = IcApi.IC_Down(icdev);
            st = IcApi.IC_ExitComm(icdev);
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
            st = IcApi.IC_ReadVer(icdev, data);
            return System.Text.Encoding.Default.GetString(data);
        }

    }
}
