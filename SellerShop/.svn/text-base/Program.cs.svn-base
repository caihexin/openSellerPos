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

  
            SellerShop sf = new SellerShop();
            sf.ShowDialog();

            string dmdm = sf.dmdm;
          

            if (sf.DialogResult == DialogResult.OK)
            {

                sf.Close();
                sf.Dispose();
                Application.Run(new InObStoreFrm(dmdm ));
            }










      

        }
    }
}