﻿namespace GraveyardManager
{
    partial class DebuggingUI
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
            this.btn_PatronIngestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PatronIngestion
            // 
            this.btn_PatronIngestion.Location = new System.Drawing.Point(12, 12);
            this.btn_PatronIngestion.Name = "btn_PatronIngestion";
            this.btn_PatronIngestion.Size = new System.Drawing.Size(142, 23);
            this.btn_PatronIngestion.TabIndex = 0;
            this.btn_PatronIngestion.Text = "Patron Ingestion";
            this.btn_PatronIngestion.UseVisualStyleBackColor = true;
            this.btn_PatronIngestion.Click += new System.EventHandler(this.btn_PatronIngestion_Click);
            // 
            // DebuggingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_PatronIngestion);
            this.Name = "DebuggingUI";
            this.Text = "DebuggingUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PatronIngestion;
    }
}