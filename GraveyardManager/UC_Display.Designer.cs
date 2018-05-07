namespace GraveyardManager
{
    partial class UC_Display
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.pnl_Tester = new System.Windows.Forms.Panel();
            this.btn_LoadCemetery = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnl_Tester.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(603, 660);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pnl_Tester
            // 
            this.pnl_Tester.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl_Tester.Controls.Add(this.btn_LoadCemetery);
            this.pnl_Tester.Location = new System.Drawing.Point(612, 522);
            this.pnl_Tester.Name = "pnl_Tester";
            this.pnl_Tester.Size = new System.Drawing.Size(207, 141);
            this.pnl_Tester.TabIndex = 1;
            // 
            // btn_LoadCemetery
            // 
            this.btn_LoadCemetery.Location = new System.Drawing.Point(3, 3);
            this.btn_LoadCemetery.Name = "btn_LoadCemetery";
            this.btn_LoadCemetery.Size = new System.Drawing.Size(201, 41);
            this.btn_LoadCemetery.TabIndex = 0;
            this.btn_LoadCemetery.Text = "Load Cemetery";
            this.btn_LoadCemetery.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(612, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 116);
            this.panel2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UC_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Tester);
            this.Controls.Add(this.listView1);
            this.Name = "UC_Display";
            this.Size = new System.Drawing.Size(822, 666);
            this.pnl_Tester.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel pnl_Tester;
        private System.Windows.Forms.Button btn_LoadCemetery;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
    }
}
