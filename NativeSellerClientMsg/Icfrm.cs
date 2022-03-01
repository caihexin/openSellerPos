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
using LptControl;
namespace NativeSeller
{
    public partial class Icfrm : Form
    {

        //定义打印机
         private  LptInterface lpt = new LptPrint();
         private  LptInterface lptpos = new LptPos();
        private string pwlength = System.Configuration.ConfigurationSettings.AppSettings["pwlength"];
        private string phlength = System.Configuration.ConfigurationSettings.AppSettings["phlength"];
        private string pfont = System.Configuration.ConfigurationSettings.AppSettings["pfont"];


        private string username, dmdm;
        private string portname, nodestr, printname, printFontValue; //打印机信息;
        private MySqlDde myCmd;
        private string _money;
        
        private string pString="";
        private string logtag;
        private Loging log = new Loging();
        public string Money
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

        public Icfrm(string _username, string _dmdm, string _portname, string _nodestr, MySqlDde _myCmd)
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
                    string _icnum = ic.IIcRead(10, 10);//读取卡信息
                    string Icr = ic.IIcRead().Trim();
                    if (Icr.Length == 0|| Icr == null||Icr.Length ==1024)
                    {
                        MessageBox.Show("请注意此IC卡为空卡或者为废卡！\r\n" , "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    //string[] icsplit = Icr.Split(new char[] { '*' });
                    if (_icnum.Length == 1024)
                    {
                        DialogResult result = MessageBox.Show("此卡可能为老卡，请仔细核实！\r\n建议更换新卡", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            label5.Text = textBox2.Text.Trim();
                            label2.Text = Icr;

                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        label5.Text = _icnum;
                        label2.Text = Icr;
                    }

                    try
                    {
                        //提醒收银员此卡金额较大需注意
                        if (double.Parse(label2.Text) >= 1000)
                        {
                            DialogResult result1 = MessageBox.Show("此卡金额较大，请仔细核实！", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.No)
                            {

                                return;

                            }

                        }

                        if (double.Parse(label2.Text) > 0)
                        {
                            textBox1.Enabled = true;
                            button2.Enabled = true;
                            textBox1.Focus();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("请注意此IC卡有异常！\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    MessageBox.Show("输入的金额不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
                try
                {
                    double x = double.Parse(textBox1.Text);

                }
                catch
                {
                    MessageBox.Show("输入的金额不正确", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                if (textBox2.Text.Trim() != label5.Text)
                {
                    MessageBox.Show("注意IC卡号不一致！请核实", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                double money = double.Parse(label2.Text) - double.Parse(textBox1.Text.Trim());//计算卡内金额
                if (money < 0)
                {
                    MessageBox.Show("卡内金额不足 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //将余额写入IC卡

                    if (ic.IIcWrite(money.ToString("f2")))
                    {
                        DialogResult dr = MessageBox.Show("付款/--" + textBox1.Text.Trim() + "元--/成功 ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            Money = textBox1.Text.Trim();
                            balance = money.ToString("f2");
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
            else
            {
                MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Sqlparam[2].Value = dmdm;
                Sqlparam[3] = new MySQLParameter("@icvalue", SqlDbType.Money);
                Sqlparam[3].Value = double.Parse(textBox1.Text.Trim());
                Sqlparam[4] = new MySQLParameter("@balance", SqlDbType.Char);
                Sqlparam[4].Value = balance;
                Sqlparam[5] = new MySQLParameter("@icnum", SqlDbType.Char);
                Sqlparam[5].Value = textBox2.Text.Trim();
                // myCmd.ExecuteProcedurePara("insertIcMoney", Sqlparam);
                myCmd.ExeMysql("insert into icmoney(saledate,dyname,dmdm,icvalue,balance,icnum) values(@saledate,@dyname,@dmdm,@icvalue,@balance,@icnum)", Sqlparam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog("ICFRM-insertIcMoney_ICmoney" + DateTime.Now.ToLongTimeString() + "\r\n" , logtag);
            }



            string body = "insert into icmoney(saledate,dyname,dmdm,icvalue,balance,icnum) values( '" + DateTime.Today.ToShortDateString() + "','"+ username + "','"+ dmdm + "','"+ double.Parse(textBox1.Text.Trim()) + "','" + balance + "','" + textBox2.Text.Trim() + "')";
            body = body.Replace("'", "*");
            string instring = "insert msg(content) values('" + body  + "')";
            try
            {
                myCmd.ExeMysql(instring);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog("insertIcMoney" + DateTime.Now.ToLongTimeString() + "\r\n" + body, logtag);

            }




        }

        private void print()
        {
            StringBuilder prt = new StringBuilder();
            prt.Append("********************" + nodestr + "***********************\n");
            prt.Append("消费IC金额：" + textBox1.Text.Trim() + "\n");
            prt.Append("消费时间：" + DateTime.Now + "\n");
            prt.Append("卡内余额：" + balance + "\n");
            pString = prt.ToString() + "\r\n***********\r\n**********\r\n**********\r\n" + prt.ToString();
            if (portname.Substring(0, 3).ToUpper() == "POS")
            {
                log.writelog("IC收银Icfrm--printDocument打印\r\n打印机名称：" + printname + "\r\n", logtag);
               
                PrintDoc();
                //PrintDoc();

            }
            else
            {
                log.writelog("IC收银Icfrm--LPT打印\r\n 端口号：" + portname + "\r\n", logtag);
                //Lpt lpt = new Lpt(portname);
                //lpt.lptPrint(prt.ToString());
                //lpt.lptPrint(prt.ToString());
                //lpt.moveGoPage();

                lpt.print(portname, pString);
                

            }


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font
            ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(pString, printFont, System.Drawing.Brushes.Black, 10, 10);
        }
        private void PrintDoc()
        {
            //printDocument1.PrinterSettings.PrinterName = printname;//设置打印机名称
            //printDocument1.Print();
            try
            {
                lptpos.print2(portname, pString, int.Parse(pwlength), int.Parse(phlength), int.Parse(pfont));
            }
            catch (Exception ex)
            {
                MessageBox.Show("PrintDoc" + ex.Message);
            }


        }

        private void Icfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ic.IIcClose();
        }



    }
}