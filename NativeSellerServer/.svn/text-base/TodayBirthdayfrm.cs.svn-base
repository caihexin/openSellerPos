using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using mySql;
using Calendar;
//using Microsoft.VisualBasic;
namespace NativeSeller
{
    public partial class TodayBirthdayfrm : Form
    {
        private  MySqlDde cmd;
        private ChineseCalendar nl = new ChineseCalendar(DateTime.Now); 
        public TodayBirthdayfrm()
        {
            InitializeComponent();
        }

        private void todayBirthdayfrm_Load(object sender, EventArgs e)
        {
            BaseDate baseDt = new BaseDate();
            cmd = new MySqlDde(baseDt._mySqlName, baseDt._dataName, baseDt._user, baseDt._pwd);
            //dataGridView1.AutoGenerateColumns = false;
            string tday_yl =  DateTime.Now.ToString("MM-dd");
            string tday_nl =DateTime.Parse( nl.NDateString.ToString()).ToString ("MM-dd");
            fillGr(tday_yl, tday_yl);
           // fillGr("01-01", "11-13");

        }
        private void fillGr(string _wherepara1, string _wherepara2)
        {

            string[] _fields = new string[] { "会员号", "姓名","生日" ,"生日属性"};

            string _query = "select vipnum,vipname,vipbirthday ,birthdaypp  from vipbase where  " +
                                " STR_TO_DATE(vipbirthday,GET_FORMAT(date,'ISO')) " +
                                " like  '%" + _wherepara1 + "' and  birthdaypp=0" +
                                " union " +
                                " select vipnum,vipname,vipbirthday ,birthdaypp  from vipbase where  " +
                                "  STR_TO_DATE(vipbirthday,GET_FORMAT(date,'ISO')) " +
                                "  like '%" + _wherepara2 + "' and birthdaypp=1";

            DataTable dt = cmd.ExecCmd (_query, _fields);

            dataGridView1.DataSource = dt.DefaultView;
        }

        private void tday_ValueChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show(tday.Value.ToString ("MM-dd") );
   
        }

        private void tday_KeyDown(object sender, KeyEventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tday_yl = tday.Value.ToString("MM-dd");
            nl = new ChineseCalendar(tday.Value);
            string tday_nl = DateTime.Parse(nl.NDateString.ToString()).ToString("MM-dd");
            fillGr(tday_yl, tday_yl);
        }
        
    }
}