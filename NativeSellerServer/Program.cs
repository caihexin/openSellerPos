using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NativeSeller
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

  
            SaleServer sf = new SaleServer();
            sf.ShowDialog();

            string username = sf.username;
            string rule = sf.rule;

            if (sf.DialogResult == DialogResult.OK)
            {

                sf.Close();
                sf.Dispose();
                Application.Run(new AdminFrm(username, rule));
            }










      

        }
    }
}