﻿namespace GraveyardManager
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
            this.col_FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_MiddleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Section = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_GraveId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_DateOfDeath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Notes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_Buttons = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_TestSql = new System.Windows.Forms.Button();
            this.pnl_Debug = new System.Windows.Forms.Panel();
            this.btn_SetupDB = new System.Windows.Forms.Button();
            this.btn_LoadCleansedFile = new System.Windows.Forms.Button();
            this.pnl_Buttons.SuspendLayout();
            this.pnl_Debug.SuspendLayout();
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
            this.lstv_Patrons.Size = new System.Drawing.Size(795, 660);
            this.lstv_Patrons.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstv_Patrons.TabIndex = 0;
            this.lstv_Patrons.UseCompatibleStateImageBehavior = false;
            this.lstv_Patrons.View = System.Windows.Forms.View.Details;
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
            // pnl_Buttons
            // 
            this.pnl_Buttons.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl_Buttons.Controls.Add(this.btn_Add);
            this.pnl_Buttons.Location = new System.Drawing.Point(807, 3);
            this.pnl_Buttons.Name = "pnl_Buttons";
            this.pnl_Buttons.Size = new System.Drawing.Size(155, 116);
            this.pnl_Buttons.TabIndex = 2;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(3, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(149, 23);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_TestSql
            // 
            this.btn_TestSql.Location = new System.Drawing.Point(3, 3);
            this.btn_TestSql.Name = "btn_TestSql";
            this.btn_TestSql.Size = new System.Drawing.Size(146, 23);
            this.btn_TestSql.TabIndex = 3;
            this.btn_TestSql.Text = "Test SQL";
            this.btn_TestSql.UseVisualStyleBackColor = true;
            this.btn_TestSql.Click += new System.EventHandler(this.btn_TestSql_Click);
            // 
            // pnl_Debug
            // 
            this.pnl_Debug.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl_Debug.Controls.Add(this.btn_LoadCleansedFile);
            this.pnl_Debug.Controls.Add(this.btn_SetupDB);
            this.pnl_Debug.Controls.Add(this.btn_TestSql);
            this.pnl_Debug.Location = new System.Drawing.Point(804, 509);
            this.pnl_Debug.Name = "pnl_Debug";
            this.pnl_Debug.Size = new System.Drawing.Size(152, 154);
            this.pnl_Debug.TabIndex = 4;
            // 
            // btn_SetupDB
            // 
            this.btn_SetupDB.Location = new System.Drawing.Point(3, 32);
            this.btn_SetupDB.Name = "btn_SetupDB";
            this.btn_SetupDB.Size = new System.Drawing.Size(146, 23);
            this.btn_SetupDB.TabIndex = 4;
            this.btn_SetupDB.Text = "Setup DB";
            this.btn_SetupDB.UseVisualStyleBackColor = true;
            this.btn_SetupDB.Click += new System.EventHandler(this.btn_SetupDB_Click);
            // 
            // btn_LoadCleansedFile
            // 
            this.btn_LoadCleansedFile.Location = new System.Drawing.Point(3, 61);
            this.btn_LoadCleansedFile.Name = "btn_LoadCleansedFile";
            this.btn_LoadCleansedFile.Size = new System.Drawing.Size(146, 23);
            this.btn_LoadCleansedFile.TabIndex = 1;
            this.btn_LoadCleansedFile.Text = "Load Cleansed File";
            this.btn_LoadCleansedFile.UseVisualStyleBackColor = true;
            this.btn_LoadCleansedFile.Click += new System.EventHandler(this.btn_LoadCleansedFile_Click);
            // 
            // UC_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnl_Debug);
            this.Controls.Add(this.pnl_Buttons);
            this.Controls.Add(this.lstv_Patrons);
            this.Name = "UC_Display";
            this.Size = new System.Drawing.Size(965, 666);
            this.pnl_Buttons.ResumeLayout(false);
            this.pnl_Debug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstv_Patrons;
        private System.Windows.Forms.Panel pnl_Buttons;
        private System.Windows.Forms.ColumnHeader col_FirstName;
        private System.Windows.Forms.ColumnHeader col_MiddleName;
        private System.Windows.Forms.ColumnHeader col_LastName;
        private System.Windows.Forms.ColumnHeader col_Section;
        private System.Windows.Forms.ColumnHeader col_GraveId;
        private System.Windows.Forms.ColumnHeader col_DateOfDeath;
        private System.Windows.Forms.ColumnHeader col_Notes;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_TestSql;
        private System.Windows.Forms.Panel pnl_Debug;
        private System.Windows.Forms.Button btn_SetupDB;
        private System.Windows.Forms.Button btn_LoadCleansedFile;
    }
}
