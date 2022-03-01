using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySQLDriverCS;
using mySql;
using DataAccess;
using System.Net.Mail;
using System.Net;
namespace NativeSeller
{
    public partial class Orderfrm : Form
    {

        private MySqlDde myCmd;
        private IData db = new SqliteData("seller.db");
        static DataTable ob_td_order ,order;
        static DataRow Row;
        public Orderfrm(string dy)
        {
            InitializeComponent();

            
            insidetextbox.Text = dy;


        }

        private void orderfrm_Load(object sender, EventArgs e)
        {


            BaseDate baseDt = new BaseDate();
            myCmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            sttextbox.Text  = baseDt.storeroom;
            
            CreatOrder();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            ob_td_order = GetObData();
            dataGridView1.DataSource = ob_td_order.DefaultView;

        }
        private void CreatOrder()
        {
            

            order = new DataTable();
            DataColumn column0 = new DataColumn("id", typeof(System.Int32));
            column0.AutoIncrement = true;
            order.Columns.Add(column0);
            DataColumn column1 = new DataColumn("obnamedm", typeof(System.String));
            order.Columns.Add(column1);
            DataColumn column2 = new DataColumn("ordernum", typeof(System.Int16 ));
            order.Columns.Add(column2);
            DataColumn column3 = new DataColumn("storedm", typeof(System.String));
            order.Columns.Add(column3);
            DataColumn column4 = new DataColumn("dyname", typeof(System.String ));
            order.Columns.Add(column4);
            DataColumn column5 = new DataColumn("ordertime", typeof(System.String  ));
            order.Columns.Add(column5);
            DataColumn column6 = new DataColumn("orderstate", typeof(System.String ));
            order.Columns.Add(column6);
            DataColumn column7 = new DataColumn("obname", typeof(System.String));
            order.Columns.Add(column7);

            dataGridView2.DataSource = order.DefaultView;

        }
        public Boolean AddRow()
        {
            try
            {
                Row = order.NewRow();

                Row["obnamedm"] = obtextbox .Text ;
                Row["ordernum"] =int.Parse ( obnum.Text) ;
                Row["storedm"] = sttextbox.Text ;
                Row["dyname"] = insidetextbox.Text ;
                Row["ordertime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Row["orderstate"] = "订货";
                Row["obname"] = obname.Text;
                order.Rows.Add(Row);
              
                dataGridView2.DataSource = order.DefaultView;


                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Rinput();
                return false;

            }


        }
        private void Rinput()
        {
            obtextbox.Text = "";
            obnum.Text = "";
            obname.Text = "";
            obtextbox.Focus();
        }

   

        private DataTable GetObData()
        {
            return myCmd.executeCmd("select * from ob order by obnamedm").Tables[0];


        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Tmpstring = obtextbox.Text.Trim() + "%";

            DataView dv = new DataView(ob_td_order);
            try
            {
                dv.RowFilter = "obnamedm like  '" + Tmpstring + "'";
                dataGridView1.DataSource = dv;
                dataGridView1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void searchOb()
        {
            string Tmpstring = obtextbox .Text .Trim ();

            DataRow[] dr = ob_td_order.Select("obnamedm='" + Tmpstring + "'");

            if (dr.Length > 0)
            {
                obname.Text  = dr[0][2].ToString();
               

            }
            else
            {
               obname.Text  = null;
               
            }






        }

        private void obtextbox_TextChanged(object sender, EventArgs e)
        {
            searchOb();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (AddRow())
            {
                  Rinput();
            }
            else
            {
                MessageBox.Show("数据有误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                obtextbox.Text  = (dataGridView1.CurrentRow.Cells["obnamedm"].Value).ToString();
                obname.Text = (dataGridView1.CurrentRow.Cells["obname_Cl"].Value).ToString();
               obnum.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dataGridView2.Columns[e.ColumnIndex].Name == "delrow")
                {

                    DeletedRow(e.RowIndex);

                }
            }
        }
        private void DeletedRow(int TmpInt)
        {
            if (order.Rows.Count > 0)
            {
                order.Rows[TmpInt].Delete();
                dataGridView2.DataSource = order.DefaultView;
            }

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            obtextbox.Text = (dataGridView1.CurrentRow.Cells["obnamedm"].Value).ToString();
            obname.Text = (dataGridView1.CurrentRow.Cells["obname_Cl"].Value).ToString();
            obnum.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveOrder();
            CreatOrder();
           
        }


        private void SendMail(string mail)
        {
            try
            {

               DataTable sys=    db.show("select id, outmail ,outport,user,passwd,inmail,outserver from sys").Tables[0];
               string outmail = sys.Rows[0].ItemArray[1].ToString();
               string outport = sys.Rows[0].ItemArray[2].ToString();
               string user = sys.Rows[0].ItemArray[3].ToString();
               string passwd = sys.Rows[0].ItemArray[4].ToString();
               string inmail =  sys.Rows[0].ItemArray[5].ToString();
               string outserver = sys.Rows[0].ItemArray[6].ToString();




                MailMessage Email = new MailMessage();
                MailAddress MailFrom =
                  new MailAddress(outmail, "麦香人家");
                Email.From = MailFrom;
                Email.To.Add( inmail );
                Email.Subject = "订单信息";
                Email.Body = mail ;
                Email.Priority = MailPriority.High;
                Email.IsBodyHtml = true;

                // Smtp Client
                SmtpClient SmtpMail =
                 new SmtpClient(outserver , int.Parse (outport ));
                SmtpMail.Credentials =
                 new NetworkCredential(user ,passwd );
                SmtpMail.EnableSsl = false;
                //SmtpMail.UseDefaultCredentials = false;
                SmtpMail.Send(Email);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void   SaveOrder()
        {
            if (order.Rows.Count == 0)
                return;

            StringBuilder orderstring = new StringBuilder();
            orderstring.Append("**商品名称**订货数量**网点代码**定货人**定货时间**定货状态\n\r");
            try
            {
                foreach (DataRow dr in order.Rows)
                {
                    StringBuilder insertstring = new StringBuilder();
                    insertstring .Append ( "insert into orders(obnamedm,ordernum,storedm,dyname,ordertime,orderstate,obname) values('" );
                    insertstring.Append(dr.ItemArray[1].ToString() + "','");
                    insertstring.Append(dr.ItemArray[2].ToString() + "','");
                    insertstring.Append(dr.ItemArray[3].ToString() + "','");
                    insertstring.Append(dr.ItemArray[4].ToString() + "','");
                    insertstring.Append(dr.ItemArray[5].ToString() + "','");
                    insertstring.Append(dr.ItemArray[6].ToString() + "','");
                    insertstring.Append(dr.ItemArray[7].ToString() + "')");
                 
                    orderstring.Append("**" + dr.ItemArray[7].ToString());
                    orderstring.Append("**" + dr.ItemArray[2].ToString());
                    orderstring.Append("**" + dr.ItemArray[3].ToString());
                    orderstring.Append("**" + dr.ItemArray[4].ToString());
                    orderstring.Append("**" + dr.ItemArray[5].ToString());
                    orderstring.Append("**" + dr.ItemArray[6].ToString() +"\n");

                    db.insert(insertstring.ToString());
                }

               // MessageBox.Show(orderstring.ToString());
                SendMail(orderstring.ToString());

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message , "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
             

            }

        }
    }
}