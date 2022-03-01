//11-28日更新
//2009-7-31更新加折扣功能
//2009-11-10 更新增加厨房打印功能 PrintCfDoc()
//2009-11-17 增加巴台打印功能 printBtDoc()
//2009-11-18 在info.xml 增加<printNum>X</printNum> X表示前台打印的数量
//2009-11-24 在info.xml 增加<unitPrice>X</unitprice> X为0 不能修改商品单价，X为1可以修改商品单价
//<printname>XXX</printname> 如果XXX为空即直接打印并口打印机，而非空即打印到WINDOWS打印机上
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using MySQLDriverCS;
using mySql;
//using SecurePass;
using System.Diagnostics;
using System.Xml;
//using MsMq;

namespace NativeSeller
{
    public partial class SaleServer : Form
    {

        static MySQLConnection conn;
        static MySqlDde sellerCmd;
        static DataTable salesMoney;
        static DataRow Row;
        static DataSet infoDs;
        public string username, rule, dmname;
        private string storeroomdm;
        static DataTable obTd;
        private string portName, printName, printFontValue, cfPrintName, cfView, btPrintName, btView, unitP, icTag;//unitP 判断是否可以更改商品单价

        private Double[] rebates; //折扣值数组
        private int rebateTime;   //此购物条目的ID

        private string logtag;
        private Loging log = new Loging();
        private string stringToPrintCf, stringToPrintBt, stringToPrintXf;
        private string remotedatabase = System.Configuration.ConfigurationSettings.AppSettings["remotedatabase"];

        //private MsgMq mq = new MsgMq(); //消息对列
        //private MsgObject mObject = new MsgObject();//消息对象

        public struct prvShops
        {
            public string _vipnum;
            public string _xfdz;
            public DataTable shop;
            public string _jf;
            public double[] rebate;
        }
        private static prvShops _shops;

        public SaleServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (! DDE.baseData.Ptag)
            //{
            //    SPass PassTag = new SPass();
            //    if (PassTag.SetPass("c:\\info.xml"))
            //    {
            //        DDE.baseData.Ptag = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("请合法使用此系统!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return ;

            //    }

            //}//验证程序是否合法
            //初始化

            try
            {
                BaseDate baseDt = new BaseDate();


                conn = new MySQLConnection(new MySQLConnectionString(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd).AsString);

                sellerCmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "初始化失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                infoDs = new DataSet();
                infoDs.ReadXml("c:\\info.xml");
                portName = infoDs.Tables["print"].Rows[0]["port"].ToString();
                printName = infoDs.Tables["print"].Rows[0]["printname"].ToString();
                printFontValue = infoDs.Tables["print"].Rows[0]["font"].ToString();
                storeroomdm = infoDs.Tables["admin"].Rows[0]["storeroom"].ToString();
                icTag = infoDs.Tables["admin"].Rows[0]["ic"].ToString();//读取IC卡功能标识
                unitP = infoDs.Tables["admin"].Rows[0]["unitPrice"].ToString(); //读取商品代码修改标识
                logtag = infoDs.Tables["admin"].Rows[0]["log"].ToString();
                cfPrintName = infoDs.Tables["print"].Rows[0]["cfprintname"].ToString();
                cfView = infoDs.Tables["print"].Rows[0]["cfView"].ToString();
                btPrintName = infoDs.Tables["print"].Rows[0]["btprintname"].ToString();
                btView = infoDs.Tables["print"].Rows[0]["btView"].ToString();

                //判断商品代码能否修改
                if (unitP == "1")
                    textBox6.ReadOnly = false;
                //判断是否使用厨房打印
                if (cfView == "0")
                    checkBox3.Visible = false;
                //判断是否使用巴台打印
                if (btView == "0")
                    checkBox4.Visible = false;
                //判断是否使用IC卡功能
                if (icTag == "0")
                    button10.Visible = false;





            }
            catch (Exception ex)
            {
                MessageBox.Show("打印配置信息有误，请核对" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //登录系统 
            string sqlString = "select dyname,rulename,dmdm from insidebase where dyname = @dyname and dysecure=@dysecure ";

            MySQLCommand mycom = new MySQLCommand(sqlString, conn);
            MySQLParameter[] sqlparam = new MySQLParameter[2];
            sqlparam[0] = new MySQLParameter("@dyname", DbType.String);
            sqlparam[0].Value = textBox1.Text.Trim();
            sqlparam[1] = new MySQLParameter("@dysecure", DbType.String);
            sqlparam[1].Value = textBox2.Text.Trim();
            foreach (MySQLParameter Param in sqlparam)
            {
                mycom.Parameters.Add(Param);
            }
            IDataReader Dr;
            try
            {
                conn.Open();
                Dr = mycom.ExecuteReader();
                while (Dr.Read())
                {
                    username = Dr.GetString(0);
                    rule = Dr.GetString(1);
                    dmname = Dr.GetString(2);
                    this.DialogResult = DialogResult.OK;


                }

                if (username == null || rule == null)
                {
                    MessageBox.Show(" 密码有误，请重新输入用户名和密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // this.DialogResult = DialogResult.Cancel;
                    return;
                }

                Dr.Close();
                conn.Close();





            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接异常\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            if (rule != "2")
            {
                //button13.Visible = false;
                button15.Visible = false;
                button16.Enabled = false;
            }
            else
            {
                //button13.Visible = true;
                button15.Visible = true;
                button16.Enabled = true;
            }


            fillCombol();
            fillGv(dataGridView2, getOb());


            label11.Text = dmname;
            label12.Text = username;
            splitContainer1.Panel1.Hide();
            splitContainer1.Panel1Collapsed = true;

            splitContainer1.Panel2.Show();
            textBox1.Text = null;
            textBox2.Text = null;
            CreatDs();
            textBox3.Focus();



            this.Close();

        }



        private void SellerSale_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            splitContainer1.Panel2.Hide();
            splitContainer1.Panel2Collapsed = true;
            textBox4.ReadOnly = true;
            textBox1.Focus();

            string xmlpath = "c:\\info.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);
            XmlNamespaceManager xnm = new XmlNamespaceManager(xmldoc.NameTable);
            XmlNode node = xmldoc.SelectSingleNode("/vipdataset/mysql/sqlName", xnm);
            //MessageBox.Show(node.InnerText);
            if (node.InnerText == "mfd.meibu.com")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

            //mObject.subject = "Seller"; //定议消息主体




        }

        private void button2_Click(object sender, EventArgs e)
        {
            username = null; rule = null; dmname = null;
            splitContainer1.Panel1.Show();
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2.Hide();
            textBox1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            username = null; rule = null; dmname = null;
            // DDE.baseData.Ptag = false;
            this.Close();


        }



        private void CreatDs()
        {
            salesMoney = new DataTable();
            DataColumn column0 = new DataColumn("id", typeof(System.Int32));
            column0.AutoIncrement = true;
            salesMoney.Columns.Add(column0);
            DataColumn column1 = new DataColumn("vipnum", typeof(System.String));
            salesMoney.Columns.Add(column1);
            DataColumn column2 = new DataColumn("xfdz", typeof(System.String));
            salesMoney.Columns.Add(column2);
            DataColumn column3 = new DataColumn("obnamedm", typeof(System.String));
            salesMoney.Columns.Add(column3);
            DataColumn column4 = new DataColumn("unitprice", typeof(System.Double));
            salesMoney.Columns.Add(column4);
            DataColumn column5 = new DataColumn("xfnum", typeof(System.String));
            salesMoney.Columns.Add(column5);
            DataColumn column6 = new DataColumn("xfsum", typeof(System.Double));
            salesMoney.Columns.Add(column6);
            DataColumn column7 = new DataColumn("dmdm", typeof(System.String));
            salesMoney.Columns.Add(column7);
            DataColumn column8 = new DataColumn("obname", typeof(System.String));
            salesMoney.Columns.Add(column8);


            dataGridView1.DataSource = salesMoney.DefaultView;
            rebates = new double[50];
            rebateTime = 0;


        }

        public Boolean AddRow()
        {
            try
            {
                Row = salesMoney.NewRow();
                Row["id"] = rebateTime;
                Row["vipnum"] = textBox3.Text;
                Row["Xfdz"] = textBox4.Text;
                // Row["obnamedm"] = int.Parse(textBox5.Text );
                Row["obnamedm"] = textBox5.Text;
                //Double  _up =Double.Parse(textBox6 .Text ) *Double.Parse (textBox11.Text );
                Double _up = Double.Parse(textBox6.Text) * Double.Parse(comboBox1.Text);
                Row["unitprice"] = _up;
                Row["xfnum"] = int.Parse(textBox7.Text);
                Double XfTotal1 = (_up) * Double.Parse(textBox7.Text);
                Row["xfsum"] = XfTotal1;
                Row["dmdm"] = label11.Text;
                Row["obname"] = textBox9.Text;
                salesMoney.Rows.Add(Row);
                dataGridView1.DataSource = salesMoney.DefaultView;
                rebates[rebateTime] = Double.Parse(textBox6.Text) * (1 - Double.Parse(comboBox1.Text)) * Double.Parse(textBox7.Text);
                rebateTime++;


                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Rinput();
                return false;

            }


        }
        private void ShowData()
        {

            string iCnt;
            iCnt = salesMoney.Compute("sum(xfsum)", "xfsum>=0").ToString();

            label15.Text = iCnt.ToString();
            label17.Text = label15.Text;



        }
        private void Rinput()
        {
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = "1";
            textBox9.Text = null;

            textBox5.Focus();

        }




        private void RestoreInput()
        {
            comboBox1.SelectedIndex = 0; //当开始一新的客户收银周期，置折扣率为1
            //comboBox1.Text = "1";
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = "1";
            textBox9.Text = null;
            label9.Text = "0";
            textBox3.ReadOnly = false;
            button4.Enabled = true;
            textBox3.Focus();

        }

        private void beginSales()
        {
            textBox3.ReadOnly = true;
            button4.Enabled = false;
            label9.Text = "0";
            label15.Text = "0";
            label17.Text = "0";
        }
        private void SalesMoney()
        {

            int i, j;
            string sqlString = "insert vipxiaofei(vipnum,xfdz,obnamedm,unitprice,xfnum,xfsum,dmdm,obname)  "
                               + "values(@vipnum,@xfdz, @obnamedm, @unitprice, @xfnum, @xfsum, @dmdm, @obname)";
            //string tmpsqlString = "insert tmpxiaofei(vipnum,xfdz,obnamedm,unitprice,xfnum,xfsum,dmdm,obname)  "
            //                  + "values(@vipnum,@xfdz, @obnamedm, @unitprice, @xfnum, @xfsum, @dmdm, @obname)";

            MySQLCommand mycom = new MySQLCommand(sqlString, conn);
            //MySQLCommand tmpmycom = new MySQLCommand(tmpsqlString, conn);
            try
            {
                j = salesMoney.Rows.Count;
                conn.Open();
                for (i = 0; i < j; i++)
                {

                    MySQLParameter[] sqlparam = new MySQLParameter[8];
                    sqlparam[0] = new MySQLParameter("@vipnum", DbType.String);
                    sqlparam[0].Value = salesMoney.Rows[i]["vipnum"].ToString();
                    sqlparam[1] = new MySQLParameter("@xfdz", DbType.String);
                    sqlparam[1].Value = salesMoney.Rows[i]["xfdz"].ToString();
                    sqlparam[2] = new MySQLParameter("@obnamedm", DbType.String);
                    sqlparam[2].Value = salesMoney.Rows[i]["obnamedm"].ToString();
                    sqlparam[3] = new MySQLParameter("@unitprice", DbType.Double);
                    sqlparam[3].Value = double.Parse(salesMoney.Rows[i]["unitprice"].ToString());
                    sqlparam[4] = new MySQLParameter("@xfnum", DbType.Int32);
                    sqlparam[4].Value = salesMoney.Rows[i]["xfnum"].ToString();
                    sqlparam[5] = new MySQLParameter("@xfsum", DbType.Double);
                    sqlparam[5].Value = double.Parse(salesMoney.Rows[i]["xfsum"].ToString());
                    sqlparam[6] = new MySQLParameter("@dmdm", DbType.String);
                    sqlparam[6].Value = salesMoney.Rows[i]["dmdm"].ToString();
                    sqlparam[7] = new MySQLParameter("@obname", DbType.String);
                    sqlparam[7].Value = salesMoney.Rows[i]["obname"].ToString();

                    mycom.Parameters.Clear();
                    //tmpmycom.Parameters.Clear();
                    foreach (MySQLParameter tmppara in sqlparam)
                    {
                        mycom.Parameters.Add(tmppara);
                        //tmpmycom.Parameters.Add(tmppara);
                    }
                    mycom.ExecuteNonQuery();
                    //tmpmycom.ExecuteNonQuery();


                    //mObject.body = "insert vipxiaofei(vipnum,xfdz,obnamedm,unitprice,xfnum,xfsum,dmdm,obname)  "
                    //           + "values('" 
                    //           + salesMoney.Rows[i]["vipnum"].ToString() + "','"  
                    //           + salesMoney.Rows[i]["xfdz"].ToString() + "','"
                    //           + salesMoney.Rows[i]["obnamedm"].ToString() + "','"  
                    //           + salesMoney.Rows[i]["unitprice"].ToString() + "','" 
                    //           + salesMoney.Rows[i]["xfnum"].ToString() + "','" 
                    //           + salesMoney.Rows[i]["xfsum"].ToString() + "','" 
                    //           + salesMoney.Rows[i]["dmdm"].ToString() + "','" 
                    //           + salesMoney.Rows[i]["obname"].ToString() + "')";

                    //mq.SendMQ(mObject);
                    UpdateStoreRoom(storeroomdm, salesMoney.Rows[i]["obnamedm"].ToString(), salesMoney.Rows[i]["xfnum"].ToString());



                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }

        private void UpdateStoreRoom(string _storeDm, String _obNameDm, string _num)
        {

            StringBuilder updateroomstr = new StringBuilder();
            updateroomstr.Append("call updatestoreroom (");
            updateroomstr.Append("'" + _storeDm + "',");
            updateroomstr.Append("'" + _obNameDm + "',");
            updateroomstr.Append("'" + _num + "'");
            updateroomstr.Append(")");


            try
            {
                sellerCmd.ExeProcedure(updateroomstr.ToString());
                //mObject.body=updateroomstr.ToString();
                //mq.SendMQ(mObject);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DeletedRow(int TmpInt)
        {

            if (salesMoney.Rows.Count > 0)
            {
                int tmp = int.Parse(salesMoney.Rows[TmpInt]["id"].ToString()); //取此条目录的ID号

                label15.Text = Convert.ToString(double.Parse(label15.Text) - double.Parse(salesMoney.Rows[TmpInt].ItemArray[6].ToString()));
                label17.Text = Convert.ToString(double.Parse(label17.Text) - double.Parse(salesMoney.Rows[TmpInt].ItemArray[6].ToString()));
                salesMoney.Rows[TmpInt].Delete();
                salesMoney.AcceptChanges();
                dataGridView1.DataSource = salesMoney.DefaultView;
                rebates[tmp] = 0; //册除此折扣值



            }

        }


        private void PrintSales()
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss") + textBox3.Text.Trim();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox6.Text, @"^\d+(\.\d{1,4})?$"))//匹配金额
            {
                MessageBox.Show("请输入正确单价!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
                return;
            }
            if (!Regex.IsMatch(textBox7.Text, @"^[1-9]+?$|^[1-9]+[0-9]+?$"))//购买数量
            {
                MessageBox.Show("请输入正确购买数量!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
                return;
            }
            if (textBox9.Text.Trim().Length == 0)//购买商品名称不能为空
            {
                MessageBox.Show("请输入商品名称\n\r不能为空!!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Focus();
                return;
            }

            if (AddRow())
            {
                ShowData();
                Rinput();
            }
            else
            {
                MessageBox.Show("销售数据有误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(textBox3.Text, @"^[0-9]?([0-9]?[0-9]?[0-9]?[0-9])?$"))//匹配5位整数
            {
                MessageBox.Show("请输入正确会员号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }


            try
            {


                beginSales();
                label9.Text = getJf();
                textBox8.Text = null;
                textBox10.Text = null;
                label21.Text = "0";

                textBox5.Focus();
                button9.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

                RestoreInput();

            }

        }

        private string getJf()
        {
            string tmpString = textBox3.Text.Trim();
            string[] _fields = new string[] { "xfjf" };
            string[] _tables = new string[] { "vipxiaofeijifen" };
            object[,] _wherePara = new object[,] { { "vipnum", "=", tmpString } };
            DataTable jf = sellerCmd.getwhereRecord(_fields, _tables, _wherePara);
            if (jf.Rows.Count > 0)
            {
                return jf.Rows[0].ItemArray[0].ToString();

            }
            else
            {
                return "0";
            }






        }
        private void button5_Click(object sender, EventArgs e)
        {

            string Tmpstring = textBox5.Text.Trim() + "%";
            DataView dv = new DataView(obTd);
            try
            {
                dv.RowFilter = "obnamedm like  '" + Tmpstring + "'";
                dataGridView2.DataSource = dv;
                dataGridView2.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            dataGridView2.Focus();

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            RestoreInput();
            CreatDs();

        }


        public void jifenZero()
        {

            object[,] _updatePara = new object[,] { { "xfjf", int.Parse(label9.Text) - int.Parse(textBox8.Text) } };
            object[,] _wherePara = new object[,] { { "vipnum", "=", textBox3.Text.Trim() } };
            sellerCmd.tableName = "vipxiaofeijifen";
            sellerCmd.updateRecord(_updatePara, _wherePara);
        }

        private void openDoor()
        {
            Process p = new Process();
            p.StartInfo.FileName = "OpenLptDoor.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (salesMoney.Rows.Count >= 1)
                {
                    if (label17.Text != "0")
                    {
                        printXf();//打印及数据处理
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {


            textBox5.Text = (dataGridView2.CurrentRow.Cells["column1"].Value).ToString();
            textBox9.Text = (dataGridView2.CurrentRow.Cells["column2"].Value).ToString();
            textBox6.Text = (dataGridView2.CurrentRow.Cells["column3"].Value).ToString();
            textBox7.Focus();



        }



        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Text = (dataGridView2.CurrentRow.Cells["column1"].Value).ToString();
                textBox9.Text = (dataGridView2.CurrentRow.Cells["column2"].Value).ToString();
                textBox6.Text = (dataGridView2.CurrentRow.Cells["column3"].Value).ToString();

                textBox7.Focus();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DelRow")
                {

                    DeletedRow(e.RowIndex);

                }
            }
        }

        private string getprintstring()  //打印消售单据
        {
            string printstring = "********" + infoDs.Tables["print"].Rows[0]["title"].ToString() + "*********" + "\n"; //设置网点名称
            printstring += "************交易*************" + "\n";
            printstring += "会员号：" + textBox3.Text + "\n";
            printstring += "商品名" + " 单价 " + " 数量 " + " 小计" + "\n";

            int j, k;
            k = salesMoney.Rows.Count;
            for (j = 0; j < k; j++)
            {


                printstring += salesMoney.Rows[j]["obname"].ToString() + " * ";
                printstring += salesMoney.Rows[j]["unitprice"].ToString() + " * ";
                printstring += salesMoney.Rows[j]["xfnum"].ToString() + " * ";
                printstring += salesMoney.Rows[j]["xfsum"].ToString() + " * ";
                printstring += " \n";



            }

            printstring += "消费金额 " + label15.Text + "\n" + "实付金额 " + label17.Text + "\n";
            printstring += "付款 " + textBox10.Text + "\n" + "找零 " + label21.Text + "\n";
            printstring += "折扣" + getRebateSum() + "\n";
            printstring += "联系电话" + infoDs.Tables["print"].Rows[0]["tel"].ToString() + "\n";
            printstring += "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss") + "\n";
            printstring += "收银员：" + username;
            printstring += "\r\n*********************************** \n\r\r\n*********************************** \n\r";


            //定制打印前台小票数量
            string pstr = "";
            int pnum = int.Parse(infoDs.Tables["print"].Rows[0]["printnum"].ToString());
            for (int i = 0; i < pnum; i++)
            {
                pstr += printstring;

            }
            log.writelog("收银系统SellerSale 打印收银小票\r\n", logtag);
            return pstr;

        }

        private string getCfPrintString()//打印其它打印数据 
        {
            string printstring = "********" + infoDs.Tables["print"].Rows[0]["title"].ToString() + "*********" + "\n"; //设置网点名称
            printstring += "************交易*************" + "\n";
            printstring += "商品名" + " 单价 " + " 数量 " + " 小计" + "\n";

            int j, k;
            k = salesMoney.Rows.Count;
            int i = 0;
            for (j = 0; j < k; j++)
            {

                if (salesMoney.Rows[j]["obnamedm"].ToString().Substring(0, 1) == infoDs.Tables["print"].Rows[0]["cfNo"].ToString())
                {

                    printstring += salesMoney.Rows[j]["obname"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["unitprice"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["xfnum"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["xfsum"].ToString() + " * ";
                    printstring += " \n";
                    i++;
                }
            }

            if (i == 0)
                return "0";


            printstring += "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss") + "\n";
            printstring += "收银员：" + username;
            return printstring;



        }


        private string getBtPrintString()//打印其它打印数据 
        {
            string printstring = "********" + infoDs.Tables["print"].Rows[0]["title"].ToString() + "*********" + "\n"; //设置网点名称
            printstring += "************交易*************" + "\n";
            printstring += "商品名" + " 单价 " + " 数量 " + " 小计" + "\n";

            int j, k;
            int i = 0;
            k = salesMoney.Rows.Count;
            for (j = 0; j < k; j++)
            {

                if (salesMoney.Rows[j]["obnamedm"].ToString().Substring(0, 1) == infoDs.Tables["print"].Rows[0]["btNo"].ToString())
                {

                    printstring += salesMoney.Rows[j]["obname"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["unitprice"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["xfnum"].ToString() + " * ";
                    printstring += salesMoney.Rows[j]["xfsum"].ToString() + " * ";
                    printstring += " \n";
                    i++;
                }


            }
            if (i == 0)  //判断是否有打印数据
                return "0";
            printstring += "打印时间：" + DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss") + "\n";
            printstring += "收银员：" + username;
            return printstring;



        }



        private double getRebateSum()
        {
            double rebateSum = 0;
            foreach (double t in rebates)
            {
                rebateSum = rebateSum + t;
            }
            return rebateSum;

        }

        #region "使用Microsoft打印控件  "
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int charactersOnPage = 0;
            int linesPerPage = 0;
            e.Graphics.MeasureString(stringToPrintXf, this.Font,
            e.MarginBounds.Size, StringFormat.GenericTypographic,
            out charactersOnPage, out linesPerPage);
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(stringToPrintXf, printFont, System.Drawing.Brushes.Black, 10, 10);

            // Remove the portion of the string that has been printed.
            stringToPrintXf = stringToPrintXf.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrintXf.Length > 0);


        }

        private void PrintDoc()
        {
            printDocument1.PrinterSettings.PrinterName = printName;//设置打印机名称
            printDocument1.Print();



        }

        #endregion



        #region   // 直接操作打印机并口

        private void PrintDocLpt() //打印
        {
            if (portName == "" || portName == null)
                portName = "lpt1";

            try
            {
                Lpt pr = new Lpt(portName);
                pr.lptPrint(getprintstring());
                pr.moveGoPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void openDoorLpt() //打开钱箱
        {
            if (portName == "" || portName == null)
                portName = "lpt1";

            Lpt op = new Lpt(portName);
            op.openDoor();

        }

        #endregion

        /// <summary>
        /// 
        /// printXf() 打印相关票据
        /// printname 打印机名
        /// printport 缺省并口lpt1
        /// 
        /// </summary>

        private void printXf()
        {

            if (salesMoney.Rows.Count == 0)  //防止二次打印
                return;



            int regu = int.Parse(infoDs.Tables["admin"].Rows[0]["regu"].ToString()); //算消费积分
            if (checkBox3.Checked)
            {
                stringToPrintCf = getCfPrintString();
                PrintCfDoc();

            }

            if (checkBox4.Checked)
            {
                stringToPrintBt = getBtPrintString();
                printBtDoc();


            }




            if (checkBox1.Checked)
            {


                if (portName.Substring(0, 3).ToUpper() == "POS")
                {
                    stringToPrintXf = getprintstring();
                    PrintDoc(); //打印
                }
                else
                {

                    PrintDocLpt(); //直接操作打印并口
                }

            }
            SalesMoney();
            if (checkBox2.Checked)
            {
                if (portName.Substring(0, 3).ToUpper() == "POS")
                {
                    openDoor(); //启用OpenLptDoor.exe
                }
                else
                {

                    openDoorLpt(); //直接操作打印并口
                }



            }

            if (textBox8.Text != "")
            {

                if (regu != 0)
                {
                    jifenAdd(Convert.ToInt16(decimal.Parse(label17.Text) / regu - decimal.Parse(textBox8.Text))); //计算消费积分
                }
                else
                {
                    jifenAdd(-int.Parse(textBox8.Text)); //计算消费积分

                }

                RecordJfLs();
            }
            else
            {

                if (regu != 0)
                {

                    int jf = Convert.ToInt16(decimal.Parse(label17.Text) / regu);//计算消费积分
                    jifenAdd(jf);

                }
            }
            CurrentSalesJl();
            saveRebates();  //记录折扣
            RestoreInput();
            CreatDs();
            button9.Enabled = false;
        }

        private void RecordJfLs()
        {
            string _vipnum = textBox3.Text.Trim();
            string _saledate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int _jf = int.Parse(textBox8.Text.Trim());
            string jfls = "insert vipxiaofeiliushui(vipnum,saledate,jifen) values ('" + _vipnum + "','" + _saledate + "'," + _jf + ")";
            sellerCmd.ExeMysql(jfls);
            //mObject.body = jfls;
            //mq.SendMQ(mObject);

        }

        public void jifenAdd(int _xfjf)
        {

            //sellerCmd.ExeMysql("update vipxiaofeijifen set xfjf = xfjf +" + _xfjf + " where vipnum= '" + textBox3.Text.Trim() + "'");

            string tmpPrc = "call UpdateXfJiFen('" + textBox3.Text.Trim() + "', " + _xfjf + ")";
            sellerCmd.ExeProcedure(tmpPrc);
            //mObject.body = tmpPrc;
            //mq.SendMQ(mObject);


        }

        private void button11_Click(object sender, EventArgs e)
        {
            PrintSales();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable getOb()
        {
            string[] _fields = new string[] { "*" };
            string[] _tables = new string[] { "ob" };
            string[,] _order = new string[,] { { "id", "desc" } };
            obTd = sellerCmd.getRecord(_fields, _tables, _order);
            return obTd;
        }

        private void fillGv(DataGridView Dv, DataTable dt)
        {
            Dv.DataSource = dt.DefaultView;



        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            searchOb();


        }

        private void searchOb()
        {
            string Tmpstring = textBox5.Text.Trim();
            DataRow[] dr = obTd.Select("obnamedm='" + Tmpstring + "'");
            if (dr.Length > 0)
            {
                textBox9.Text = dr[0][2].ToString();
                textBox6.Text = dr[0][3].ToString();

            }
            else
            {
                textBox9.Text = null;
                textBox6.Text = null;
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox10.Text, @"^[0-9]+?(.\d{1,4})?$"))//匹配可以是正的两位数***.**
            {


                label21.Text = Convert.ToString(double.Parse(textBox10.Text) - double.Parse(label17.Text));
            }

            else
            {
                MessageBox.Show("请输入正确金额", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button9.Focus();


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (textBox8.Text != "")
            {

                if (double.Parse(textBox8.Text) > double.Parse(label9.Text))
                {
                    MessageBox.Show("超出会员积分! ", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox8.Text = null;
                    label17.Text = Convert.ToString(Double.Parse(label15.Text) - 0);
                }
                else
                {
                    label17.Text = Convert.ToString(Double.Parse(label15.Text) - Double.Parse(textBox8.Text));
                }
            }
            else
            {
                label17.Text = Convert.ToString(Double.Parse(label15.Text) - 0);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            qZtz();
        }
        /// <summary>
        /// qZtz() 清台帐
        /// </summary>
        private void qZtz()
        {

            DialogResult dialog = MessageBox.Show("请确认是否清台帐！", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.Cancel)
            {
                return;
            }


            try
            {
                string[] fields = new string[]
                {
               "id", "vipnum", "xfdz", "obnamedm", "unitprice", "xfnum", "xfsum", "dmdm", "obname"
                };
                string[] tables = new string[] { "vipxiaofei" };
                DataTable xf = sellerCmd.getRecord(fields, tables);
                DataSet xfDs = new DataSet();
                xfDs.Tables.Add(xf);
                xfDs.WriteXml("c:\\xf" + DateTime.Now.ToString("yyyy-MM-dd/HH-mm-ss") + ".xml");
                sellerCmd.tableName = "vipxiaofei";
                sellerCmd.DeleteRecord(null);
                string[] icfields = new string[]
                {
               "id", "saledate", "dyname", "dmdm", "icvalue", "balance", "icnum"
                };
                string[] ictables = new string[] { "icmoney" };
                DataTable ic = sellerCmd.getRecord(icfields, ictables);
                DataSet icDs = new DataSet();
                icDs.Tables.Add(ic);
                icDs.WriteXml("c:\\ic" + DateTime.Now.ToString("yyyy-MM-dd/HH-mm-ss") + ".xml");
                sellerCmd.tableName = "icmoney";
                sellerCmd.DeleteRecord(null);




                MessageBox.Show("清台帐成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            msg.Text = "数据正在同步中......";
            dataTb();

        }

        /// <summary>
        /// 同步联机服务器内数据
        /// </summary>

        private void dataTb()
        {
            BaseDate tb = new BaseDate();
            try
            {

                tb.dataImportMySql();

                msg.Text = "数据同步成功......";

                MessageBox.Show("数据导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("数据导入出错!" + err.Message, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button13_Click_1(object sender, EventArgs e)
        {



            AdminFrm fr = new AdminFrm(username, rule);
            //fr.MdiParent = this;
            fr.Show();

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            pauseShops();

        }
        private void pauseShops()
        {
            try
            {
                _shops = new prvShops();
                _shops._vipnum = textBox3.Text;
                _shops._xfdz = textBox4.Text;
                _shops.shop = salesMoney;
                _shops._jf = label9.Text;
                _shops.rebate = rebates;
                RestoreInput();
                CreatDs();
                button9.Enabled = false;
                textBox3.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void restoreShops()
        {
            try
            {
                textBox3.Text = _shops._vipnum;
                textBox4.Text = _shops._xfdz;
                salesMoney = _shops.shop;
                label9.Text = _shops._jf;
                rebates = _shops.rebate;
                dataGridView1.DataSource = salesMoney.DefaultView;
                ShowData();
                button9.Enabled = true;
                textBox5.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            restoreShops();


        }

        private void SellerSale_KeyDown(object sender, KeyEventArgs e)
        {
            //F2收费暂停
            //F3恢复收费
            //F12消费打印
            if (e.KeyCode == Keys.F2)
            {
                pauseShops();
            }
            if (e.KeyCode == Keys.F4)
            {
                restoreShops();
            }
            if (e.KeyCode == Keys.F12)
            {
                try
                {
                    if (salesMoney.Rows.Count >= 1)
                    {
                        if (label17.Text != "0")
                        {
                            printXf();//打印及数据处理
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void fillCombol()
        {
            string[] _fields = new string[] { "zk" };
            string[] _tables = new string[] { "zkou" };

            DataTable zk = sellerCmd.getRecord(_fields, _tables);
            comboBox1.DataSource = zk.DefaultView;
            comboBox1.DisplayMember = "zk";



        }

        private void CurrentSalesJl()
        {

            string _dyname = username;
            DateTime _saledate = DateTime.Now;
            decimal _salesum = decimal.Parse(label17.Text);

            sellerCmd.tableName = "currentsales";
            object[,] insertPara = new object[,] { { "dyname", _dyname }, { "saledate", _saledate }, { "salesum", _salesum } };
            try
            {
                sellerCmd.insertRecord(insertPara);
                //mObject.body = "insert currentsales(dyname,saledate,salesum) values ('"
                //             + _dyname + "','"
                //             + _saledate + "','"
                //             + _salesum + "')";
                //mq.SendMQ(mObject);

            }
            catch (Exception ex)
            {
                MessageBox.Show("currentsalesjl 失败!" + "\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private string getJsString() //取结算数据
        {
            string js = "select * from currentsalesview where dyname = '" + username + "'";

            string[] _fields = new string[] { "dyname", "salesum" };

            string isumstr = "select sum(icvalue) from icmoney where dyname='" + username + "' and saledate= '" + DateTime.Today.ToShortDateString() + "'";

            string rebateStr = " select  sum(rebates) as rebates  from rebates   where dyname='" + username + "' and  saledate = '" + DateTime.Today.ToShortDateString() + "' GROUP BY dyname";


            DataTable jsDt = sellerCmd.ExecCmd(js, _fields);
            DataSet ds = sellerCmd.executeCmd(isumstr);
            DataTable rDt = sellerCmd.executeCmd(rebateStr).Tables[0];

            StringBuilder printStr = new StringBuilder();
            if (jsDt.Rows.Count > 0)
            {
                printStr.Append("****************" + jsDt.Rows[0].ItemArray[0].ToString() + "****************" + "\n");
                printStr.Append("收银小计：" + jsDt.Rows[0].ItemArray[1].ToString() + "\n");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    printStr.Append("IC收银小计：" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "\n");
                }
                if (rDt.Rows.Count > 0)
                {
                    printStr.Append("折扣小计：" + rDt.Rows[0].ItemArray[0].ToString() + "\n");
                }
                printStr.Append("打印时间：" + DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss") + "\n");



            }

            log.writelog("收银系统SellerSale结算小票getJsString--\r\n", logtag);
            return printStr.ToString();



        }



        private void button7_Click_1(object sender, EventArgs e)
        {
            if (portName.Substring(0, 3).ToUpper() == "POS")
            {
                log.writelog("SellerSale--printDocument打印PrintJsDoc\r\n打印设备为:" + portName + "\r\n", logtag);
                PrintJsDoc(); //打印
            }
            else
            {
                log.writelog("SellerSale--LPT打印PrintJsDoc\r\n端口号为:" + portName + "\r\n", logtag);
                Lpt pr = new Lpt(portName);
                pr.lptPrint(getJsString());
                pr.moveGoPage();


            }

            MessageBox.Show("打印完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }






        private void button10_Click(object sender, EventArgs e)
        {
            string nodestr = infoDs.Tables["print"].Rows[0]["title"].ToString();
            Icfrm icform = new Icfrm(username, label11.Text, portName, nodestr, sellerCmd);
            icform.ShowDialog();
            textBox10.Text = icform.Money;

            if (textBox10.Text.Trim().Length != 0)
            {
                if (double.Parse(label17.Text) == double.Parse(textBox10.Text))
                {
                    otherPrint();

                }
            }



        }


        /// <summary>
        /// 有IC卡结算返回打印小票
        /// </summary>


        private void otherPrint()
        {

            try
            {
                if (salesMoney.Rows.Count >= 1)
                {
                    if (label17.Text != "0")
                    {
                        int regu = int.Parse(infoDs.Tables["admin"].Rows[0]["regu"].ToString()); //算消费积分
                        if (checkBox3.Checked)
                        {
                            stringToPrintCf = getCfPrintString();
                            PrintCfDoc();

                        }
                        if (checkBox4.Checked)
                        {
                            stringToPrintBt = getBtPrintString();
                            printBtDoc();


                        }

                        if (checkBox1.Checked)
                        {

                            if (portName.Substring(0, 3).ToUpper() == "POS")
                            {
                                stringToPrintXf = getprintstring();
                                PrintDoc(); //打印
                                log.writelog("IC卡消费打印：" + portName, logtag);
                            }
                            else
                            {

                                PrintDocLpt(); //直接操作打印并口
                                log.writelog("IC卡消费打印：" + portName, logtag);
                            }

                        }
                        SalesMoney();

                        if (textBox8.Text != "")
                        {

                            if (regu != 0)
                            {
                                jifenAdd(Convert.ToInt16(decimal.Parse(label17.Text) / regu - decimal.Parse(textBox8.Text))); //计算消费积分
                            }
                            else
                            {
                                jifenAdd(-int.Parse(textBox8.Text)); //计算消费积分

                            }

                        }
                        else
                        {

                            if (regu != 0)
                            {

                                int jf = Convert.ToInt16(decimal.Parse(label17.Text) / regu);//计算消费积分
                                jifenAdd(jf);

                            }
                        }
                        CurrentSalesJl();
                        RestoreInput();
                        CreatDs();
                        button9.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void saveRebates()
        {
            try
            {
                StringBuilder insertRebate = new StringBuilder();
                insertRebate.Append("insert rebates(dyname,saledate,vipnum,dmdm,rebates)  values('");
                insertRebate.Append(username + "','");
                insertRebate.Append(DateTime.Today + "','");
                insertRebate.Append(textBox3.Text + "','");
                insertRebate.Append(label11.Text + "','");
                insertRebate.Append(getRebateSum() + "')");

                sellerCmd.ExeMysql(insertRebate.ToString());

                //mObject.body = insertRebate.ToString();
                //mq.SendMQ(mObject);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        /// <summary>
        /// 打印收银员当日结算小票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font
              ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(getJsString(), printFont, System.Drawing.Brushes.Black, 10, 10);

        }

        private void PrintJsDoc()
        {
            printDocument2.PrinterSettings.PrinterName = printName;
            printDocument2.Print();
            log.writelog("PrintJsDoc：" + printName, logtag);


        }
        /// <summary>
        /// 打印厨房小票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void cfPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrintCf, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            System.Drawing.Font printFont = new System.Drawing.Font
             ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);
            // Draw the content.
            e.Graphics.DrawString(stringToPrintCf, printFont, System.Drawing.Brushes.Black, 10, 10);


            // Remove the portion of the string that has been printed.
            stringToPrintCf = stringToPrintCf.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrintCf.Length > 0);




        }

        private void PrintCfDoc()
        {
            //判断是否有打印数据
            if (getCfPrintString() == "0")
                return;

            cfPrint.PrinterSettings.PrinterName = cfPrintName;
            cfPrint.Print();
            log.writelog("PrintCfDoc：" + cfPrintName, logtag);
        }

        /// <summary>
        /// 打印巴台订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void btPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrintBt, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);


            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", float.Parse(printFontValue), System.Drawing.FontStyle.Regular);
            // Draw the content.
            e.Graphics.DrawString(stringToPrintBt, printFont, System.Drawing.Brushes.Black, 10, 10);



            // Remove the portion of the string that has been printed.
            stringToPrintBt = stringToPrintBt.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrintBt.Length > 0);

        }

        private void printBtDoc()
        {
            //判断是否有打印数据
            if (getBtPrintString() == "0")
                return;

            btPrint.PrinterSettings.PrinterName = btPrintName;
            btPrint.Print();
            log.writelog("printBtDoc：" + btPrintName, logtag);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {





        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked)
                {
                    string xmlpath = "c:\\info.xml";
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(xmlpath);
                    XmlNamespaceManager xnm = new XmlNamespaceManager(xmldoc.NameTable);
                    XmlNode node = xmldoc.SelectSingleNode("/vipdataset/mysql/sqlName", xnm);
                    //MessageBox.Show(node.InnerText);
                    node.InnerText = remotedatabase;
                    xmldoc.Save(xmlpath);
                    MessageBox.Show("切换成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    string xmlpath = "c:\\info.xml";
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(xmlpath);
                    XmlNamespaceManager xnm = new XmlNamespaceManager(xmldoc.NameTable);
                    XmlNode node = xmldoc.SelectSingleNode("/vipdataset/mysql/sqlName", xnm);
                    //MessageBox.Show(node.InnerText);
                    node.InnerText = "localhost";
                    xmldoc.Save(xmlpath);
                    MessageBox.Show("切换成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件有误，请仔细检查\r\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SellerSale_FormClosed(object sender, FormClosedEventArgs e)
        {





        }





    }
}