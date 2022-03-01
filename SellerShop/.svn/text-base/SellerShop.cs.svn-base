//11-28日更新
//2009-7-31更新加折扣功能
//2009-11-10 更新增加厨房打印功能 PrintCfDoc()
//2009-11-17 增加巴台打印功能 printBtDoc()
//2009-11-18 在info.xml 增加<printNum>X</printNum> X表示前台打印的数量
//2009-11-24 在info.xml 增加<unitPrice>X</unitprice> X为0 不能修改商品单价，X为1可以修改商品单价
//<printname>XXX</printname> 如果XXX为空即直接打印并口打印机，而非空即打印到WINDOWS打印机上
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using MySQLDriverCS;
using mySql;
//using SecurePass;
using System.Diagnostics;
using System.Xml;
//using MsMq;

namespace NativeSeller
{
    public partial class SellerShop : Form
    {


        public string dyname,dmdm;
        //远程数据配置
        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];




        public SellerShop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDde myremote = new MySqlDde(remotedatabase, tablename, user, passwd);

                //登录系统 
                string sqlString = "select dyname,dmdm from insidebase where dyname ='" + textBox1.Text + "' and   dysecure= '" + textBox2.Text + "'";

                DataSet ds = myremote.executeCmd(sqlString);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dyname = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    dmdm = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("密码有误，请核对！","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox2.Focus();

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接异常\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

   




        }



        private void SellerSale_Load(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Hide();
            splitContainer1.Panel2Collapsed = true;
            textBox4.ReadOnly = true;
            textBox1.Focus();






        }



    }
}