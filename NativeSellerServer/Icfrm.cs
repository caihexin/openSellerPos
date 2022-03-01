using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IcIo;
using System.Data.SqlClient;
using MySQLDriverCS;
using mySql;
namespace NativeSeller
{
    public partial class Icfrm : Form
    {
        
        
        private string username, dmdm;
        private string portname, nodestr, printname, printFontValue; //打印机信息;
        private MySqlDde myCmd;
        private string  _money;
        private StringBuilder prt;
        private string logtag;
        private Loging log = new Loging();
        public string  Money
        {
            set
            {
                _money = value;
            }
            get
            {
                return _money;
            }
        }

        private string _balance;
        public string balance
        {
            set
            {
                _balance = value;
            }
            get
            {
                return _balance;

            }
        }

        private IIc ic = new IcDc();

        public Icfrm(string _username,string _dmdm,string _portname,string _nodestr,MySqlDde _myCmd )
        {
            InitializeComponent();
            BaseDate baseDt = new BaseDate();
            printname = baseDt.printname;
            printFontValue = baseDt.printFontValue;
            logtag = baseDt.logtag;
            username = _username;
            dmdm = _dmdm;
            portname = _portname;
            nodestr = _nodestr;
            myCmd = _myCmd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                if (ic.IIcCheckPass("888888"))
                {

                    label2.Text = ic.IIcRead();
                    if (double.Parse(label2.Text) > 0)
                    {
                        textBox1.Enabled = true;
                        button2.Enabled = true;
                        textBox1.Focus();
                    }


                }
            }
            else
            {
                textBox2.Focus();
                MessageBox.Show("请输入卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ic.IIcCheckPass("888888"))
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    return;
                }
                double money = double.Parse(label2.Text) - double.Parse(textBox1.Text.Trim());
                if (money < 0)
                {
                    MessageBox.Show("卡内金额不足 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (ic.IIcWrite(money.ToString()))
                    {
                        DialogResult dr = MessageBox.Show("付款/--" + textBox1.Text.Trim() + "元--/成功 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            Money = textBox1.Text.Trim();
                            balance = money.ToString();
                            print();
                            insertIcMoney();

                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("付款失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

            ic.IIcClose();


           // insertIcMoney();

        }

        private void Icfrm_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox1.Enabled = false;
            button2.Enabled = false;
        }
        private void insertIcMoney()
        {
            try
            {
                MySQLParameter[] Sqlparam = new MySQLParameter[6];
                Sqlparam[0] = new MySQLParameter("@saledate", SqlDbType.Char);
                Sqlparam[0].Value = DateTime.Today.ToShortDateString();
                Sqlparam[1] = new MySQLParameter("@dyname", SqlDbType.Char);
                Sqlparam[1].Value = username;
                Sqlparam[2] = new MySQLParameter("@dmdm", SqlDbType.Char);
                Sqlparam[2].Value = dmdm ;
                Sqlparam[3] = new MySQLParameter("@icvalue", SqlDbType.Money );
                Sqlparam[3].Value =double.Parse ( textBox1.Text.Trim());
                Sqlparam[4] = new MySQLParameter("@balance", SqlDbType.Char);
                Sqlparam[4].Value = balance;
                Sqlparam[5] = new MySQLParameter("@icnum", SqlDbType.Char);
                Sqlparam[5].Value = textBox2.Text.Trim();
               // myCmd.ExecuteProcedurePara("insertIcMoney", Sqlparam);
                myCmd.ExeMysql("insert into icmoney(saledate,dyname,dmdm,icvalue,balance,icnum) values(@saledate,@dyname,@dmdm,@icvalue,@balance,@icnum)", Sqlparam);

                string body = "insert into icmoney(saledate,dyname,dmdm,icvalue,balance,icnum) values('"
                                +DateTime.Today.ToShortDateString() +"','"
                                + username +"','"
                                + dmdm +"','"
                                + double.Parse ( textBox1.Text.Trim()) +"','"
                                + balance+"','"
                                + textBox2.Text.Trim()
                                +"')";
                body=body.Replace("'", "*");
                myCmd.ExeMysql(body);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void print()
        {
            prt = new StringBuilder();
            prt.Append("********************"+ nodestr +"***********************\n");
            prt.Append("消费IC金额：" + textBox1.Text.Trim() + "\n");
            prt.Append("消费时间：" + DateTime.Now +"\n");
            prt.Append("卡内余额："+balance+"\n");
            if (portname.Substring(0, 3).ToUpper() == "POS")
            {
                log.writelog("IC收银Icfrm--printDocument打印\r\n打印机名称：" + printname + "\r\n", logtag);
                PrintDoc();
                PrintDoc();

            }
            else
            {
                log.writelog("IC收银Icfrm--LPT打印\r\n 端口号：" + portname + "\r\n", logtag);
                Lpt lpt = new Lpt(portname);
                lpt.lptPrint(prt.ToString());
                lpt.lptPrint(prt.ToString());
                lpt.moveGoPage();
            }


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font
            ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(prt.ToString(), printFont, System.Drawing.Brushes.Black, 10, 10);
        }
        private void PrintDoc()
        {
            printDocument1.PrinterSettings.PrinterName = printname;//设置打印机名称
            printDocument1.Print();



        }



    }
}