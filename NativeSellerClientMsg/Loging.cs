using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NativeSeller
{
    public  class Loging
    {

        public void writelog( string log,string tag)
        {  
            if ( tag =="0" )
            {
                
                try
                {
                    StreamWriter sw= new StreamWriter(DateTime.Now.ToString("yyyyMMdd") + ".log", true, System.Text.Encoding.GetEncoding("GB2312"));
                    sw.Write(log + "\r\n");
                    sw.Close();
                    
                }
                catch
                {
                }
              



            }
        }
        public void writemsg(string msg, string tag)
        {   
            if (tag == "0")
            {
                
                try
                {
                    StreamWriter sw= new StreamWriter(DateTime.Now.ToString("yyyyMMdd") + "msg.log", true, System.Text.Encoding.GetEncoding("GB2312"));
                    sw.Write(msg + "\r\n");
                    sw.Close();

                }
                catch
                {
                }
               
            }
        }
    }
}
