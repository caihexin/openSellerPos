using System;
using System.Collections.Generic;
using System.Text;

namespace NativeSeller
{
   public class Comm
    {

       /// <summary>
        /// 实现简单的 Ping 的功能，用于测试网络是否已经联通
       /// </summary>
       /// <param name="ip"></param>
       /// <returns></returns>
        public bool Ping(string ip)
        {
            Boolean pT = true;
            try
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                options.DontFragment = true;
                string data = "Test Data!";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000; // Timeout 时间，单位：毫秒
                System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                   pT=true;
                else
                   pT= false;
            }
            catch
            {
                pT = false;
                return pT;
            }
            return pT;

        }


    }
}
