namespace NativeSeller
{
    partial class Insidebasefrm
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isfz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.itel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iadd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rule1 = new System.Windows.Forms.RadioButton();
            this.rule2 = new System.Windows.Forms.RadioButton();
            this.rule3 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.ibirthday = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.idm = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.rule4 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.Location = new System.Drawing.Point(3, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 296);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "dyname";
            this.Column2.HeaderText = "员工姓名";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "dysecure";
            this.Column3.HeaderText = "密码";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "dysfz";
            this.Column4.HeaderText = "身份证号";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "dyemail";
            this.Column5.HeaderText = "邮箱";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "dytel";
            this.Column6.HeaderText = "联系电话";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "dymob";
            this.Column7.HeaderText = "移动电话";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "dyhome";
            this.Column8.HeaderText = "家庭地址";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "rulename";
            this.Column9.HeaderText = "权限";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "birthday";
            this.Column10.HeaderText = "生日";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "dmdm";
            this.Column11.HeaderText = "网点代码";
            this.Column11.Name = "Column11";
            // 
            // iname
            // 
            this.iname.Location = new System.Drawing.Point(103, 16);
            this.iname.MaxLength = 12;
            this.iname.Name = "iname";
            this.iname.Size = new System.Drawing.Size(100, 21);
            this.iname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "员工姓名*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码*";
            // 
            // ipasswd
            // 
            this.ipasswd.Location = new System.Drawing.Point(339, 19);
            this.ipasswd.MaxLength = 8;
            this.ipasswd.Name = "ipasswd";
            this.ipasswd.Size = new System.Drawing.Size(100, 21);
            this.ipasswd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "身份证";
            // 
            // isfz
            // 
            this.isfz.Location = new System.Drawing.Point(103, 46);
            this.isfz.MaxLength = 18;
            this.isfz.Name = "isfz";
            this.isfz.Size = new System.Drawing.Size(336, 21);
            this.isfz.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "邮箱";
            // 
            // imail
            // 
            this.imail.Location = new System.Drawing.Point(103, 73);
            this.imail.MaxLength = 50;
            this.imail.Name = "imail";
            this.imail.Size = new System.Drawing.Size(204, 21);
            this.imail.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "联系电话";
            // 
            // itel
            // 
            this.itel.Location = new System.Drawing.Point(103, 100);
            this.itel.MaxLength = 11;
            this.itel.Name = "itel";
            this.itel.Size = new System.Drawing.Size(100, 21);
            this.itel.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "移动电话";
            // 
            // imob
            // 
            this.imob.Location = new System.Drawing.Point(339, 100);
            this.imob.MaxLength = 11;
            this.imob.Name = "imob";
            this.imob.Size = new System.Drawing.Size(100, 21);
            this.imob.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "家庭住址";
            // 
            // iadd
            // 
            this.iadd.Location = new System.Drawing.Point(103, 127);
            this.iadd.MaxLength = 100;
            this.iadd.Name = "iadd";
            this.iadd.Size = new System.Drawing.Size(336, 21);
            this.iadd.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "权限*";
            // 
            // rule1
            // 
            this.rule1.AutoSize = true;
            this.rule1.Location = new System.Drawing.Point(103, 155);
            this.rule1.Name = "rule1";
            this.rule1.Size = new System.Drawing.Size(59, 16);
            this.rule1.TabIndex = 18;
            this.rule1.TabStop = true;
            this.rule1.Text = "收银员";
            this.rule1.UseVisualStyleBackColor = true;
            // 
            // rule2
            // 
            this.rule2.AutoSize = true;
            this.rule2.Location = new System.Drawing.Point(227, 155);
            this.rule2.Name = "rule2";
            this.rule2.Size = new System.Drawing.Size(71, 16);
            this.rule2.TabIndex = 19;
            this.rule2.TabStop = true;
            this.rule2.Text = "高级权限";
            this.rule2.UseVisualStyleBackColor = true;
            // 
            // rule3
            // 
            this.rule3.AutoSize = true;
            this.rule3.Checked = true;
            this.rule3.Location = new System.Drawing.Point(344, 153);
            this.rule3.Name = "rule3";
            this.rule3.Size = new System.Drawing.Size(71, 16);
            this.rule3.TabIndex = 20;
            this.rule3.TabStop = true;
            this.rule3.Text = "普通员工";
            this.rule3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "生日XXXX-XX-XX";
            // 
            // ibirthday
            // 
            this.ibirthday.Location = new System.Drawing.Point(125, 177);
            this.ibirthday.Name = "ibirthday";
            this.ibirthday.Size = new System.Drawing.Size(100, 21);
            this.ibirthday.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(266, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "网点代码*";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "提交";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // idm
            // 
            this.idm.Location = new System.Drawing.Point(339, 180);
            this.idm.Name = "idm";
            this.idm.Size = new System.Drawing.Size(100, 21);
            this.idm.TabIndex = 26;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msg
            // 
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(55, 17);
            this.msg.Text = "提示信息";
            // 
            // rule4
            // 
            this.rule4.AutoSize = true;
            this.rule4.Location = new System.Drawing.Point(449, 153);
            this.rule4.Name = "rule4";
            this.rule4.Size = new System.Drawing.Size(71, 16);
            this.rule4.TabIndex = 28;
            this.rule4.TabStop = true;
            this.rule4.Text = "最高权限";
            this.rule4.UseVisualStyleBackColor = true;
            // 
            // Insidebasefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 600);
            this.Controls.Add(this.rule4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.idm);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ibirthday);
            this.Controls.Add(this.rule3);
            this.Controls.Add(this.rule2);
            this.Controls.Add(this.rule1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iadd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imob);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.itel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.isfz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipasswd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iname);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Insidebasefrm";
            this.Text = "员工资料";
            this.Load += new System.EventHandler(this.insidebasefrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.TextBox iname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox isfz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox itel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox imob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox iadd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rule1;
        private System.Windows.Forms.RadioButton rule2;
        private System.Windows.Forms.RadioButton rule3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ibirthday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox idm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel msg;
        private System.Windows.Forms.RadioButton rule4;
    }
}