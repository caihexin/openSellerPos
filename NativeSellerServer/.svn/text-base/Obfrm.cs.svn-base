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
    public partial class Obfrm : Form
    {
       // private mySqlDde myCmd;
        public MySqlDde cmd;
        public Obfrm()
        {
            InitializeComponent();
        }

        private void obfrm_Load(object sender, EventArgs e)
        {
            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            dataGridView1.AutoGenerateColumns = false;
            fillGr();


        }
        private void fillGr()
        {

            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "ob" };
            string[,] _order = new string[,] { { "id", "desc" } };

            dataGridView1.DataSource = cmd.getRecord(_fields, _tables,_order ).DefaultView;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //获取CurrentRow各值
            string _id, _obnamedm, _obname, _unitprice;
            _id = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            _obnamedm = (dataGridView1.CurrentRow.Cells[1].Value).ToString();
            _obname = (dataGridView1.CurrentRow.Cells[2].Value).ToString();
            _unitprice = (dataGridView1.CurrentRow.Cells[3].Value).ToString();


            object[,] _updatePara = new object[,] { { "obnamedm", _obnamedm   }, 
                                                    {"obname",_obname   },
                                                    {"unitprice",_unitprice }

                                                 };

            object[,] _wherePara = new object[,] { { "id", "=", _id } };
            cmd.tableName = "ob";
            try
            {
                cmd.updateRecord(_updatePara, _wherePara);
                MessageBox.Show("数据更新成功", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败" + "\r\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                addob();
                fillGr();
            }

            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void addob()

        {
            string _obnamedm, _obname;
            decimal  _unitprice;
            _obnamedm = textBox1.Text.Trim ();
            _obname = textBox2.Text.Trim ();
            _unitprice = decimal.Parse(textBox3.Text.Trim());
                        
            cmd.tableName = "ob";
            object[,] insertPara = new object[,] { { "obnamedm", _obnamedm  }, { "obname", _obname  }, { "unitprice", _unitprice  } };
            try
            {
                cmd.insertRecord(insertPara);
                msg.Text = "商品信息新增成功";
                initInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败,请核对有无相同商品编号!"+"\r\n"+ex.Message ,"警告",MessageBoxButtons.OK ,MessageBoxIcon.Error  );
            }

        }
        private void initInput()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
         
          
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {  
          //  MessageBox.Show ( e.Row.Cells[0].Value.ToString () );
                 cmd.tableName = "ob";
                 object[,] delPara = new object[,] { { "id", "=", e.Row.Cells[0].Value.ToString() } };
            try
            {

                cmd.DeleteRecord(delPara);

                MessageBox.Show("删除成功!" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

         

        }

        private void button2_Click(object sender, EventArgs e)

        {
            DataSet Ds = new DataSet();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(*.xml)|*.xml";
           // of.FileName = "xf";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Ds.ReadXml(of.FileName);
            }
            else
            {
                return;
            }


            cmd.tableName = "ob";
            cmd.DeleteRecord(null);

            DataTable msDt = new DataTable();
                  
            msDt = Ds.Tables[0];
            string _obnamedm;
            string _obname;
            string _unitprice;
            string insertString;
            insertString = "insert ob(obnamedm,obname,unitprice) values";
            int i, j;
            i = msDt.Rows.Count;

            for (j = 0; j < i; j++)
            {
                _obnamedm = msDt.Rows[j].ItemArray[1].ToString();
                _obname = msDt.Rows[j].ItemArray[2].ToString();
                _unitprice = msDt.Rows[j].ItemArray[3].ToString();

                insertString += "('"
                                + _obnamedm + "','"
                                + _obname + "','"
                                + _unitprice + "'"
                                + "),";

            }
            insertString = insertString.Substring(0, insertString.Length - 1);
            cmd.ExeMysql(insertString);
            fillGr();
            MessageBox.Show("商品代码数据导入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet Ds = new DataSet();
            SaveFileDialog  of = new SaveFileDialog() ;
            of.Filter = "(*.xml)|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {
             
                Ds.Tables.Add(getObDt());
                Ds.WriteXml(of.FileName, XmlWriteMode.WriteSchema);

                MessageBox.Show("商品代码数据导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }

        }

        private DataTable getObDt()
        {
            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "ob" };
            string[,] _order = new string[,] { { "id", "desc" } };

          return   cmd.getRecord(_fields, _tables, _order);

        }






    }
}