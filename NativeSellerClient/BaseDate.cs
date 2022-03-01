using System;
using System.Collections.Generic;
using System.Text;
using DDE;
using mySql;
using System.Data;
using System.Windows.Forms;
namespace NativeSeller
{
  public   class BaseDate  //操作mysql数据的基本库
    {
      public     MySqlDde myCmd;
      private    Cmdata msCmd;
      public    string _mySqlName, _dataName, _user, _pwd;
      public    string storeroom, portName, printname, printFontValue, logtag;

     
      public void ShowGridData(DataGridView dv, DataTable dt) //显示DataTable 数据在DataGridView中 
      {
          dv.DataSource = dt.DefaultView;


      }

        public void dataImportMySql()//将联机数据与MYSQL同步
        {
            obTomy();
          //  insidebaseTomy();
            vipTomy();
            jfTomy();

        }

        public BaseDate ()
        {
           getMySqlInfo();
           myCmd = new MySqlDde(_mySqlName , _dataName , _user , _pwd );
           
        }
    //取数据库配置信息
      public  void  getMySqlInfo()
      {
          DataSet myInfo = new DataSet();
          myInfo.ReadXml("c:\\info.xml");
          _mySqlName = myInfo.Tables["mysql"].Rows[0]["sqlName"].ToString(); //数据库连接地址
          _dataName = myInfo.Tables["mysql"].Rows[0]["tabname"].ToString(); //库名
          _user = myInfo.Tables["mysql"].Rows[0]["user"].ToString();//数据库用户名
          _pwd = myInfo.Tables["mysql"].Rows[0]["pwd"].ToString(); //密码
          storeroom = myInfo.Tables["admin"].Rows[0]["storeroom"].ToString();  //网点代码
          logtag = myInfo.Tables["admin"].Rows[0]["log"].ToString(); 
          portName = myInfo.Tables["print"].Rows[0]["port"].ToString();   //打印机端口号
          printname = myInfo.Tables["print"].Rows[0]["printname"].ToString();
          printFontValue = myInfo.Tables["print"].Rows[0]["font"].ToString(); 

      }


        private void obTomy()
        {
            msCmd = new Cmdata();
            myCmd.tableName = "ob";
            myCmd.DeleteRecord(null);
                     
            msCmd.dataTable = "ob";
            DataTable msDt = new DataTable();
            msDt = msCmd.showAllRecord("obnamedm,obname,unitprice");
            string _obnamedm;
            string _obname;
            string _unitprice;
            string insertString;
            insertString = "insert ob(obnamedm,obname,unitprice) values";
            int i, j;
            i = msDt.Rows.Count;

            for (j = 0; j < i; j++)
            {
                _obnamedm = msDt.Rows[j].ItemArray[0].ToString();
                _obname = msDt.Rows[j].ItemArray[1].ToString();
                _unitprice = msDt.Rows[j].ItemArray[2].ToString();

                //object[,] insertPara = new object[,] { { "obnamedm", _obnamedm }, { "obname", _obname }, { "unitprice", _unitprice } };
                //myCmd.insertRecord(insertPara);

                insertString += "('"
                                + _obnamedm + "','"
                                + _obname + "','"
                                + _unitprice + "'"
                                + "),";

            }
            insertString = insertString.Substring(0, insertString.Length - 1);
            myCmd.ExeMysql(insertString);

        }



        private void insidebaseTomy()
        {
            msCmd = new Cmdata();
            myCmd.tableName = "insidebase";
            myCmd.DeleteRecord(null);

            msCmd.dataTable = "insidebase";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday,dmdm");
            string _dyname, _dysecure, _dysfz, _dyemail, _dytel, _dymob, _dyhome, _rulename, _birthday, _dmdm;
            string insertString = null;
            insertString = "insert insidebase(dyname,dysecure,dysfz,dyemail,dytel,dymob,dyhome,rulename,birthday,dmdm)  values";
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
                    string _tmpBirth;
                    _birthday = msDt.Rows[j].ItemArray[8].ToString();
                    if (_birthday.Trim() == "")
                    {
                        _tmpBirth = "null";
                    }
                    else
                    {
                        _tmpBirth = "'" + _birthday + "'"; 
                    }

                    _dmdm = msDt.Rows[j].ItemArray[9].ToString();
                    insertString += "('"
                                   + _dyname + "','"
                                   + _dysecure + "','"
                                   + _dysfz + "','"
                                   + _dyemail + "','"
                                   + _dytel + "','"
                                   + _dymob + "','"
                                   + _dyhome + "','"
                                   + _rulename + "',"
                                   + _tmpBirth  + ",'"
                                   + _dmdm
                                   + "') ,";





                }
                insertString = insertString.Substring(0, insertString.Length - 1);
                myCmd.ExeMysql(insertString);


        }
        private void vipTomy()
        {
            msCmd = new Cmdata();
            myCmd.tableName = "vipbase";
            myCmd.DeleteRecord(null);

            msCmd.dataTable = "vipbase";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdayPp");
            string _vipnum, _vipname, _vipsfz, _viptel, _vipmob, _vipwork, _vipemail, _viphome, _vipbirthday, _birthdayPp;
            string insertString = null;
            insertString = "insert vipbase(vipnum,vipname,vipsfz,viptel,vipmob,vipwork,vipemail,viphome,vipbirthday,birthdayPp)  values ";
                               
            int i, j;
            i = msDt.Rows.Count;
            for (j = 0; j < i; j++)
            {
                _vipnum = msDt.Rows[j].ItemArray[0].ToString();
                _vipname = msDt.Rows[j].ItemArray[1].ToString();
                _vipsfz = msDt.Rows[j].ItemArray[2].ToString();
                _viptel = msDt.Rows[j].ItemArray[3].ToString();
                _vipmob = msDt.Rows[j].ItemArray[4].ToString();
                _vipwork = msDt.Rows[j].ItemArray[5].ToString();
                _vipemail = msDt.Rows[j].ItemArray[6].ToString();
                _viphome = msDt.Rows[j].ItemArray[7].ToString();
                string tmp;
                if (msDt.Rows[j].ItemArray[8].ToString() == "")
                {
                    tmp = "null";
                }
                else
                {
                    tmp = "'" + msDt.Rows[j].ItemArray[8].ToString() + "'";
                }

                _vipbirthday = msDt.Rows[j].ItemArray[8].ToString();
                _birthdayPp = msDt.Rows[j].ItemArray[9].ToString();
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

        }
        private void jfTomy()
        {
            msCmd = new Cmdata();
            myCmd.tableName = "vipxiaofeijifen";
            myCmd.DeleteRecord(null);

            msCmd.dataTable = "vipxiaofeijifen";
            DataTable msDt = new DataTable();

            msDt = msCmd.showAllRecord("vipnum,xfjf");
            string _vipnum, _xfjf;
            string insertString = null;
            insertString = "insert vipxiaofeijifen(vipnum,xfjf) values ";
                              

            int i, j;
            i = msDt.Rows.Count;
            for (j = 0; j < i; j++)
            {
                _vipnum = msDt.Rows[j].ItemArray[0].ToString();
                _xfjf = msDt.Rows[j].ItemArray[1].ToString();

                insertString += "('"
                               + _vipnum + "','"
                               + _xfjf
                               + "'),";


            }
            insertString = insertString.Substring(0, insertString.Length - 1);
            myCmd.ExeMysql(insertString);
        }

        public  void xfDataExportXml(string xfNameString)
        {

            
                string[] fields = new string[]
            {
            "vipnum", "xfdz", "obnamedm", "unitprice", "xfnum", "xfsum", "dmdm", "obname"
            };
                string[] tables = new string[] { "vipxiaofei" };
                DataTable xf = myCmd.getRecord(fields, tables);
                DataSet xfDs = new DataSet();
                xfDs.Tables.Add(xf);
                xfDs.WriteXml(xfNameString);
            
               myCmd.tableName  = "vipxiaofei";

               myCmd.DeleteRecord(null);



        }

      public void xfXmlImportMsSql(string xfNameString)
      {
             msCmd = new Cmdata();
            DataSet xfDs = new DataSet();
            xfDs.ReadXml( xfNameString);
            msCmd.updateMultRecord(xfDs.Tables[0], "select   vipnum, xfdz, obnamedm, unitprice, xfnum, xfsum, dmdm,obname from vipxiaofei where 1<0");


      }
     



    }
}
