using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IcIo;
using DataAccess;
namespace IcAdmin
{
    public partial class IcAdminFrm : Form
    {
      
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
                MessageBox.Show("密码检验失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            ic.IIcClose();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 0)
            {
                MessageBox.Show("请输入IC卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            
            
            IIc ic = new IcDc();
            if (ic.IIcCheckPass("888888"))
            {
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

                }
            }
            else
            {
                MessageBox.Show("密码检验失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ic.IIcClose();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            IIc ic = new IcDc();
            if (ic.IIcCheckPass("888888"))
            {

                MessageBox.Show(ic.IIcRead(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("密码检验失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ic.IIcClose();
        }

        private void insertRecord()
        {
            IData db = new SqliteData("sales.db");
            string insertSqlCom = "insert into outrecord(outdate,outvalue,icnum) values('"+DateTime.Now.ToString ("yyyy-MM-dd") +"','" + textBox1.Text.Trim () +"','" + textBox2.Text.Trim() +"' )";
            db.insert(insertSqlCom);
          

        }

        private void sumRecord()
        {

            IData db = new SqliteData("sales.db");
            DataSet dt = db.show("select sum(outvalue) as 发卡总金额  from outrecord  where outdate >=  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and outdate<= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'");
            dataGridView1.DataSource = dt.Tables[0].DefaultView;

        }


        private void button4_Click(object sender, EventArgs e)
        {
            sumRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox2.Focus();

        }

     




    }
}