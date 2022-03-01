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
    public partial class StoreFrm : Form
    {
          public MySqlDde cmd;
        public StoreFrm()
        {
            InitializeComponent();
        }

        private void storeFrm_Load(object sender, EventArgs e)
        {

             BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            //dataGridView1.AutoGenerateColumns = false;
            fillGr();
        }
             private void fillGr()
        {

            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "storeproperty" };
            string[,] _order = new string[,] { { "id", "desc" } };

            dataGridView1.DataSource = cmd.getRecord(_fields, _tables, _order).DefaultView;
            // dataGridView1.Columns[0].ReadOnly = true;
            // dataGridView1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                addvip();
                fillGr();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
// 数据表名称: StoreProPerty
//创建时间:2007-1-15 22:09:46
//-----------------------------------------------------
//Create Table StoreProPerty(
//    ID	int  NOT NULL ,
//    storeDm	char(2)  NOT NULL ,
//    StoreName	varchar(50)  NOT NULL ,
//    StoreAddress	varchar(50)  NULL ,
//    storeTel	char(11)  NULL ,
//    linkName	char(8)  NULL 
//)

//GO
//ALTER TABLE StoreProPerty ADD  PRIMARY KEY  clustered 
//   ( ID )  ON [PRIMARY]

        private void addvip()
        {
            string _storedm,_storename,_storeaddress,_storetel,_linkname;

            _storedm = storedm.Text;
            _storename = storename.Text;
            _storeaddress = storeaddress.Text;
            _storetel = storetel.Text;
            _linkname = linkname.Text;

            cmd.tableName = "storeproperty";
            object[,] insertPara = new object[,] { 
                                                { "storedm", _storedm  },
                                                { "storename", _storename }, 
                                                { "storeaddress", _storeaddress  },
                                                { "storetel", _storetel },
                                                { "linkname", _linkname  }
                                                            };
            try
            {
                cmd.insertRecord(insertPara);
                msg.Text = "网点信息新增成功";
                initInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败,请核对有无相同网点编号!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void initInput()

        {
            storetel.Text  = "";
            storename.Text  = "";
            storedm.Text  = "";
            storeaddress.Text  = "";
            linkname.Text = "";
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            cmd.tableName = "storeproperty";
            object[,] delPara = new object[,] { { "id", "=", e.Row.Cells[0].Value.ToString() } };
            try
            {

                cmd.DeleteRecord(delPara);

                MessageBox.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());

           
            string _storedm, _storename, _storeaddress, _storetel, _linkname;

            _storedm = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            _storename = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            _storeaddress = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            _storetel = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            _linkname = dataGridView1.CurrentRow.Cells[5].Value.ToString();




            object[,] _updatePara = new object[,] { 
                                                { "storedm", _storedm  },
                                                { "storename", _storename }, 
                                                { "storeaddress", _storeaddress  },
                                                { "storetel", _storetel },
                                                { "linkname", _linkname  }
                                                            };

            object[,] _wherePara = new object[,] { { "id", "=", dataGridView1.CurrentRow.Cells[0].Value.ToString() } };
            cmd.tableName = "storeproperty";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}