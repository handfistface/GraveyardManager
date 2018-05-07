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
            this.lstv_Patrons = new System.Windows.Forms.ListView();
            this.pnl_Tester = new System.Windows.Forms.Panel();
            this.btn_LoadCemetery = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.col_FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_MiddleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Section = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_GraveId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_DateOfDeath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Notes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_Tester.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstv_Patrons
            // 
            this.lstv_Patrons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_FirstName,
            this.col_MiddleName,
            this.col_LastName,
            this.col_Section,
            this.col_GraveId,
            this.col_DateOfDeath,
            this.col_Notes});
            this.lstv_Patrons.FullRowSelect = true;
            this.lstv_Patrons.Location = new System.Drawing.Point(3, 3);
            this.lstv_Patrons.MultiSelect = false;
            this.lstv_Patrons.Name = "lstv_Patrons";
            this.lstv_Patrons.Size = new System.Drawing.Size(750, 660);
            this.lstv_Patrons.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstv_Patrons.TabIndex = 0;
            this.lstv_Patrons.UseCompatibleStateImageBehavior = false;
            this.lstv_Patrons.View = System.Windows.Forms.View.Details;
            // 
            // pnl_Tester
            // 
            this.pnl_Tester.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl_Tester.Controls.Add(this.btn_LoadCemetery);
            this.pnl_Tester.Location = new System.Drawing.Point(759, 522);
            this.pnl_Tester.Name = "pnl_Tester";
            this.pnl_Tester.Size = new System.Drawing.Size(200, 141);
            this.pnl_Tester.TabIndex = 1;
            // 
            // btn_LoadCemetery
            // 
            this.btn_LoadCemetery.Location = new System.Drawing.Point(3, 3);
            this.btn_LoadCemetery.Name = "btn_LoadCemetery";
            this.btn_LoadCemetery.Size = new System.Drawing.Size(194, 41);
            this.btn_LoadCemetery.TabIndex = 0;
            this.btn_LoadCemetery.Text = "Load Cemetery";
            this.btn_LoadCemetery.UseVisualStyleBackColor = true;
            this.btn_LoadCemetery.Click += new System.EventHandler(this.btn_LoadCemetery_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(759, 3);
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
            // col_FirstName
            // 
            this.col_FirstName.Text = "First Name";
            this.col_FirstName.Width = 100;
            // 
            // col_MiddleName
            // 
            this.col_MiddleName.Text = "Middle Name";
            this.col_MiddleName.Width = 75;
            // 
            // col_LastName
            // 
            this.col_LastName.Text = "Last Name";
            this.col_LastName.Width = 125;
            // 
            // col_Section
            // 
            this.col_Section.Text = "Section";
            this.col_Section.Width = 50;
            // 
            // col_GraveId
            // 
            this.col_GraveId.Text = "Grave Id";
            // 
            // col_DateOfDeath
            // 
            this.col_DateOfDeath.Text = "Date Of Death";
            this.col_DateOfDeath.Width = 100;
            // 
            // col_Notes
            // 
            this.col_Notes.Text = "Notes";
            this.col_Notes.Width = 100;
            // 
            // UC_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Tester);
            this.Controls.Add(this.lstv_Patrons);
            this.Name = "UC_Display";
            this.Size = new System.Drawing.Size(964, 666);
            this.pnl_Tester.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstv_Patrons;
        private System.Windows.Forms.Panel pnl_Tester;
        private System.Windows.Forms.Button btn_LoadCemetery;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader col_FirstName;
        private System.Windows.Forms.ColumnHeader col_MiddleName;
        private System.Windows.Forms.ColumnHeader col_LastName;
        private System.Windows.Forms.ColumnHeader col_Section;
        private System.Windows.Forms.ColumnHeader col_GraveId;
        private System.Windows.Forms.ColumnHeader col_DateOfDeath;
        private System.Windows.Forms.ColumnHeader col_Notes;
    }
}
