using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using System.Threading;
using mySql;
namespace MsMq
{
    public class MsgMq
    {
        private MessageQueue _messageQueue = null;
        //最大并发线程数 
        private static int MAX_WORKER_THREADS = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["MAX_WORKER_THREADS"].ToString());
        //Msmq路径
        private static string MsmqPath = System.Configuration.ConfigurationSettings.AppSettings["MQPath"];
        //等待句柄
        public WaitHandle[] waitHandleArray = new WaitHandle[MAX_WORKER_THREADS];
        //任务类型
        //1. Send Email 2. Send Message  3. Send Email and Message
        private string TaskType = System.Configuration.ConfigurationSettings.AppSettings["TaskType"];

        private string logTag = System.Configuration.ConfigurationSettings.AppSettings["logTag"];


        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];
        private  Loging log = new Loging();
       // private MySqlDde mycmd;


        public MsgMq()
        {
           // mycmd = new MySqlDde(remotedatabase, tablename, user, passwd);
        }


        public MessageQueue MessQueue
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

        #region Private Method

        private void mq_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e)
        {
            MessageQueue mqq = (MessageQueue)sender;
            System.Messaging.Message m = mqq.EndReceive(e.AsyncResult);
           // m.Recoverable = true;
            m.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(MsgObject) });
            MsgObject obj = (MsgObject)m.Body;
        
            string subject = obj.subject;
            string body = obj.body;
         
            switch (TaskType)
            {
                
                case "1":
                    
                    

                    try
                    {
                        //log.writelog(body, logTag);
                       // mycmd.ExeMysql(body);

                    }
                    catch (Exception ex)
                    {
                        log.writelog("消息队列插入数据异常//"+body+"//\r\n " + ex.Message, logTag);

                    }


                    break;
                //Message
                case "2":
                  
                    break;
                //Email and Message        
                case "3":
               
                    break;
                default:
                    break;

            }
            mqq.BeginReceive();

        }

        #endregion



        #region Public Method

        //一个将对象发送到队列的方法,这里发送的是对象
        public void SendMQ(object arr)
        {


            Message mm = new Message(arr);
            mm.Recoverable = true;
            mm.Priority = MessagePriority.High;
            MessageQueue mq = new MessageQueue(MsmqPath);
            mq.Send(mm);
      
        }

        //同步接受队列内容的方法
        public void ReceiveFromMQ()
        {
                 Message ms = new Message();
                 ms.Recoverable = true;//防止系统重启或异常，保留消息

        
                ms = MessQueue.Receive(new TimeSpan(0, 0, 5));
                if (ms != null)
                {
                    ms.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                    //AppLog.log.Info((string)ms.Body);
                }
       
    


        }

        //开始监听工作线程
        public void startListen()
        {
            MessQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(mq_ReceiveCompleted);

            //异步方式，并发

            for (int i = 0; i < MAX_WORKER_THREADS; i++)
            {
                // Begin asynchronous operations.
                waitHandleArray[i] = MessQueue.BeginReceive().AsyncWaitHandle;
            }

      

            return;

        }


        //停止监听工作线程
        public void stopListen()
        {

            for (int i = 0; i < waitHandleArray.Length; i++)
            {

             
                    waitHandleArray[i].Close();
             
            }

                WaitHandle.WaitAll(waitHandleArray, 1000, false);
        

        }

        #endregion


    }
}
