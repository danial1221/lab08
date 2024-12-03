namespace Activity_01_Lab
{
    partial class MDICustomer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enterCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterCustomerToolStripMenuItem,
            this.form1OpenToolStripMenuItem,
            this.form2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enterCustomerToolStripMenuItem
            // 
            this.enterCustomerToolStripMenuItem.Name = "enterCustomerToolStripMenuItem";
            this.enterCustomerToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.enterCustomerToolStripMenuItem.Text = "file";
            this.enterCustomerToolStripMenuItem.Click += new System.EventHandler(this.enterCustomerToolStripMenuItem_Click);
            // 
            // form1OpenToolStripMenuItem
            // 
            this.form1OpenToolStripMenuItem.Name = "form1OpenToolStripMenuItem";
            this.form1OpenToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.form1OpenToolStripMenuItem.Text = "Form1 open";
            this.form1OpenToolStripMenuItem.Click += new System.EventHandler(this.form1OpenToolStripMenuItem_Click);
            // 
            // form2ToolStripMenuItem
            // 
            this.form2ToolStripMenuItem.Name = "form2ToolStripMenuItem";
            this.form2ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.form2ToolStripMenuItem.Text = "Form2";
            // 
            // MDICustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 501);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDICustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDICustomer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enterCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form1OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form2ToolStripMenuItem;
    }
}