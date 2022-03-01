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
    public partial class InObStoreFrm : Form
    {

  
        private string dmdm;


        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];

        private MySqlDde myremote;
        private DataTable obDs;
        public InObStoreFrm(string _dmdm)
        {
            InitializeComponent();
            dmdm = _dmdm;
            myremote = new MySqlDde(remotedatabase, tablename, user, passwd);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Tmpstring = textBox1.Text.Trim();
      
            DataRow[] dr = obDs.Select("obnamedm='" + Tmpstring + "'");
            if (dr.Length > 0)
            {
                label5.Text  = dr[0][2].ToString();
                

            }
            else
            {
                label5.Text = null ;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InObStoreFrm_Load(object sender, EventArgs e)
        {
       

            textBox3.Text = dmdm;
            obDs =  GetObData();
            ShowGridData(dataGridView1,obDs );
            ShowGridData(dataGridView2, GetTodayOb());

            

        }

   


        private void ShowGridData(DataGridView dv, DataTable dt)
        {
           dv.DataSource =  dt.DefaultView ;


        }


        private DataTable  GetObData( )
        {
            return  myremote.executeCmd ("select * from ob order by obnamedm").Tables[0];
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dmdm = textBox3.Text.Trim();
            string _storedm = dmdm;
            string _obNameDm = textBox1.Text.Trim();
            string _num = textBox2.Text.Trim();
            string _inTime = DateTime.Now.ToString();

            if (_storedm.Length == 0 || _num.Length == 0 || _obNameDm.Length == 0)
            {
                MessageBox.Show("对不起输入的数据有空，请检查\r\n", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
      
            if (int.Parse(_num) < 0)
            {
                MessageBox.Show("对不起\r\n入库数量不能为负，请申请库存调配", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            


            if (radioButton2.Checked == true)
            {
                _num = "-" + _num;
            }

            
     

            StringBuilder insertroomstr = new StringBuilder();
            insertroomstr.Append("call instoretoroom (");
            insertroomstr.Append("'" + _storedm + "',");
            insertroomstr.Append("'" + _obNameDm + "',");
            insertroomstr.Append("'" + _num + "',");
            insertroomstr.Append("'" + _inTime + "'");
            insertroomstr.Append(")");
            

            try
            {
                myremote.ExeProcedure( insertroomstr.ToString () );
                initscreen();
                ShowGridData(dataGridView2, GetTodayOb());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private DataTable GetTodayOb()
        {
            string todayobstr = "select * from instore where storedm='"+dmdm  +"' and  intime >='" 
                                + DateTime.Today.ToShortDateString()  +"'  order by intime desc";

            return myremote.executeCmd(todayobstr).Tables[0];

        }


        private void initscreen()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label5.Text = "商品名称";
            textBox1.Focus();
        }


        string pwd;
        private void label2_DoubleClick(object sender, EventArgs e)
        {
         //  = Microsoft.VisualBasic.Interaction.InputBox("请输入密码", "提示","",-1,-1);
         
           
            if (InputBox.Show("提示", "请输入密码", true ,ref pwd))
            {
                string pwdtime =DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                if (pwd == pwdtime)
                    radioButton2.Visible = true;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string Tmpstring = textBox1.Text.Trim() + "%";
            DataView dv = new DataView(obDs);
            try
            {
                dv.RowFilter = "obnamedm like  '" + Tmpstring + "'";
                dataGridView1.DataSource = dv;
                dataGridView1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            label5.Text=(dataGridView1.CurrentRow.Cells["column2"].Value).ToString() ;
            textBox1.Text = (dataGridView1.CurrentRow.Cells["column1"].Value).ToString();
            textBox2.Focus();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}