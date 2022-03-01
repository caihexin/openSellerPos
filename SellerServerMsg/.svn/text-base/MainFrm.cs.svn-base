using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;
using System.Threading;
using System.Diagnostics;
using SellerServer;
namespace SellerServer
{
    public partial class MainFrm : Form
    {
      

        private string logTag = System.Configuration.ConfigurationSettings.AppSettings["logTag"];
        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];
        private string waittime = System.Configuration.ConfigurationSettings.AppSettings["waittime"]; //间隔时间

        private Loging log = new Loging();
        private MySqlDde mycmd;


       

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strMsg"></param>
        private void WriteSysLog(string strMsg)
        {
            EventLog objLog = new EventLog("Application");
            objLog.Source = "信息网络管理系统--消息服务";
            objLog.WriteEntry(strMsg, EventLogEntryType.Error);
        }



        //开始监听工作线程
        private System.Timers.Timer t;
        private void startListen()
        {
            int waitt = int.Parse(waittime);
            t= new System.Timers.Timer(waitt);
            t.Elapsed += new System.Timers.ElapsedEventHandler(workOnline);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Eapsed事件； 



        }

        private void workOnline(object source, System.Timers.ElapsedEventArgs e)
        {

            t.Stop();
            Thread newthread = new Thread(new ParameterizedThreadStart(this.worksendmsg));
            newthread.IsBackground = true;
            newthread.Start();
      

     
        }

        private void worksendmsg(object o)
        {
            DataSet dsl=new DataSet ();
            MySqlDde mylocal = new MySqlDde(remotedatabase, tablename, user, passwd);
            string msgl = "select * from msg order by id";
            try
            {
                dsl = mylocal.executeCmd(msgl);
            }
            catch (Exception ex)
            {
                log.writelog("ExeMsgSelect" + DateTime.Now.ToLongTimeString() + "::\r\n" + dsl + "::\r\n" + ex.Message, logTag);

            }


            if (dsl.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsl.Tables[0].Rows)
                {
                    string cmds="";
                    string dels = "";
                    try
                    {                       
                        cmds = dr.ItemArray[1].ToString();
                        cmds = cmds.Replace("*", "'");
                        mylocal.ExeMysqlTrans(cmds);
          
                        dels= "delete from  msg where id =" + int.Parse(dr.ItemArray[0].ToString());
                        mylocal.ExeMysqlTrans(dels);
                    }
                    catch (Exception ex)
                    {
                        log.writelog("ExeMsgToDataBase/ExeMsgDelDataBase" + DateTime.Now.ToLongTimeString() + "::\r\n" + cmds + "::\r\n" + dels + "::\r\n" + ex.Message, logTag);

                    }
                  
                }
            }
            log.writelog("+++消息数据入库成功+++" + DateTime.Now.ToLongTimeString()  , logTag);
            t.Start();


        }


        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            appStart();

        }


        private void appStart()
        {

            try
            {
                startListen();
            }
            catch (Exception ex)
            {
                log.writelog(DateTime.Now.ToLongTimeString() + ":" + ex.Message, logTag);

            }
            this.button1.Enabled = false;
            this.button2.Enabled = true;


        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            mycmd = new MySqlDde(remotedatabase, tablename, user, passwd);

            appStart();

        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
     
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
  
            this.Close();
          
        }
    }
}