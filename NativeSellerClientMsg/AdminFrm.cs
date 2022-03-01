using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;
using System.Text.RegularExpressions;
using System.Xml;
namespace NativeSeller
{
    public partial class AdminFrm : Form
    {

        private string username; 
        private string Rule ;
        private string storeroomdm;

        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];
        private string tablename = System.Configuration.ConfigurationSettings.AppSettings["tablename"];
        private string user = System.Configuration.ConfigurationSettings.AppSettings["username"];
        private string passwd = System.Configuration.ConfigurationSettings.AppSettings["passwd"];

        private string logtag = System.Configuration.ConfigurationSettings.AppSettings["logTag"];
        private string uptime = System.Configuration.ConfigurationSettings.AppSettings["uptime"];

        private Loging log = new Loging();
        private SellerConfig conf;
        public AdminFrm(string _user, string _rule, string _storeroomdm)
        {
            
            InitializeComponent();

            username = _user;
            Rule = _rule;
            storeroomdm = _storeroomdm;

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Insidebasefrm fr = new Insidebasefrm();
            fr.Show();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Report fr = new Report();
            fr.Show();
        }

        private void adminFrm_Load(object sender, EventArgs e)
        {
            //收银端不允许入库
            //商品入库ToolStripMenuItem.Visible = false;

            if ((Rule == "3"  )||(Rule=="1"))
            {
                //MessageBox.Show("你没有权限，请重新登录", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                //return;

                员工资料ToolStripMenuItem.Visible = false;
                商品入库ToolStripMenuItem.Visible = false;
                数据导入导出工具ToolStripMenuItem.Visible = false;
                数据库升级ToolStripMenuItem.Visible = false;



            }
            //置入库标记，即一天只能入库一次
            conf = new SellerConfig();
            //取实时配制文件内更新时间
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='uptime']");
            XmlElement ele = (XmlElement)node;
            uptime = ele.GetAttribute("value");

                 

            if ( uptime == DateTime.Today.ToString("yyyy-MM-dd"))
            {

                同步ToolStripMenuItem.Visible = false;



            }



           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JfFrm fr = new JfFrm();
           // fr.MdiParent = this;
            fr.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoreFrm sf = new StoreFrm();
            sf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VipFrm vf = new VipFrm();

            vf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Obfrm of = new Obfrm();
            of.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TodayBirthdayfrm tb = new TodayBirthdayfrm();
            tb.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            InExport inex = new InExport();
            inex.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RebatesFrm rfrm = new RebatesFrm();
            rfrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InObStoreFrm sfrm = new InObStoreFrm(Rule);
            sfrm.Show();




        }

        private void 网点信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreFrm sf = new StoreFrm();
            sf.MdiParent = this;
            sf.Show();
        }

        private void 员工资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insidebasefrm fr = new Insidebasefrm();
            fr.MdiParent = this;
            fr.Show();
        }

        private void 商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Obfrm of = new Obfrm();
            of.MdiParent = this;
            of.Show();
        }

        private void 商品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InObStoreFrm sfrm = new InObStoreFrm(Rule);
            sfrm.MdiParent = this;
            sfrm.Show();

        }

        private void 会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VipFrm vf = new VipFrm();
            vf.MdiParent = this;
            vf.Show();
        }

        private void 会员积分管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JfFrm fr = new JfFrm();
            fr.MdiParent = this;
            fr.Show();
        }

        private void 会员服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodayBirthdayfrm tb = new TodayBirthdayfrm();
            tb.MdiParent = this;
            tb.Show();

        }

        private void 折扣报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RebatesFrm rfrm = new RebatesFrm();
            rfrm.MdiParent = this;
            rfrm.Show();
        }

        private void 销售报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report fr = new Report();
            fr.MdiParent = this;
            fr.Show();
        }

        private void 数据导入导出工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InExport inex = new InExport();
            inex.MdiParent = this;

            inex.Show();
        }

        private void 库房报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreRptFrm srf = new StoreRptFrm();
            srf.MdiParent = this;
            srf.Show();
        }

        private void 订货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Orderfrm of = new Orderfrm( username );
            of.MdiParent = this;
            of.Show();
        }

        private void 订单报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdFrm od = new OdFrm();
            od.MdiParent = this;
            od.Show();
        }

        private void 会员消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VipXfList xfl = new VipXfList();
            xfl.MdiParent = this;
            xfl.Show();
        }
        
        string pwd;
        private void 数据库升级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("请确认进行数据库升级，有可能造成数据丢失请警慎", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result== DialogResult.OK)
            {

                if (InputBox.Show("提示", "请输入密码", true, ref pwd))
                {
                    string pwdtime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                    if (pwd == pwdtime)
                    {
                        try
                        {
                            DataSet up = new DataSet();
                            up.ReadXml("nsupdate.xml");
                            string sqlStr = "";
                            foreach (DataRow dr in up.Tables[0].Rows)
                            {
                                sqlStr = sqlStr + dr[0].ToString();
                            }

                            string[] qStr = sqlStr.Split(char.Parse("\\"));

                            BaseDate bd = new BaseDate();
                            MySqlDde myCmd = bd.myCmd;

                            foreach (string _q in qStr)
                            {
                                if (Regex.Match(_q, "\\w+").Length > 0)
                                {
                                    myCmd.ExeMysql(_q);
                                }
                            }
                            MessageBox.Show("数据库升级成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                            log.writelog("数据库升级异常" + ex.Message, logtag);
                        }

                    }

                    else
                    {
                        log.writelog("密码错误" , logtag);

                    }



                }


               
            }
        }

        private void iC卡消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IcReport icr = new IcReport();
            icr.MdiParent = this;
            icr.Show();
        }

        private void 同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conf.uptag == false)
            {
                log.writelog(DateTime.Today.ToString()+"已完成入库！拒绝", logtag);
                return;
            }
            string obs = "select *  from instore  where  date(intime) = '" + DateTime.Today.ToString("yyyy-MM-dd")
                        + "' and storeDm='" + storeroomdm + "'";

            MySqlDde myCmd = new MySqlDde(remotedatabase, tablename,user,passwd);
            DataSet ods = myCmd.executeCmd(obs);
            if (ods.Tables[0].Rows.Count == 0)
                return;

            log.writelog(DateTime.Today.ToString() + "入库商品记录数：" + ods.Tables[0].Rows.Count.ToString(), logtag);




            MySqlDde myCmdlocal = new MySqlDde("localhost", tablename, user, passwd);


            foreach (DataRow dr in ods.Tables[0].Rows)
            {
               
                string _storedm = dr.ItemArray[1].ToString ();
                string _obNameDm = dr.ItemArray[2].ToString();
                string _num = dr.ItemArray[3].ToString();
                string _inTime = DateTime.Now.ToString();

                StringBuilder insertroomstr = new StringBuilder();
                insertroomstr.Append("call instoretoroom (");
                insertroomstr.Append("'" + _storedm + "',");
                insertroomstr.Append("'" + _obNameDm + "',");
                insertroomstr.Append("'" + _num + "',");
                insertroomstr.Append("'" + _inTime + "'");
                insertroomstr.Append(")");
                try
                {
                    myCmdlocal.ExeProcedure(insertroomstr.ToString());
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.writelog("同步主机商品入库异常" + ex.Message, logtag);
                }
            }
            //更新成功入库标识时间
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.ExecutablePath + ".config");
                XmlNode node = doc.SelectSingleNode(@"//add[@key='uptime']");
                XmlElement ele = (XmlElement)node;
                ele.SetAttribute("value", DateTime.Today.ToString("yyyy-MM-dd"));
                ele.Attributes["value"].ToString();
                doc.Save(Application.ExecutablePath + ".config");
                //置成功入库
                conf.uptag = false;
                MessageBox.Show("入库成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.writelog("app.conf配置" + ex.Message, logtag);


            }

         
        }





    }
}