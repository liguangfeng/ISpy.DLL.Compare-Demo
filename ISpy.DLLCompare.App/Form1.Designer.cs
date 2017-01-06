namespace ISpy.DLLCompare.App
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOld = new System.Windows.Forms.Button();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFile1
            // 
            this.txtFile1.Location = new System.Drawing.Point(18, 40);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(268, 21);
            this.txtFile1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(305, 38);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "文件一";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // btnOld
            // 
            this.btnOld.Location = new System.Drawing.Point(305, 77);
            this.btnOld.Name = "btnOld";
            this.btnOld.Size = new System.Drawing.Size(75, 23);
            this.btnOld.TabIndex = 3;
            this.btnOld.Text = "文件二";
            this.btnOld.UseVisualStyleBackColor = true;
            this.btnOld.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // txtFile2
            // 
            this.txtFile2.Location = new System.Drawing.Point(17, 79);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(269, 21);
            this.txtFile2.TabIndex = 2;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(18, 106);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(173, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "比较[Class list]";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "比较[All in One]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCompare2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 173);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnOld);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtFile1);
            this.Name = "Form1";
            this.Text = "Dll Compare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOld;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button button1;
    }
}

