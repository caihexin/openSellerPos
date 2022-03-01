using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySQLDriverCS;
using mySql;
using System.IO;

namespace NativeSeller
{
    public partial class StoreRptFrm : Form
    {
        private MySqlDde myCmd;
        private DataTable Dt;
       // private DataTable  storeDt,instoreDt,outDt;
        private string storeroom; //网点号
        private BaseDate baseDt;
        private string portName, printname, printFontValue; //打印机信息
        private StringBuilder prt;
        private string logtag;
        private Loging log = new Loging();
        private string stringToPrint;  //修正多页打印
        public StoreRptFrm()
        {
            InitializeComponent();
        }

        private void StoreRptFrm_Load(object sender, EventArgs e)
        {
            
            baseDt = new BaseDate();
            myCmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            storeroom = baseDt.storeroom;
            textBox1.Text = storeroom;
            portName = baseDt.portName;
            printname = baseDt.printname;
            printFontValue = baseDt.printFontValue;
            logtag = baseDt.logtag;
            Dt =GetStoreData();
            baseDt.ShowGridData(dataGridView1,Dt  );
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            storeroom = textBox1.Text.Trim();
            if (storeroom.Length == 0)
                return;

            if (radioButton1.Checked )
            {
                Dt = GetInStoreData();
               // baseDt.ShowGridData(dataGridView1, instoreDt);
            }

            if (radioButton2.Checked)
            {
                Dt = GetOutData();
               // baseDt.ShowGridData(dataGridView1, outDt);
            

            }

            if (radioButton3.Checked)
            {
                Dt = GetStoreData();
                // baseDt.ShowGridData(dataGridView1, storeDt);
            }

            baseDt.ShowGridData(dataGridView1, Dt);
            prt = new StringBuilder();
            prt = GetPrtData(Dt, prt);
            button2.Enabled = true;
            button3.Enabled = true;

        }

        private DataTable GetInStoreData()
        {
            //substr(intime,1,10)
            string instorestr = "select i.obnamedm  ,o.obname , sum(num) as sum from instore i ,  ob o where i.obnamedm=o.obnamedm and date(intime) between "
                          + "date('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + " ') and date( '"
                          + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') and storeDm='" + storeroom + "' group by i.obnamedm order by i.obnamedm";
            return myCmd.executeCmd(instorestr).Tables[0];

        }



        private DataTable GetStoreData()
        {

            string storestr = "select s.obnamedm  ,o.obname , num from storeroom s ,  ob o where s.obnamedm=o.obnamedm and storeDm='" + storeroom + "' order by s.obnamedm";
            return  myCmd.executeCmd(storestr).Tables[0];


        }


        private DataTable GetOutData()
        {
          string outstr= " select obnamedm,obname , sum(xfnum) as num from reportxiaofei  where  d between "
                          + "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + " ' and  '"
                          + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and dmDm='" + storeroom + "' group by obname  order by obnamedm";

          return myCmd.executeCmd(outstr).Tables[0];


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prt = new StringBuilder();
            try
            {
                if (radioButton3.Checked)
                {
                    prt.Append("*******网点库存报表******\n\r");
                    prt.Append(DateTime.Now.ToString() + "\n\r");
                    prt = GetPrtData(Dt,prt );
                }
                if (radioButton1.Checked)
                {
                    prt.Append("*******网点进货报表******\n\r");
                    prt.Append(DateTime.Now.ToString() + "\n\r");
                    prt = GetPrtData(Dt,prt );
                }
                if (radioButton2.Checked)
                {
                    prt.Append("*******网点出货报表******\n\r");
                    prt.Append(DateTime.Now.ToString() + "\n\r");
                    prt = GetPrtData(Dt,prt );
                }

               
                if (portName.Substring(0, 3).ToUpper() == "POS")
                {
                    log.writelog("库存报表StoreRptFrm--printDocument打印\r\n打印设备为:" + printname + "\r\n", logtag);
                    stringToPrint = prt.ToString();
                    PrintDoc();
                    
                
                }
                else
                {
                    log.writelog("库存报表StoreRptFrm--LPT打印\r\n端口号为:" + portName + "\r\n", logtag);
                    Lpt pr = new Lpt(portName);
                    pr.lptPrint(prt.ToString());
                    pr.moveGoPage();
                }
              



            }
            catch (Exception ex)
            {
                MessageBox.Show("数据异常，请重试查询再打印"+ex.Message ,"提示",MessageBoxButtons.OK ,MessageBoxIcon.Information );
            }
          

            button2.Enabled = false;

        }

        private void storeWrite(string prt)
        {
            StreamWriter sw = new StreamWriter("c:\\store" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true, System.Text.Encoding.GetEncoding("GB2312"));
            sw.Write(prt);
            sw.Close();




        }



        private StringBuilder  GetPrtData(DataTable dt,StringBuilder prt)
        {
        
            if (dt.Rows.Count > 0)
            {

                prt.Append ( "商品代码**商名名称**数量"+"\r\n");
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (string i in dr.ItemArray)
                    {
                        prt.Append(i + " ** ");

                    }

                    prt.Append("\n\r");

                }
            }

            return prt;

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

            log.writelog("StoreRptFrm--PrintDocument打印内容:\r\n" + stringToPrint + "\r\n", logtag);


        }


        private void PrintDoc()
        {
            printDocument1.PrinterSettings.PrinterName = printname;//设置打印机名称
            printDocument1.Print();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            storeWrite(prt.ToString());
            MessageBox.Show("store####-##-##.txt文件生成成功,请到C：下查看相关文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button3.Enabled = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}