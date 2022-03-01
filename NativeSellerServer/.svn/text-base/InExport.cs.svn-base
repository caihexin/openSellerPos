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
    public partial class InExport : Form
    {
        private  MySqlDde myCmd;
      

        public InExport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportDt(comboBox1.Text);
          
        

        }

        private void fillGv(DataTable dt, DataGridView dv)
        {
            dv.DataSource = dt.DefaultView;
        }

        private void exportDt( string flName)
        {
            DataSet Ds = new DataSet();
            SaveFileDialog of = new SaveFileDialog();
            of.FileName = flName + DateTime.Now.ToString("yyyy-MM-dd/HH-mm-ss");
            of.Filter = "(*.xml)|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {

                Ds.Tables.Add(getDt(flName ));
                Ds.WriteXml(of.FileName, XmlWriteMode.WriteSchema);

                MessageBox.Show("数据导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }

        private DataTable getDt( string dataTableString )
        {
            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { dataTableString };
            string[,] _order = new string[,] { { "id", "desc" } };

            return myCmd.getRecord(_fields, _tables, _order);

        }
        private void inExport_Load(object sender, EventArgs e)
        {
            BaseDate baseDt = new BaseDate();
            myCmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            fillCombobox();
           
        }

       
        private void fillCombobox()
        {
            
            DataTable dt = getDatatableNames();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr.ItemArray[0]);
            }

            comboBox1.SelectedIndex = 0;
       
        }
        //取mysql-crm中所有的表名
        private DataTable getDatatableNames()
        {
            string[] _fields = new string[] { "*" };

           return  myCmd.ExecCmd("show tables ;",_fields );

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            try
            {


                inportDt(comboBox1.Text);
                MessageBox.Show("数据导入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据导入失败 \n\r" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        private void   inportDt(string _tablenameString)
        {
            DataSet Ds = new DataSet();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(*.xml)|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Ds.ReadXml(of.FileName);
            }
            else
            {
                return  ;
            }
            
            DataTable dt= Ds.Tables[0];
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            StringBuilder tmpS;
            StringBuilder tmpS1;
            foreach (DataRow dr in dt.Rows)
            {
                tmpS = new StringBuilder();
                tmpS1 = new StringBuilder();
                tmpS.Append("call " + _tablenameString  + "Insert(");
                for (int i = 1; i < dr.ItemArray.Length; i++)
                {
                    tmpS.Append("'" + dr.ItemArray[i].ToString() + "',");


                }

                tmpS1.Append(tmpS.ToString(0, tmpS.Length - 1));
                tmpS1.Append(")");
                myCmd.ExeProcedure(tmpS1.ToString());
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            fillGv(getDt(comboBox1.Text ), dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }



        private void button6_Click(object sender, EventArgs e)
        {
          DialogResult dr=    MessageBox.Show("请确认删除历史数据,是否考虑备份？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question );

          if (dr == DialogResult.OK)
          {
              myCmd.tableName = "tmpxiaofei";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "currentsales";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "icmoney";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "rebates";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "vipxiaofei";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "vipxiaofeiliushui";
              myCmd.DeleteRecord(null);
              myCmd.tableName = "instore";
              myCmd.DeleteRecord(null);

              MessageBox.Show("数据删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }





        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }
    }
}