using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NativeSeller
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }
        public string  getValue()
        {
            return textBox1.Text;
        } 
        public static bool Show(string  title,string  inputTips,bool isPassword,ref string  value)
        {
            InputBox ib = new InputBox();
            if (title != null)
            {
              ib.Text = title;
            }
            if (inputTips != null)
            {
                ib.label1.Text = inputTips;
            } 

            if (isPassword)
            {
            ib.textBox1.PasswordChar = '*';
            } 

            if (ib.ShowDialog()==DialogResult.OK)
            {
                value = ib.getValue();
                ib.Dispose();
                return true;
            }
            else
            {
                ib.Dispose();
                return false;
            }
            }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        

        }
        } 

      
    }
