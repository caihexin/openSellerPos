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
    public partial class Insidebasefrm : Form
    {

        public MySqlDde cmd;

        public Insidebasefrm()
        {
            InitializeComponent();
        }

        private void insidebasefrm_Load(object sender, EventArgs e)

        {   BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            dataGridView1.AutoGenerateColumns = false;
            fillGr();

        }
        private void fillGr()
        {
             
            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "insidebase"  };
            string[,] _order = new string[,] { { "id", "desc" } };
            dataGridView1.DataSource =    cmd.getRecord(_fields   , _tables,_order ).DefaultView;
            dataGridView1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

         




        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //获取CurrentRow各值
            string _id, _dyname, _dysecure, _dysfz, _dyemail, _dytel, _dymob, _dyhome, _rulename, _birthday, _dmdm;
            _id = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            _dyname = (dataGridView1.CurrentRow.Cells[1].Value).ToString();
            _dysecure = (dataGridView1.CurrentRow.Cells[2].Value).ToString();
            _dysfz = (dataGridView1.CurrentRow.Cells[3].Value).ToString();
            _dyemail = (dataGridView1.CurrentRow.Cells[4].Value).ToString();
            _dytel = (dataGridView1.CurrentRow.Cells[5].Value).ToString();
            _dymob = (dataGridView1.CurrentRow.Cells[6].Value).ToString();
            _dyhome = (dataGridView1.CurrentRow.Cells[7].Value).ToString();
            _rulename = (dataGridView1.CurrentRow.Cells[8].Value).ToString();
            _birthday = (dataGridView1.CurrentRow.Cells[9].Value).ToString();
            if (_birthday == "")
            {
                _birthday = null;
            }
        
            _dmdm = (dataGridView1.CurrentRow.Cells[10].Value).ToString();


            object[,] _updatePara = new object[,] { { "dyname", _dyname }, 
                                                    {"dysecure",_dysecure  },
                                                    {"dysfz",_dysfz  },
                                                    {"dyemail",_dyemail  },
                                                    {"dytel",_dytel  },
                                                    {"dymob",_dymob  },
                                                    {"dyhome",_dyhome  },
                                                    {"rulename",_rulename },
                                                    {"birthday",_birthday } ,
                                                    {"dmdm",_dmdm } };
           
            object[,] _wherePara = new object[,] { { "id", "=", _id } };
            cmd.tableName = "insidebase";
            try
            {
                
                cmd.updateRecord(_updatePara, _wherePara);
                MessageBox.Show  ("数据更新成功","更新提示",MessageBoxButtons.OK ,MessageBoxIcon.Asterisk );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                addob();
                fillGr();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addob()
        {
            string  _dyname, _dysecure, _dysfz, _dyemail, _dytel, _dymob, _dyhome, _rulename, _birthday, _dmdm;
         
            _dyname = iname.Text ;
            _dysecure = ipasswd .Text ;
            _dysfz = isfz.Text ;
            _dyemail = imail.Text ;
            _dytel = itel.Text ;
            _dymob = imob.Text ;
            _dyhome = iadd.Text ;  
            _rulename = "3";
            if (rule1.Checked ==true)
            {
            _rulename ="1" ;
            }
            if (rule2.Checked == true)
            {
                _rulename ="2";
            }
            if (rule4.Checked == true)
            {
                _rulename = "4";
            }

            _birthday =ibirthday.Text ;
            if (_birthday == "")
            {
                _birthday = null;
            }

            _dmdm =idm.Text ;

            object[,] insertPara = new object[,] { { "dyname", _dyname }, 
                                                    {"dysecure",_dysecure  },
                                                    {"dysfz",_dysfz  },
                                                    {"dyemail",_dyemail  },
                                                    {"dytel",_dytel  },
                                                    {"dymob",_dymob  },
                                                    {"dyhome",_dyhome  },
                                                    {"rulename",_rulename },
                                                    {"birthday",_birthday } ,
                                                    {"dmdm",_dmdm } };
            cmd.tableName = "insidebase";
            try
            {
                cmd.insertRecord(insertPara);
                msg.Text = "员工信息新增成功";
                initInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败,请核对有无相同员工姓名!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//        数据表名称: InsideBase
//创建时间:2007-3-7 20:47:56
//-----------------------------------------------------
//Create Table InsideBase(
//    ID	int  NOT NULL ,
//    DyName	char(12)  NOT NULL ,
//    Dysecure	char(8)  NOT NULL ,
//    DySFZ	char(18)  NULL ,
//    DyEmail	varchar(50)  NULL ,
//    DyTel	char(11)  NULL ,
//    DyMob	char(11)  NULL ,
//    DyHome	varchar(100)  NULL ,
//    rulename	char(10)  NOT NULL ,
//    Birthday	datetime  NULL ,
//    Dmdm	char(2)  NOT NULL 
//)

//GO
//ALTER TABLE InsideBase ADD  PRIMARY KEY  clustered 
//   ( ID )  ON [PRIMARY]
        private void initInput()
        {
            iname.Text ="";
            ipasswd.Text = "";
            isfz.Text = "";
            imail.Text = "";
            itel.Text = "";
            imob.Text = "";
            iadd.Text = "";
            rule3.Checked = true;
            ibirthday.Text  = "";
            idm.Text = "";
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            cmd.tableName = "insidebase";
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






    }
}