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
    public partial class IcReport : Form
    {


        private MySqlDde cmd;

        public IcReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //saledate as 消费时间,dyname as 收银员,dmdm as 网点,icvalue as 消费金额,balance as 卡内剩余金额,icnum as 卡号
            string sS = "select * from icmoney where icnum='" + textBox1.Text + "' order by saledate";
            DataSet ds = new DataSet();
            ds = cmd.executeCmd(sS);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;




        }

        private void IcReport_Load(object sender, EventArgs e)
        {
            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet dtin = cmd.executeCmd("select sum(icvalue) as  ICin  from icmoney  where saledate >=  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and saledate<= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'");
            label5.Text = dtin.Tables[0].Rows[0].ItemArray[0].ToString();

        }








    }
}