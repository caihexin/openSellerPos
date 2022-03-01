using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;

namespace NativeSeller
{
    public partial class VipXfList : Form
    {

        public MySqlDde cmd;
        private string portName,printname, printFontValue; //打印机信息
        private  DataTable dt ;
        private string printstring;
        private string logtag;
        private Loging log = new Loging();
        string stringToPrint ;
        public VipXfList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDate baseDt = new BaseDate();
            portName = baseDt.portName;
            printname = baseDt.printname;
            printFontValue = baseDt.printFontValue;
            logtag = baseDt.logtag;
            try
            {
                string xfStr = "select * from vipxiaofei where vipnum = '" + textBox1.Text.Trim() + "'";
                cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
                dt = cmd.executeCmd(xfStr).Tables[0];
                dataGridView1.DataSource = dt.DefaultView;

                string sS1 = "select * from icmoney where icnum='" + textBox1.Text + "' order by saledate";
                DataSet ds1 = new DataSet();
                ds1 = cmd.executeCmd(sS1);
                dataGridView2.DataSource = ds1.Tables[0].DefaultView;

                string sS2 = "select * from ic where icnum='" + textBox1.Text + "' order by outdate";
                DataSet ds2 = new DataSet();
                ds2 = cmd.executeCmd(sS2);
                dataGridView3.DataSource = ds2.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog(DateTime.Now.ToLongTimeString() + "::" + ex.Message, logtag);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            printstring="";

            int j, k;
            k = dt.Rows.Count;
            for (j = 0; j < k; j++)
            {

                printstring += dt.Rows[j]["xfdz"].ToString() + "\n";
                printstring += dt.Rows[j]["obname"].ToString() + " * ";
                printstring += dt.Rows[j]["unitprice"].ToString() + " * ";
                printstring += dt.Rows[j]["xfnum"].ToString() + " * ";
                printstring += dt.Rows[j]["xfsum"].ToString() + " * ";
                printstring += " \n";
                
          
            }
            if (portName.Substring(0, 3).ToUpper() == "POS")
            {
                log.writelog("会员消费记录VipxfList--printDocument打印\r\n打印机名称："+printname+"\r\n", logtag);
                stringToPrint = printstring;
                PrintDoc();

            }
            else
            {
                log.writelog("会员消费记录VipxfList--LPT打印\r\n 端口号：" + portName + "\r\n", logtag);
                Lpt pr = new Lpt(portName);
                pr.lptPrint(printstring);
                pr.moveGoPage();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(stringToPrint, printFont, System.Drawing.Brushes.Black, 10, 10);


            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

        }

        private void PrintDoc()
        {
            printDocument1.PrinterSettings.PrinterName = printname;//设置打印机名称
            printDocument1.Print();



        }

        private void VipXfList_Load(object sender, EventArgs e)
        {
           
        }



    }
}