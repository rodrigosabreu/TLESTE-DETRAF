namespace DETRAF.VIEW
{
    partial class FormHome
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pREÇOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detrafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.eOTToolStripMenuItem,
            this.pREÇOSToolStripMenuItem,
            this.detrafToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "CDR";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem2.Text = "PREFIXO";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // eOTToolStripMenuItem
            // 
            this.eOTToolStripMenuItem.Name = "eOTToolStripMenuItem";
            this.eOTToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.eOTToolStripMenuItem.Text = "EOT";
            this.eOTToolStripMenuItem.Click += new System.EventHandler(this.eOTToolStripMenuItem_Click);
            // 
            // pREÇOSToolStripMenuItem
            // 
            this.pREÇOSToolStripMenuItem.Name = "pREÇOSToolStripMenuItem";
            this.pREÇOSToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.pREÇOSToolStripMenuItem.Text = "TABELA DE PREÇOS";
            this.pREÇOSToolStripMenuItem.Click += new System.EventHandler(this.pREÇOSToolStripMenuItem_Click);
            // 
            // detrafToolStripMenuItem
            // 
            this.detrafToolStripMenuItem.Name = "detrafToolStripMenuItem";
            this.detrafToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.detrafToolStripMenuItem.Text = "DETRAF";
            this.detrafToolStripMenuItem.Click += new System.EventHandler(this.detrafToolStripMenuItem_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Leste Telecom - Sistema de DETRAF";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pREÇOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detrafToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eOTToolStripMenuItem;
    }
}