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
    public partial class VipFrm : Form
    {
        public MySqlDde cmd;
        public VipFrm()
        {
            InitializeComponent();
        }

        private void vipFrm_Load(object sender, EventArgs e)
        {

            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            //dataGridView1.AutoGenerateColumns = false;
            fillGr();

        }
        private void fillGr()
        {

            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "vipbase" };
            string[,] _order = new string[,] { { "id", "desc" } };

            dataGridView1.DataSource = cmd.getRecord(_fields, _tables, _order).DefaultView;
            // dataGridView1.Columns[0].ReadOnly = true;
            // dataGridView1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
        private void addvipnumtojf(string tmpvipnum)
        {
            string _vipnum=tmpvipnum  ;
            cmd.tableName = "vipxiaofeijifen";
            object[,] insertPara = new object[,] { 
                                            
                                                { "vipnum", _vipnum   },
                                                { "xfjf", 0   }
                                                            };
            try
            {
                cmd.insertRecord(insertPara);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

//数据表名称: Vipbase
//创建时间:2007-4-10 22:12:58
//-----------------------------------------------------
//Create Table Vipbase(
//    ID	int  NOT NULL ,
//    VipNum	char(5)  NOT NULL ,
//    VipName	char(8)  NULL ,
//    VipSfz	char(18)  NULL ,
//    VipTel	char(11)  NULL ,
//    VipMob	char(11)  NULL ,
//    VipWork	varchar(100)  NULL ,
//    VipEmail	varchar(50)  NULL ,
//    VipHome	varchar(100)  NULL ,
//    VipBirthday	smalldatetime  NULL ,
//    BirthdayPp	char(1)  NULL 
//)

//GO
//ALTER TABLE Vipbase ADD  PRIMARY KEY  clustered 
//   ( VipNum )  ON [PRIMARY]

        private void addvip()
        {
            string _vipnum,_vipname,_vipsfz,_viptel,_vipmob,_vipwork,_vipemail,_viphome,_vipbirthday,_birthdaypp;

            _vipnum = vipnum.Text;
            _vipname = vipname.Text;
            _vipsfz = vipsfz.Text;
            _viptel = viptel.Text;
            _vipmob = vipmob.Text;
            _vipwork = vipwork.Text;
            _vipemail = vipemail.Text;
            _viphome = viphome.Text;
            _vipbirthday = vipbirthday.Text;

            try
            {
                DateTime tmp = DateTime.Parse(_vipbirthday);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生日输入格式不对，请核对!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (vipbirthday.Text.Trim ()  == "")
            {
                _vipbirthday  = null;
            }
            _birthdaypp = "1";

            if (birthdaypp1.Checked ==true)
            {
                _birthdaypp = "1";
            }
            if (birthdaypp2.Checked == true)
            {
                _birthdaypp  = "0";
            }

            cmd.tableName = "vipbase";
            object[,] insertPara = new object[,] { 
                                                { "vipnum", _vipnum },
                                                { "vipname", _vipname }, 
                                                { "vipsfz", _vipsfz  },
                                                { "viptel", _viptel },
                                                { "vipmob", _vipmob }, 
                                                { "vipwork", _vipwork },
                                                { "vipemail", _vipemail },
                                                { "viphome", _viphome  }, 
                                                { "vipbirthday", _vipbirthday  },
                                                { "birthdaypp", _birthdaypp   }
                                                            };
            try
            {
                cmd.insertRecord(insertPara);
                addvipnumtojf(_vipnum ); //将会员号加入到会员积分表中
                msg.Text = "会员信息新增成功";
                initInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败,请核对有无相同会员编号!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void initInput()
        {
            vipnum.Text  = "";
            vipname.Text  = "";
            vipsfz.Text  = "";
            viptel.Text = "";
            vipmob.Text = "";
            vipwork.Text = "";
            vipemail.Text = "";
            viphome.Text = "";
            vipbirthday.Text = "";
            birthdaypp1.Checked = true;
            birthdaypp2.Checked = false;



        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            cmd.tableName = "vipbase";
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

        private void dataGridView1_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            string _vipnum, _vipname, _vipsfz, _viptel, _vipmob, _vipwork, _vipemail, _viphome, _vipbirthday, _birthdaypp;
            _vipnum = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            _vipname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            _vipsfz = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            _viptel = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            _vipmob = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            _vipwork = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            _vipemail = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            _viphome = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            _vipbirthday = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (_vipbirthday == "")
            {
                _vipbirthday = null;
            }
            _birthdaypp = dataGridView1.CurrentRow.Cells[10].Value.ToString();



            object[,] _updatePara = new object[,] { 
                                                { "vipnum", _vipnum },
                                                { "vipname", _vipname }, 
                                                { "vipsfz", _vipsfz  },
                                                { "viptel", _viptel },
                                                { "vipmob", _vipmob }, 
                                                { "vipwork", _vipwork },
                                                { "vipemail", _vipemail },
                                                { "viphome", _viphome  }, 
                                                { "vipbirthday", _vipbirthday  },
                                                { "birthdaypp", _birthdaypp   }
                                                            };

            object[,] _wherePara = new object[,] { { "id", "=", dataGridView1.CurrentRow.Cells[0].Value.ToString() } };
            cmd.tableName = "vipbase";
            try
            {
                cmd.updateRecord(_updatePara, _wherePara);
                MessageBox.Show("数据更新成功", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败"+"\r\n"+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_EditModeChanged(object sender, EventArgs e)
        {

        }


    }
}