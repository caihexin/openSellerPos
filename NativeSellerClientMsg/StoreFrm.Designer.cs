namespace NativeSeller
{
    partial class StoreFrm
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
            this.storedm = new System.Windows.Forms.TextBox();
            this.storename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.storeaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.storetel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.msg = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(733, 229);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "网点代码";
            // 
            // storedm
            // 
            this.storedm.Location = new System.Drawing.Point(102, 12);
            this.storedm.MaxLength = 2;
            this.storedm.Name = "storedm";
            this.storedm.Size = new System.Drawing.Size(48, 21);
            this.storedm.TabIndex = 2;
            // 
            // storename
            // 
            this.storename.Location = new System.Drawing.Point(102, 39);
            this.storename.MaxLength = 50;
            this.storename.Name = "storename";
            this.storename.Size = new System.Drawing.Size(379, 21);
            this.storename.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "网点名称";
            // 
            // storeaddress
            // 
            this.storeaddress.Location = new System.Drawing.Point(102, 66);
            this.storeaddress.MaxLength = 50;
            this.storeaddress.Name = "storeaddress";
            this.storeaddress.Size = new System.Drawing.Size(379, 21);
            this.storeaddress.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "地址";
            // 
            // storetel
            // 
            this.storetel.Location = new System.Drawing.Point(102, 93);
            this.storetel.MaxLength = 11;
            this.storetel.Name = "storetel";
            this.storetel.Size = new System.Drawing.Size(257, 21);
            this.storetel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "联系电话";
            // 
            // linkname
            // 
            this.linkname.Location = new System.Drawing.Point(102, 120);
            this.linkname.MaxLength = 8;
            this.linkname.Name = "linkname";
            this.linkname.Size = new System.Drawing.Size(100, 21);
            this.linkname.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "联系人";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // msg
            // 
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(55, 17);
            this.msg.Text = "提示信息";
            // 
            // storeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 522);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.storetel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.storeaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.storename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.storedm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "storeFrm";
            this.Text = "网点信息维护";
            this.Load += new System.EventHandler(this.storeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox storedm;
        private System.Windows.Forms.TextBox storename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox storeaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox storetel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox linkname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel msg;
    }
}