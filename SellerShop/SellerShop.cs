//11-28�ո���
//2009-7-31���¼��ۿ۹���
//2009-11-10 �������ӳ�����ӡ���� PrintCfDoc()
//2009-11-17 ���Ӱ�̨��ӡ���� printBtDoc()
//2009-11-18 ��info.xml ����<printNum>X</printNum> X��ʾǰ̨��ӡ������
//2009-11-24 ��info.xml ����<unitPrice>X</unitprice> XΪ0 �����޸���Ʒ���ۣ�XΪ1�����޸���Ʒ����
//<printname>XXX</printname> ���XXXΪ�ռ�ֱ�Ӵ�ӡ���ڴ�ӡ�������ǿռ���ӡ��WINDOWS��ӡ����
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
        //Զ����������
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

                //��¼ϵͳ 
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
                    MessageBox.Show("����������˶ԣ�","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox2.Focus();

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("���ݿ������쳣\r\n" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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