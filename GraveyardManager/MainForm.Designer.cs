namespace GraveyardManager
{
    partial class frm_GraveyardManager
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
            this.pnl_MainView = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGraveyardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inhabitantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uC_Display1 = new GraveyardManager.UC_Display();
            this.pnl_MainView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_MainView
            // 
            this.pnl_MainView.AutoSize = true;
            this.pnl_MainView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_MainView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnl_MainView.Controls.Add(this.uC_Display1);
            this.pnl_MainView.Location = new System.Drawing.Point(0, 27);
            this.pnl_MainView.Name = "pnl_MainView";
            this.pnl_MainView.Size = new System.Drawing.Size(1030, 643);
            this.pnl_MainView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "File...";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadFileToolStripMenuItem.Text = "Load File...";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawGraveyardToolStripMenuItem,
            this.inhabitantsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.viewToolStripMenuItem.Text = "View...";
            // 
            // drawGraveyardToolStripMenuItem
            // 
            this.drawGraveyardToolStripMenuItem.Name = "drawGraveyardToolStripMenuItem";
            this.drawGraveyardToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.drawGraveyardToolStripMenuItem.Text = "Draw Graveyard";
            this.drawGraveyardToolStripMenuItem.Click += new System.EventHandler(this.drawGraveyardToolStripMenuItem_Click);
            // 
            // inhabitantsToolStripMenuItem
            // 
            this.inhabitantsToolStripMenuItem.Name = "inhabitantsToolStripMenuItem";
            this.inhabitantsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.inhabitantsToolStripMenuItem.Text = "Database";
            this.inhabitantsToolStripMenuItem.Click += new System.EventHandler(this.inhabitantsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // uC_Display1
            // 
            this.uC_Display1.AutoSize = true;
            this.uC_Display1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uC_Display1.Location = new System.Drawing.Point(3, 3);
            this.uC_Display1.Name = "uC_Display1";
            this.uC_Display1.Size = new System.Drawing.Size(1024, 637);
            this.uC_Display1.TabIndex = 0;
            // 
            // frm_GraveyardManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1039, 674);
            this.Controls.Add(this.pnl_MainView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_GraveyardManager";
            this.Text = "Graveyard Manager";
            this.pnl_MainView.ResumeLayout(false);
            this.pnl_MainView.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MainView;
        private UC_Display uC_Display1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGraveyardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inhabitantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

