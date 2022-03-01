using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IcIo;
//using DataAccess;
using mySql;
namespace NativeSeller
{
    public partial class IcAdminFrm : Form
    {
        private string logTag = System.Configuration.ConfigurationSettings.AppSettings["logTag"];
        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];
        private MySqlDde db;
        private Loging log = new Loging();
        public IcAdminFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IIc ic = new IcDc();
            if (ic.IIcCheckPass("FFFFFF"))
            {
                if (ic.IIcChangePass("888888"))
                {
                    MessageBox.Show("密码更新成功，可以充值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("密码更新失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("读密码失败，请仔细检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ic.IIcClose();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 0 || textBox2.Text.Length>10)
            {
                MessageBox.Show("请输入IC卡号且不能超5位", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Length <= 0)
            {
                MessageBox.Show("请再次输入IC卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("请确认IC卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;

            }

            if (textBox1.Text.Length == 0||textBox1.Text.Length>4)
            {
                MessageBox.Show("输入的金额不能为空,且不能大于9999元", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            try
            {
                int x = int.Parse(textBox1.Text);

            }
            catch
            {
                MessageBox.Show("输入的金额不正确", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            IIc ic = new IcDc();
            if (ic.IIcCheckPass("888888"))
            {

                //写入卡号
                if (!ic.IIcWrite(textBox2.Text.Trim(), 10, 10))
                {
                    log.writelog("ICADMIN-写卡号失败" + DateTime.Now.ToLongTimeString(), logTag);
                }




                //写入充值金额

                if (ic.IIcWrite(textBox1.Text.Trim()))
                {
                    DialogResult dr = MessageBox.Show("充值/--" + textBox1.Text.Trim() + "元--/成功 ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        insertRecord();
                    }
                    else
                    {
                        MessageBox.Show("重新确认充值金额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("充值失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.writelog("ICADMIN-充值失败" + DateTime.Now.ToLongTimeString(), logTag);

                }
            }
            else
            {
                MessageBox.Show("读密码失败，请仔细检查！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            ic.IIcClose();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            IIc ic = new IcDc();
            if (ic.IIcCheckPass("888888"))
            {
               
                
                string _icnum = "卡号：" + ic.IIcRead(10, 10);

                string _icvalue = "金额（元）：" + ic.IIcRead();

                textBox5.Text = _icnum.Trim () ;
                textBox4.Text = _icvalue.Trim();



            } 
            else
            {
                MessageBox.Show("读密码失败，请仔细检查！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Text = "";
                

            }

            ic.IIcClose();
        }

        private void insertRecord()
        {
            //IData db = new SqliteData("sales.db");

            string insertSqlCom = "insert into ic(outdate,outvalue,icnum) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "' )";
            try
            {
                db.ExeMysql(insertSqlCom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog("ICADMIN-inserrecord" + DateTime.Now.ToLongTimeString() + ex.Message, logTag);
            }

        }

        private void sumRecord()
        {

            try
            {
                DataSet dtout = db.executeCmd("select sum(outvalue) as  ICout  from ic  where outdate >=  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and outdate<= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'");
                label6.Text = dtout.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet dtin = db.executeCmd("select sum(icvalue) as  ICin  from icmoney  where saledate >=  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and saledate<= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'");
                label9.Text = dtin.Tables[0].Rows[0].ItemArray[0].ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog("ICADMIN-sumRecord" + DateTime.Now.ToLongTimeString() + ex.Message, logTag);
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            sumRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox2.Focus();
            db = new MySqlDde(remotedatabase, tablename, user, passwd);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            IIc ic = new IcDc();
            if (ic.IIcCheckPass("888888"))
            {
                if (ic.IIcChangePass("888888"))
                {
                    MessageBox.Show("密码更新成功，可以充值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("密码更新失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("读密码失败，请仔细检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ic.IIcClose();
        }






    }
}