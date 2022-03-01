using System;
using System.Collections.Generic;
using System.Text;
using mySql;
using System.Data;
using System.Windows.Forms;
namespace NativeSeller
{
  public   class BaseDate  //操作mysql数据的基本库
    {
      public     MySqlDde myCmd;

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
           
        }



        private void insidebaseTomy()
        {
          


        }
        private void vipTomy()
        {
          

        }
        private void jfTomy()
        {
           



        }

      public void xfXmlImportMsSql(string xfNameString)
      {
           

      }
     



    }
}
