using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace IcRw
{
    public partial class Form1 : Form

    {

        private int icdev;
        private short st;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            icdev = 0;
            st=0;
            byte[] data = new byte[1024];
            icdev = Ic.IC_InitComm(100);
            MessageBox.Show(icdev.ToString ());
            st= Ic.IC_Status(icdev);
            if (st==1)
            {
            MessageBox.Show("没有插卡");
            }
          
            //st = Ic.IC_InitType(icdev, 0x0c);
            st = Ic.IC_InitType(icdev, 0x10);
            MessageBox.Show(st.ToString());
            st= Ic.IC_ReadVer(icdev, data);
            MessageBox.Show( System.Text.Encoding.Default.GetString(data));

        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            st = Ic.IC_Beep(icdev, 100);
            MessageBox.Show(st.ToString ());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            st = Ic.IC_Check_CPU(icdev);
            MessageBox.Show(st.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            st = Ic.IC_CpuGetProtocol(icdev);
            MessageBox.Show(st.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            st = Ic.IC_Down (icdev);
            MessageBox.Show(st.ToString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
           st= Ic.IC_CheckCard(icdev);
           MessageBox.Show(st.ToString());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            st=Ic.IC_Read (icdev ,0,1024,data );
            MessageBox.Show(st.ToString ()+"||"+System.Text.Encoding.Default.GetString(data));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            st = Ic.IC_ExitComm(icdev);

            MessageBox.Show(st.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
          MessageBox.Show (  ic.IIcReadVer());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
            ic.IIcCheckPass("FFFFFF");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
            MessageBox .Show ( ic.IIcRead());
            ic.IIcClose();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
            if (ic.IIcCheckPass("123456"))
            {
                ic.IIcWrite(textBox1.Text);
            }
            ic.IIcClose();

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            IcInterface ic = new IcDc();
            ic.IIcInit();
            ic.IIcChangePass(textBox2.Text.Trim() );

        }
    }
}