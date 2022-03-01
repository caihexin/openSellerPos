using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MsMq;
using System.Threading;
using mySql;
namespace SellerClient
{
    public partial class SellerClientFrm : Form
    {
        private MsgMq mq =new MsgMq();
        private MsgObject mo = new MsgObject();


        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];
        private MySqlDde mycmd;
        public SellerClientFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mo.subject = "Seller";
            mo.body =textBox1.Text.Trim();
            try
            {
                mq.SendMQ(mo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

 
        private void button2_Click(object sender, EventArgs e)
        {
      
            //TimerCallback timerDelegate = new TimerCallback(workOnline);
            //System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, "", 1000, 60000);

            System.Timers.Timer t = new System.Timers.Timer(60000);//实例化Timer类，设置间隔时间为10000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(workOnline);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件； 




        }


        public void workOnline(object source, System.Timers.ElapsedEventArgs e)
        {
            mycmd = new MySqlDde(remotedatabase, tablename, user, passwd);

            if (mycmd.getconnstate())
            {

                Thread newthread = new Thread(new ParameterizedThreadStart(this.worksendmsg));
                newthread.Start();
        
            }
         


        }

        private void worksendmsg(object o )
        {

           // MessageBox.Show("呵呵，成功！");
            MySqlDde  mylocal = new MySqlDde("localhost", tablename, user, passwd);
            string msgl = "select * from msg order by id";
            DataSet dsl= mylocal.executeCmd(msgl);
            MySqlDde myremote = new MySqlDde(remotedatabase, tablename, user, passwd);

            if (dsl.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsl.Tables[0].Rows)
                {
                    string msgr = "insert msg(content) values('" + dr.ItemArray[1].ToString() + "')";
                    try
                    {
                        myremote.ExeProcedure(msgr);
                        string dels = "delete from  msg where id =" + int.Parse(dr.ItemArray[0].ToString());
                        mylocal.ExeMysql(dels);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            






        }




    }
}