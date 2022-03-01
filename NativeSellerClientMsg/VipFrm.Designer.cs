namespace NativeSeller
{
    partial class VipFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.vipnum = new System.Windows.Forms.TextBox();
            this.vipname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vipsfz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viptel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vipmob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vipwork = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.vipemail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.viphome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vipbirthday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.birthdaypp1 = new System.Windows.Forms.RadioButton();
            this.birthdaypp2 = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(865, 242);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dataGridView1_CancelRowEdit);
            this.dataGridView1.EditModeChanged += new System.EventHandler(this.dataGridView1_EditModeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会员号";
            // 
            // vipnum
            // 
            this.vipnum.Location = new System.Drawing.Point(83, 12);
            this.vipnum.MaxLength = 5;
            this.vipnum.Name = "vipnum";
            this.vipnum.Size = new System.Drawing.Size(100, 21);
            this.vipnum.TabIndex = 2;
            // 
            // vipname
            // 
            this.vipname.Location = new System.Drawing.Point(388, 12);
            this.vipname.MaxLength = 8;
            this.vipname.Name = "vipname";
            this.vipname.Size = new System.Drawing.Size(100, 21);
            this.vipname.TabIndex = 4;
            this.vipname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "会员名";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // vipsfz
            // 
            this.vipsfz.Location = new System.Drawing.Point(83, 39);
            this.vipsfz.MaxLength = 18;
            this.vipsfz.Name = "vipsfz";
            this.vipsfz.Size = new System.Drawing.Size(405, 21);
            this.vipsfz.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "身份证";
            // 
            // viptel
            // 
            this.viptel.Location = new System.Drawing.Point(83, 67);
            this.viptel.MaxLength = 11;
            this.viptel.Name = "viptel";
            this.viptel.Size = new System.Drawing.Size(201, 21);
            this.viptel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "电话";
            // 
            // vipmob
            // 
            this.vipmob.Location = new System.Drawing.Point(83, 93);
            this.vipmob.MaxLength = 11;
            this.vipmob.Name = "vipmob";
            this.vipmob.Size = new System.Drawing.Size(201, 21);
            this.vipmob.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "移动电话";
            // 
            // vipwork
            // 
            this.vipwork.Location = new System.Drawing.Point(83, 122);
            this.vipwork.MaxLength = 100;
            this.vipwork.Name = "vipwork";
            this.vipwork.Size = new System.Drawing.Size(405, 21);
            this.vipwork.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "工作单位";
            // 
            // vipemail
            // 
            this.vipemail.Location = new System.Drawing.Point(83, 146);
            this.vipemail.MaxLength = 50;
            this.vipemail.Name = "vipemail";
            this.vipemail.Size = new System.Drawing.Size(100, 21);
            this.vipemail.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "邮箱";
            // 
            // viphome
            // 
            this.viphome.Location = new System.Drawing.Point(83, 173);
            this.viphome.MaxLength = 100;
            this.viphome.Name = "viphome";
            this.viphome.Size = new System.Drawing.Size(405, 21);
            this.viphome.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "家庭地址";
            // 
            // vipbirthday
            // 
            this.vipbirthday.Location = new System.Drawing.Point(83, 208);
            this.vipbirthday.Name = "vipbirthday";
            this.vipbirthday.Size = new System.Drawing.Size(100, 21);
            this.vipbirthday.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "生日";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "生日属性";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // birthdaypp1
            // 
            this.birthdaypp1.AutoSize = true;
            this.birthdaypp1.Checked = true;
            this.birthdaypp1.Location = new System.Drawing.Point(322, 213);
            this.birthdaypp1.Name = "birthdaypp1";
            this.birthdaypp1.Size = new System.Drawing.Size(71, 16);
            this.birthdaypp1.TabIndex = 22;
            this.birthdaypp1.TabStop = true;
            this.birthdaypp1.Text = "阳历生日";
            this.birthdaypp1.UseVisualStyleBackColor = true;
            // 
            // birthdaypp2
            // 
            this.birthdaypp2.AutoSize = true;
            this.birthdaypp2.Location = new System.Drawing.Point(417, 215);
            this.birthdaypp2.Name = "birthdaypp2";
            this.birthdaypp2.Size = new System.Drawing.Size(71, 16);
            this.birthdaypp2.TabIndex = 23;
            this.birthdaypp2.Text = "农历生日";
            this.birthdaypp2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msg
            // 
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(29, 17);
            this.msg.Text = "提示";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label11.Location = new System.Drawing.Point(81, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "****（年）-**（月）-**（日）";
            // 
            // vipFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 571);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.birthdaypp2);
            this.Controls.Add(this.birthdaypp1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.vipbirthday);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.viphome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vipemail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.vipwork);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.vipmob);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.viptel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vipsfz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vipname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vipnum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "vipFrm";
            this.Text = "会员基本信息";
            this.Load += new System.EventHandler(this.vipFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vipnum;
        private System.Windows.Forms.TextBox vipname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vipsfz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox viptel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vipmob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox vipwork;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox vipemail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox viphome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox vipbirthday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton birthdaypp1;
        private System.Windows.Forms.RadioButton birthdaypp2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel msg;
        private System.Windows.Forms.Label label11;
    }
}