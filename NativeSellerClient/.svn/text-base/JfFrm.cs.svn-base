using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using MySQLDriverCS;
using mySql;
namespace NativeSeller
{
    public partial class JfFrm : Form
    {
        public MySqlDde cmd;
        public JfFrm()
        {
            InitializeComponent();
        }

        private void jfFrm_Load(object sender, EventArgs e)
        {
            checkBox5.Checked = true;
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            fillGr(getData());
            fillGrjfView();

        }
        private DataTable getData()
        {

            string[] _fields = new string[] { "会员号","会员姓名", "消费总额","积分" ,"联系电话","移动电话" };

            string query = "select a.vipnum , b.vipname ,sum(xfsum) as total ,c.xfjf  , b.viptel,b.vipmob from reportxiaofei a , vipbase b   ,vipxiaofeijifen c   ";



            if (checkBox5.Checked)
            {

                query += " where ";

                query += " ( d between '" + textBox2.Text + "' and  '" + textBox3.Text + "' ) and  ";

            }
            else
            {
                query += " where ";
            }

            
                query += "  (a.vipnum = b.vipnum)  and (a.vipnum=c.vipnum) group by vipnum order by vipnum ";

           // return cmd.Exec(query, _fields);

              DataTable dt=  cmd.ExecCmd (query, _fields);
              return dt;



        }


        private void fillGr(DataTable dt)
        {
           
 
            dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor =Color.Blue ;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Focus();
        }

        private void fillGrjfView()
        {
            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "jfview" };
            dataGridView2.DataSource = cmd.getRecord(_fields, _tables).DefaultView;
            dataGridView2.AutoGenerateColumns = false;
            
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
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillGr(getData());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //获取CurrentRow各值
            string _vipnum, _xfjf  ;
            _vipnum = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            _xfjf = (dataGridView1.CurrentRow.Cells[3].Value).ToString();
         
       
            object[,] _updatePara = new object[,] { { "xfjf", _xfjf }
                                                    };

            object[,] _wherePara = new object[,] { { "vipnum", "=", _vipnum } };
            cmd.tableName = "vipxiaofeijifen";
            try
            {
                cmd.updateRecord(_updatePara, _wherePara);
                MessageBox.Show("数据更新成功", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            fillGrjfView();


        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //获取CurrentRow各值
            string _vipnum, _xfjf;
            _vipnum = (dataGridView2.CurrentRow.Cells[1].Value).ToString();
            _xfjf = (dataGridView2.CurrentRow.Cells[2].Value).ToString();


            object[,] _updatePara = new object[,] { { "xfjf", _xfjf }
                                                    };

            object[,] _wherePara = new object[,] { { "vipnum", "=", _vipnum } };
            cmd.tableName = "vipxiaofeijifen";
            try
            {
                cmd.updateRecord(_updatePara, _wherePara);
                MessageBox.Show("数据更新成功", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         //   MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString());


            



        }
    }
}