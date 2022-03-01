using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccess;
namespace NativeSeller
{
    public partial class OdFrm : Form
    {

        private IData db = new SqliteData("seller.db");

        public OdFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string s = "select obnamedm, obname, sum(ordernum) from orders  where date(ordertime) >= '" +
                                                                startDate +
                                                                "' and  date(ordertime) <= '" +
                                                                endDate + "' group by obnamedm ,obname";

            try
            {
                DataTable odt = GetDt(s);
                ShowDataView(odt, dataGridView1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }







        }

        private DataTable GetDt(string odwhere)
        {
           return   db.show(odwhere).Tables[0];


        }


        private void ShowDataView(DataTable dt, DataGridView dv)
        {
            dv.DataSource = dt.DefaultView;



        }

        private void OdFrm_Load(object sender, EventArgs e)
        {
            
            try
            {
                DataTable odt = GetDt("select id, obnamedm as 商品代码,obname as 商品名称,ordernum as 数量,storedm as 网点,dyname as 店员,ordertime as 时间,orderstate as 状态  from orders ");
                ShowDataView(odt, dataGridView1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

       

        }


    }
}