using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;
using MySQLDriverCS;
namespace NativeSeller
{
    public partial class RebatesFrm : Form
    {

        private  MySqlDde sellerCmd;
        public RebatesFrm()
        {
            InitializeComponent();
        }

        private void rebatesFrm_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BaseDate baseDt = new BaseDate();
            sellerCmd  = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;
            if (textBox3.Text.Length == 0)
                return;

            try
            {
                string rebateStr = " select dyname ,saledate , sum(rebates) as rebates  from rebates   where   saledate between  '" + DateTime.Parse(textBox2.Text).ToShortDateString() + "' and  '" + DateTime.Parse(textBox3.Text).ToShortDateString() + "'  GROUP BY dyname,saledate order by saledate";
                DataTable rDt = sellerCmd.executeCmd(rebateStr).Tables[0];


                dataGridView1.DataSource = rDt.DefaultView;
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message, "¾¯¸æ", MessageBoxButtons.OK);
            }



        }
    }
}