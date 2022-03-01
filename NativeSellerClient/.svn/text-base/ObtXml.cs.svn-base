using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DDE;
//using MySQLDriverCS;
using mySql;
namespace NativeSeller
{
    public partial class ObtXml : Form
    {
        Cmdata cmd = new Cmdata();

        public ObtXml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               DataSet dt = new DataSet();
          
              dt = cmd.GetAllDataSet("*", "ob");
              dt.WriteXml("ob.xml");
              dt.Clear();
              dt = cmd.GetAllDataSet("*", "vipjfview");
              dt.WriteXml("vipjfview.xml");
              dt.Clear();
              MessageBox.Show("后台数据同步成功","提示",MessageBoxButtons.OK  , MessageBoxIcon.Information);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt.ReadXml("ob.xml", XmlReadMode.Auto  );
            dataGridView1.DataSource = dt.Tables["ob"].DefaultView ;


        }

        private void button3_Click(object sender, EventArgs e)
        {
      

            MySqlDde cmd = new MySqlDde("localhost","crm_dbo","root","");
            string[] fields = new string[] { "obnamedm", "obname", "unitprice" };
            string[] tables = new string[] { "ob" };

           dataGridView1.DataSource = cmd.getRecord(fields ,tables );
 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            string[] fields = new string[] { "obnamedm", "obname", "unitprice" };
            string[] tables = new string[] { "ob" };
            object[,] wherePara = new object[,] { { "obnamedm", "=", "10001" } };
            dataGridView1.DataSource = cmd.getwhereRecord (fields ,tables ,wherePara );
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //    new object[,] { { "SettingID", SettingID }, { "SettingValue", Value } }
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
          //  cmd.ExeMysql("insert ob(obnamedm,obname,unitprice) values('10003','t2','23.5') ");
            cmd.tableName = "ob";
            object[,] insertPara = new object[,] { { "obnamedm", "10006" }, { "obname", "t6" }, { "unitprice", "28.9" } };
            cmd.insertRecord(insertPara );

           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            object[,] updatePara = new object[,] { { "unitprice", "22" } };
            object[,] wherePara = new object[,] { { "obnamedm", "=", "10002" } };
            cmd.tableName = "ob";
            cmd.updateRecord(updatePara, wherePara);


        }

        private void button7_Click(object sender, EventArgs e)
        {
           // new object[,] { { "SettingID", "=", SettingID } }
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            cmd.tableName = "ob";
            object[,] delPara = new object[,] { { "obnamedm", "=", "10001" } };

            cmd.DeleteRecord(delPara);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //insidebaseTomy();
            insideTomy();
        }

        private void obTomy()
        {
            MySqlDde myCmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            myCmd.tableName = "ob";
            myCmd.DeleteRecord(null);

            Cmdata msCmd = new Cmdata();
            msCmd.dataTable = "ob";
            DataTable msDt = new DataTable();
            msDt = msCmd.showAllRecord("obnamedm,obname,unitprice");
            //  dataGridView1.DataSource = msDt;
            string _obnamedm;
            string _obname;
            string _unitprice;
            int i, j;
            i = msDt.Rows.Count;
            for (j = 0; j < i; j++)
            {
                _obnamedm = msDt.Rows[j].ItemArray[0].ToString();
                _obname = msDt.Rows[j].ItemArray[1].ToString();
                _unitprice = msDt.Rows[j].ItemArray[2].ToString();
                object[,] insertPara = new object[,] { { "obnamedm", _obnamedm }, { "obname", _obname }, { "unitprice", _unitprice } };
                myCmd.insertRecord(insertPara);

            }
            MessageBox.Show("数据导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void insidebaseTomy()
        {
               //`ID` INT(10) NOT NULL AUTO_INCREMENT,
              //`DyName` CHAR(12) NOT NULL,
              //`Dysecure` CHAR(8) NOT NULL,
              //`DySFZ` CHAR(18) NULL,
              //`DyEmail` VARCHAR(50) NULL,
              //`DyTel` CHAR(11) NULL,
              //`DyMob` CHAR(11) NULL,
              //`DyHome` VARCHAR(100) NULL,
              //`rulename` CHAR(10) NOT NULL,
              //`Birthday` DATETIME NULL,
              //`Dmdm` CHAR(2) NOT NULL,
            MySqlDde myCmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            myCmd.tableName = "insidebase";
            myCmd.DeleteRecord(null);

            Cmdata msCmd = new Cmdata();
            msCmd.dataTable = "insidebase";
            DataTable msDt = new DataTable();
            msDt = msCmd.showAllRecord("dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday,dmdm");
            //  dataGridView1.DataSource = msDt;
            string _dyname,_dysecure,_dysfz,_dyemail,_dytel,_dymob,_dyhome,_rulename,_dmdm;
          //  DateTime _birthday;
            try
            {

                int i, j;
                i = msDt.Rows.Count;
                for (j = 0; j < i; j++)
                {
                    _dyname = msDt.Rows[j].ItemArray[0].ToString();
                    _dysecure = msDt.Rows[j].ItemArray[1].ToString();
                    _dysfz = msDt.Rows[j].ItemArray[2].ToString();
                    _dyemail = msDt.Rows[j].ItemArray[3].ToString();
                    _dytel = msDt.Rows[j].ItemArray[4].ToString();
                    _dymob = msDt.Rows[j].ItemArray[5].ToString();
                    _dyhome = msDt.Rows[j].ItemArray[6].ToString();
                    _rulename = msDt.Rows[j].ItemArray[7].ToString();
                  //  _birthday =  msDt.Rows[j].ItemArray[8].ToString() ;
                   // _birthday =DateTime.Now  ;
                    _dmdm = msDt.Rows[j].ItemArray[9].ToString();

                    object[,] insertPara = new object[,]
                
                { 
                     { "dyname",_dyname },
                    { "dysecure", _dysecure  }, 
                     { "dysfz", _dysfz }, 
                     { "dyemail", _dyemail  }, 
                     { "dytel", _dytel  }, 
                     { "dymob", _dymob  }, 
                     { "dyhome", _dyhome  }, 
                     { "rulename", _rulename  }, 
                  //   { "birthdya", _birthday  }, 
                     { "dmdm", _dmdm  }
                 };
                    myCmd.insertRecord(insertPara);
              
                }
                MessageBox.Show("数据导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
         

            }
    
        }
        private void insideTomy()
        {

            MySqlDde myCmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            myCmd.tableName = "insidebase";
            myCmd.DeleteRecord(null);

            Cmdata msCmd = new Cmdata();
            msCmd.dataTable = "insidebase";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday,dmdm");
            string _dyname, _dysecure, _dysfz, _dyemail, _dytel, _dymob, _dyhome, _rulename,_birthday, _dmdm;
            string insertString =null ;
            insertString = "insert insidebase(dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday,dmdm)  values";
            try
            {

                int i, j;
                i = msDt.Rows.Count;
                for (j = 0; j < i; j++)
                {
                    _dyname = msDt.Rows[j].ItemArray[0].ToString();
                    _dysecure = msDt.Rows[j].ItemArray[1].ToString();
                    _dysfz = msDt.Rows[j].ItemArray[2].ToString();
                    _dyemail = msDt.Rows[j].ItemArray[3].ToString();
                    _dytel = msDt.Rows[j].ItemArray[4].ToString();
                    _dymob = msDt.Rows[j].ItemArray[5].ToString();
                    _dyhome = msDt.Rows[j].ItemArray[6].ToString();
                    _rulename = msDt.Rows[j].ItemArray[7].ToString();
                    _birthday = msDt.Rows[j].ItemArray[8].ToString();
                   _dmdm = msDt.Rows[j].ItemArray[9].ToString();
                   insertString += "('"
                                  + _dyname + "','"
                                  + _dysecure + "','"
                                  + _dysfz + "','"
                                  + _dyemail + "','"
                                  + _dytel + "','"
                                  + _dymob + "','"
                                  + _dyhome + "','"
                                  + _rulename + "','"
                                  + _birthday + "','"
                                  + _dmdm 
                                  + "') ,";
                    
                                    
                
             

                }
               insertString = insertString.Substring(0, insertString.Length - 1);
               myCmd.ExeMysql(insertString);
                MessageBox.Show("数据导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }

        }

        private void vipTomy()
        {
            //            CREATE TABLE `Crm_dbo`.`Vipbase` (
            //  `ID` INT(10) NOT NULL,
            //  `VipNum` CHAR(5) NOT NULL,
            //  `VipName` CHAR(8) NULL,
            //  `VipSfz` CHAR(18) NULL,
            //  `VipTel` CHAR(11) NULL,
            //  `VipMob` CHAR(11) NULL,
            //  `VipWork` VARCHAR(100) NULL,
            //  `VipEmail` VARCHAR(50) NULL,
            //  `VipHome` VARCHAR(100) NULL,
            //  `VipBirthday` DATETIME NULL,
            //  `BirthdayPp` CHAR(4) NULL,
            //  PRIMARY KEY (`VipNum`)
            //)
            MySqlDde myCmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            myCmd.tableName = "vipbase";
            myCmd.DeleteRecord(null);

            Cmdata msCmd = new Cmdata();
            msCmd.dataTable = "vipbase";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdayPp");
            string _vipnum, _vipname, _vipsfz, _viptel, _vipmob, _vipwork, _vipemail, _viphome, _vipbirthday, _birthdayPp;
            string insertString = null;
            insertString = "insert vipbase(vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdayPp)  values";
            try
            {

                int i, j;
                i = msDt.Rows.Count;
                for (j = 0; j < i; j++)
                {
                    _vipnum  = msDt.Rows[j].ItemArray[0].ToString();
                    _vipname  = msDt.Rows[j].ItemArray[1].ToString();
                    _vipsfz  = msDt.Rows[j].ItemArray[2].ToString();
                    _viptel  = msDt.Rows[j].ItemArray[3].ToString();
                    _vipmob  = msDt.Rows[j].ItemArray[4].ToString();
                    _vipwork  = msDt.Rows[j].ItemArray[5].ToString();
                    _vipemail  = msDt.Rows[j].ItemArray[6].ToString();
                    _viphome = msDt.Rows[j].ItemArray[7].ToString();
                      string tmp ;
                       if  (msDt.Rows[j].ItemArray[8].ToString()== "") 
                    {  
                           tmp = "null";
                       }
                       else
                       {
                           tmp = "'" + msDt.Rows[j].ItemArray[8].ToString() + "'";
                       }
                       
                    _vipbirthday  = msDt.Rows[j].ItemArray[8].ToString();
                    _birthdayPp  = msDt.Rows[j].ItemArray[9].ToString();
                    //insertString = "insert vipbase(vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdayPp)  "
                    //               + "values('"
                    //               + _vipnum  + "','"
                    //               + _vipname  + "','"
                    //               + _vipsfz  + "','"
                    //               + _viptel  + "','"
                    //               + _vipmob  + "','"
                    //               + _vipwork  + "','"
                    //               + _vipemail  + "','"
                    //               + _viphome   + "',"
                    //               + tmp   + ",'"
                    //               + _birthdayPp 
                    //               + "')";

                    insertString +="('"
                             + _vipnum + "','"
                             + _vipname + "','"
                             + _vipsfz + "','"
                             + _viptel + "','"
                             + _vipmob + "','"
                             + _vipwork + "','"
                             + _vipemail + "','"
                             + _viphome + "',"
                             + tmp + ",'"
                             + _birthdayPp
                             + "'),";

                    

                }

                insertString = insertString.Substring(0, insertString.Length - 1);

                myCmd.ExeMysql(insertString);
                MessageBox.Show("数据导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vipTomy();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                insidebaseTomy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            jfTomy();
        }
        private void jfTomy()
        {
            MySqlDde myCmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            myCmd.tableName = "vipxiaofeijifen";
            myCmd.DeleteRecord(null);

            Cmdata msCmd = new Cmdata();
            msCmd.dataTable = "vipxiaofeijifen";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("vipnum,xfjf");
            string _vipnum, _xfjf;
            string insertString = null;
            insertString = "insert vipxiaofeijifen(vipnum,xfjf) values ";
            try
            {

                int i, j;
                i = msDt.Rows.Count;
                for (j = 0; j < i; j++)
                {
                    _vipnum = msDt.Rows[j].ItemArray[0].ToString();
                    _xfjf = msDt.Rows[j].ItemArray[1].ToString();
                                      
                    insertString += "('"
                                   + _vipnum + "','"
                                   + _xfjf
                                   + "') ,";




                }

                insertString = insertString.Substring(0, insertString.Length - 1);

                myCmd.ExeMysql(insertString);
                MessageBox.Show("数据导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataSet xfDs = new DataSet();
            xfDs.ReadXml("xf.xml");

            if (cmd.updateMultRecord(xfDs.Tables[0], "select   vipnum, xfdz, obnamedm, unitprice, xfnum, xfsum, dmdm,obname from vipxiaofei where 1<0"))
            {


                MessageBox.Show("数据导入成功!","提示",MessageBoxButtons.OK ,MessageBoxIcon.Information );

            }

        }

        private void ObtXml_Load(object sender, EventArgs e)
        {

        }

    }
}