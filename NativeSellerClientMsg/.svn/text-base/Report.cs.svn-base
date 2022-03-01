using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySQLDriverCS;
using mySql;
namespace NativeSeller
{
    public partial class Report : Form
    {
        private  MySqlDde cmd;
        private string portName, printname, printFontValue; //打印机信息
        private DataTable dt;    //报表数据
        private StringBuilder prt;//打印数据
        private string logtag;
        private Loging log = new Loging();
        private string stringToPrint;
        private string storeDm;
        public Report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)

        {
            checkBox5.Checked = true;
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            portName = baseDt.portName;
            printname = baseDt.printname;
            logtag = baseDt.logtag;
            printFontValue = baseDt.printFontValue;
            storeDm = baseDt.storeroom;
            textBox4.Text = storeDm;
            fillGr(getData ());
           //  lbSum.Text = total(dt);
            dataGridView1.AutoGenerateColumns = false;
            button3.Enabled = false;
        }

        private DataTable getData()
        {

            string[] _fields = new string[] { "obname", "num", "total" };

            string query = "";
            if (checkBox2.Checked)
            {
                query = "select splb,sum(xfnum) as num ,sum(xfsum) as total  from reportxiaofei ";
            }
            else
            {

               query= "select obname,sum(xfnum) as num ,sum(xfsum) as total  from reportxiaofei  ";
            }
            if (checkBox1.Checked && checkBox5.Checked)
            {
                query += " where ";

                query += "vipnum = '" + textBox1.Text + "' and d between '" + textBox2.Text + "' and  '" + textBox3.Text + "' ";



            }

            else
            {
                if (checkBox1.Checked)
                {
                    query += " where ";

                    query += "vipnum = '" + textBox1.Text + "' ";

                }
                if (checkBox5.Checked)
                {

                    query += " where ";

                    query += " d between '" + textBox2.Text + "' and  '" + textBox3.Text + "' ";

                }
                

            }

            if (textBox4.Text.Trim().Length > 0)
            {
                query += " and  dmdm='" + textBox4.Text + "' ";

            }

            if (checkBox2.Checked)
            {
                query += "  group by splb order by obnamedm ";
            }
            else
            {
                query += "  group by obnamedm order by obnamedm ";
            }
            return  cmd.ExecCmd (query, _fields);
        }


        private string total(DataTable dt)
        {   
            decimal iCnt = 0;
            int irow=  dt.Rows.Count;
            if (irow > 0)
            {
                

                for (int i = 0; i < irow; i++)
                {
                    iCnt =iCnt + decimal.Parse(dt.Rows[i].ItemArray[2].ToString());

                }
            }
       


            return iCnt.ToString()  ;

        }


        private void fillGr(DataTable dt)
        {

            dataGridView1.DataSource = dt.DefaultView ;

            dataGridView1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dt = getData();
            lbSum.Text = total(dt);
            fillGr(dt);
            button3.Enabled = true;
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true ;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                
            }
            else
            {
                textBox2.ReadOnly = true ;
                textBox3.ReadOnly = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            prt = new StringBuilder();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    prt.Append("******商品销售报表******\n");
                    prt.Append(DateTime.Now.ToString() + "\n\r");
                    prt.Append("商品名称***数量***小计" + "\r\n");
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (string i in dr.ItemArray)
                        {
                            prt.Append(i + " *** ");


                        }

                        prt.Append("\n");

                    }
                }

                if (portName.Substring(0, 3).ToUpper() == "POS")
                {
                    log.writelog("销售报表ReportFrm--printDocument打印\r\n打印设备为:" + printname + "\r\n", logtag);
                    stringToPrint = prt.ToString();
                    PrintDoc();

                }
                else
                {

                    log.writelog("销售报表ReportFrm--portName打印\r\n打印端口为:" + portName + "\r\n", logtag);
                    Lpt pr = new Lpt(portName);
                    pr.lptPrint(prt.ToString());
                    pr.moveGoPage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {

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
    }
}