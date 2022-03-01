using System;
using System.Collections.Generic;
using System.Text;

namespace IcIo
{
  public   interface IIc
    {

      bool  IIcInit();
      string  IIcRead();
      bool  IIcWrite(string str);
      bool  IIcClose();
      string  IIcReadVer();
      bool   IIcCheckPass(string pwd);
      bool IIcChangePass(string pwd);

        

    }
}
