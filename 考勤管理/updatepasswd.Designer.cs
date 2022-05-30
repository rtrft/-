namespace 考勤管理
{
    partial class updatepasswd
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
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textB_passwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textB_1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textB_2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 287);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(248, 72);
            this.button3.TabIndex = 52;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = " 新 密 码：";
            // 
            // textB_passwd
            // 
            this.textB_passwd.Location = new System.Drawing.Point(132, 182);
            this.textB_passwd.Margin = new System.Windows.Forms.Padding(4);
            this.textB_passwd.Name = "textB_passwd";
            this.textB_passwd.PasswordChar = '*';
            this.textB_passwd.Size = new System.Drawing.Size(132, 25);
            this.textB_passwd.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "旧 密 码:";
            // 
            // textB_1
            // 
            this.textB_1.Location = new System.Drawing.Point(132, 52);
            this.textB_1.Margin = new System.Windows.Forms.Padding(4);
            this.textB_1.Name = "textB_1";
            this.textB_1.PasswordChar = '*';
            this.textB_1.Size = new System.Drawing.Size(132, 25);
            this.textB_1.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 54;
            this.label1.Text = "确认密码:";
            // 
            // textB_2
            // 
            this.textB_2.Location = new System.Drawing.Point(132, 112);
            this.textB_2.Margin = new System.Windows.Forms.Padding(4);
            this.textB_2.Name = "textB_2";
            this.textB_2.PasswordChar = '*';
            this.textB_2.Size = new System.Drawing.Size(132, 25);
            this.textB_2.TabIndex = 53;
            // 
            // updatepasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textB_2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textB_passwd);
            this.Controls.Add(this.textB_1);
            this.Name = "updatepasswd";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textB_passwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textB_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textB_2;
    }
}