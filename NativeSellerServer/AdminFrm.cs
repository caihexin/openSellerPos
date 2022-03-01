using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;
using System.Text.RegularExpressions;
namespace NativeSeller
{
    public partial class AdminFrm : Form
    {

        private string username; 

        private string  Rule ;

        public AdminFrm(string _user,string _rule )
        {
            
            InitializeComponent();

            username = _user;
            Rule = _rule;

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

        private void 数据库升级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("请确认进行数据库升级，有可能造成数据丢失请警慎", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result== DialogResult.OK)
            {

                DataSet up = new DataSet();
                up.ReadXml("nsupdate.xml");
                string sqlStr = "";
                foreach (DataRow dr in up.Tables[0].Rows)
                {
                    sqlStr = sqlStr + dr[0].ToString() ; 
                }
            
                string[]  qStr =sqlStr.Split(char.Parse("\\"));

                BaseDate bd = new BaseDate();
                MySqlDde myCmd = bd.myCmd;
                try
                {
                    foreach (string _q in qStr)
                    {
                        if (Regex.Match(_q ,"\\w+").Length >0)
                        {
                            myCmd.ExeMysql(_q);
                        }
                    }
                    MessageBox.Show("数据库升级成功", "提醒",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void iC卡消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IcReport icr = new IcReport();
            icr.MdiParent = this;
            icr.Show();
        }

        private void AdminFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void iC卡开卡充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IcAdminFrm ic = new IcAdminFrm();
            ic.MdiParent = this;
            ic.Show();



        }
    }
}