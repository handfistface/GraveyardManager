namespace GraveyardManager
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
            this.rtxt_Debug = new System.Windows.Forms.RichTextBox();
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
            // rtxt_Debug
            // 
            this.rtxt_Debug.Location = new System.Drawing.Point(12, 122);
            this.rtxt_Debug.Name = "rtxt_Debug";
            this.rtxt_Debug.Size = new System.Drawing.Size(776, 316);
            this.rtxt_Debug.TabIndex = 1;
            this.rtxt_Debug.Text = "";
            // 
            // DebuggingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtxt_Debug);
            this.Controls.Add(this.btn_PatronIngestion);
            this.Name = "DebuggingUI";
            this.Text = "DebuggingUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PatronIngestion;
        private System.Windows.Forms.RichTextBox rtxt_Debug;
    }
}