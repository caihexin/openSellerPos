using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SellerServer
{
    public  class Loging
    {

        public void writelog( string log,string tag)
        {
            if ( tag =="0" )
            {
                StreamWriter sw = new StreamWriter(DateTime.Now.ToString("yyyyMMdd") + ".log", true, System.Text.Encoding.GetEncoding("GB2312"));
                sw.Write(log+"\r\n");
                sw.Close();
            }
        }
    }
}
