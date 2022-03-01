using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using MySQLDriverCS;
using mySql;
namespace NativeSeller
{
    public partial class ObtXml : Form
    {
       

        public ObtXml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt.ReadXml("ob.xml", XmlReadMode.Auto  );
            dataGridView1.DataSource = dt.Tables["ob"].DefaultView ;


        }

        private void button3_Click(object sender, EventArgs e)
        {
      

            MySqlDde cmd = new MySqlDde("localhost","crm_dbo","root","");
            string[] fields = new string[] { "obnamedm", "obname", "unitprice" };
            string[] tables = new string[] { "ob" };

           dataGridView1.DataSource = cmd.getRecord(fields ,tables );
 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            string[] fields = new string[] { "obnamedm", "obname", "unitprice" };
            string[] tables = new string[] { "ob" };
            object[,] wherePara = new object[,] { { "obnamedm", "=", "10001" } };
            dataGridView1.DataSource = cmd.getwhereRecord (fields ,tables ,wherePara );
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //    new object[,] { { "SettingID", SettingID }, { "SettingValue", Value } }
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
          //  cmd.ExeMysql("insert ob(obnamedm,obname,unitprice) values('10003','t2','23.5') ");
            cmd.tableName = "ob";
            object[,] insertPara = new object[,] { { "obnamedm", "10006" }, { "obname", "t6" }, { "unitprice", "28.9" } };
            cmd.insertRecord(insertPara );

           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            object[,] updatePara = new object[,] { { "unitprice", "22" } };
            object[,] wherePara = new object[,] { { "obnamedm", "=", "10002" } };
            cmd.tableName = "ob";
            cmd.updateRecord(updatePara, wherePara);


        }

        private void button7_Click(object sender, EventArgs e)
        {
           // new object[,] { { "SettingID", "=", SettingID } }
            MySqlDde cmd = new MySqlDde("localhost", "crm_dbo", "root", "");
            cmd.tableName = "ob";
            object[,] delPara = new object[,] { { "obnamedm", "=", "10001" } };

            cmd.DeleteRecord(delPara);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //insidebaseTomy();
            insideTomy();
        }

        private void obTomy()
        {
           
        }
        private void insidebaseTomy()
        {
             
    
        }
        private void insideTomy()
        {

          
        }

        private void vipTomy()
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vipTomy();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                insidebaseTomy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            jfTomy();
        }
        private void jfTomy()
        {
           

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //DataSet xfDs = new DataSet();
            //xfDs.ReadXml("xf.xml");

            //if (cmd.updateMultRecord(xfDs.Tables[0], "select   vipnum, xfdz, obnamedm, unitprice, xfnum, xfsum, dmdm,obname from vipxiaofei where 1<0"))
            //{


            //    MessageBox.Show("数据导入成功!","提示",MessageBoxButtons.OK ,MessageBoxIcon.Information );

            //}

        }

        private void ObtXml_Load(object sender, EventArgs e)
        {

        }

    }
}