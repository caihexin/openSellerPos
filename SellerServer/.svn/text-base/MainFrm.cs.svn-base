using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MsMq;
using mySql;
using System.Messaging;
using System.Threading;
using System.Diagnostics;
namespace SellerServer
{
    public partial class MainFrm : Form
    {

        private MessageQueue _messageQueue = null;
        //最大并发线程数 
        private static int MAX_WORKER_THREADS = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["MAX_WORKER_THREADS"].ToString());
        //Msmq路径
        private static string MsmqPath = System.Configuration.ConfigurationSettings.AppSettings["MQPath"];
        //等待句柄
        private WaitHandle[] waitHandleArray = new WaitHandle[MAX_WORKER_THREADS];
        //任务类型
        //1. Send Email 2. Send Message  3. Send Email and Message
        private string TaskType = System.Configuration.ConfigurationSettings.AppSettings["TaskType"];

        private string logTag = System.Configuration.ConfigurationSettings.AppSettings["logTag"];


        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];
        private Loging log = new Loging();
        private MySqlDde mycmd;

        private MessageQueue MessQueue
        {
            get
            {

                if (_messageQueue == null)
                {
                    if (MessageQueue.Exists(MsmqPath)) //System.Messaging.MessageQueue.Exists 不适用于远程队列
                    {
                        _messageQueue = new MessageQueue(MsmqPath);
                    }
                    else
                    {
                        _messageQueue = MessageQueue.Create(MsmqPath);
                    }
                }


                return _messageQueue;
            }
        }


        private void mq_ReceiveCompleted( )
        {
            if (!MessageQueue.Exists(MsmqPath))
            {
                MessageQueue.Create(MsmqPath);
                MessageQueue mqTemp = new MessageQueue(MsmqPath);
                mqTemp.SetPermissions("Everyone", MessageQueueAccessRights.FullControl);
            }
            MessageQueue MyQueue = new MessageQueue(MsmqPath);

            MyQueue.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(MsgObject) });
            MyQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);
            MyQueue.BeginReceive();

        }

        private void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            try
            {

                System.Messaging.Message ms = mq.EndReceive(asyncResult.AsyncResult);

                MsgObject obj = (MsgObject)ms.Body;

                string subject = obj.subject;
                string body = obj.body;
                try
                {
                
                    mycmd.ExeMysql(body);

                }
                catch (Exception ex)
                {
                    log.writelog("消息队列插入数据异常//" + body + "//\r\n " + ex.Message, logTag);

                }
              

            }
            catch (Exception ex)
            {
                if (ex.Source != "System.Messaging")
                    WriteSysLog(ex.ToString());
            }
            finally
            {
                GC.Collect();
                mq.BeginReceive();
            }
            return;
        }

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
        private void startListen()
        {
    

            Thread newThread = new Thread(new ThreadStart(mq_ReceiveCompleted));

            newThread.IsBackground = true;
            newThread.Start();

        }




        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                startListen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.button1.Enabled = false;
            this.button2.Enabled = true;


        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            mycmd = new MySqlDde(remotedatabase, tablename, user, passwd);

        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           // mq.stopListen();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    mq.stopListen();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}
            this.Close();
          
        }
    }
}