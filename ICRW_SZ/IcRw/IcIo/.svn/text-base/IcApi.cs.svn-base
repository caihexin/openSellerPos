using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace IcIo
{
  class IcApi
    {
      

            //申明API位置.
            [DllImport("dcic32.dll")]
            //初始化端口
            public static extern int IC_InitComm(int Port);

            [DllImport("dcic32.dll")]
            //关闭端口
            public static extern short IC_ExitComm(int icdev);

            [DllImport("dcic32.dll")]
            //卡下电(要重新审核密码才能继续操作)
            public static extern short IC_Down(int icdev);

            [DllImport("dcic32.dll")]
            //初始化卡型
            public static extern short IC_InitType(int icdev, int cardType);

            [DllImport("dcic32.dll")]
            //判断连接是否成功,<0 ,连接不成功.0可以读写,1连接成功,但是没插卡.
            public static extern short IC_Status(int icdev);
            [DllImport("dcic32.dll")]
            //检查原始密码(小于0为不正确)
            public static extern short IC_CheckPass_4442hex(int icdev, string Password);
            [DllImport("dcic32.dll")]
            //更改密码(0为更改成功)
            public static extern short IC_ChangePass_4442hex(int icdev, string Password);
            [DllImport("dcic32.dll")]
            //在固定的位置写入固定长度的数据
            public static extern short IC_Write(int icdev, int offset, int Length, string Databuffer);
            [DllImport("dcic32.dll")]
            //在固定的位置读出固定长度的数据
            public static extern short IC_Read(int icdev, int offset, int Length, byte[] Databuffer);
            [DllImport("dcic32.dll")]
            //擦除固定的位置固定长度的数据
            public static extern short IC_Erase(int icdev, int offset, int Length);
            [DllImport("dcic32.dll")]
            //发出声音
            public static extern short IC_Beep(int icdev, int intime);

            [DllImport("dcic32.dll")]
             //读设备硬件版本号
            public static extern short IC_ReadVer(int icdev,  byte[] Databuffer);
            [DllImport("dcic32.dll")]
            //检查有无CPU卡
            public static extern short IC_Check_CPU(int icdev);
            [DllImport("dcic32.dll")]
            //检查CPU卡协议
            public static extern short IC_CpuGetProtocol(int icdev);
            [DllImport("dcic32.dll")]
            //检查卡类型
            public static extern short IC_CheckCard(int icdev);
    }
}
