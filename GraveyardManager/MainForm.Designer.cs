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
            this.uC_Display1 = new GraveyardManager.UC_Display();
            this.SuspendLayout();
            // 
            // uC_Display1
            // 
            this.uC_Display1.Location = new System.Drawing.Point(12, 57);
            this.uC_Display1.Name = "uC_Display1";
            this.uC_Display1.Size = new System.Drawing.Size(816, 671);
            this.uC_Display1.TabIndex = 0;
            // 
            // frm_GraveyardManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 740);
            this.Controls.Add(this.uC_Display1);
            this.Name = "frm_GraveyardManager";
            this.Text = "Graveyard Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Display uC_Display1;
    }
}

