namespace GraveyardManager
{
    partial class ResizeWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_WidthPix = new System.Windows.Forms.TextBox();
            this.txt_HeightPix = new System.Windows.Forms.TextBox();
            this.txt_WidthPerc = new System.Windows.Forms.TextBox();
            this.txt_HeightPerc = new System.Windows.Forms.TextBox();
            this.btn_Resize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            // 
            // txt_WidthPix
            // 
            this.txt_WidthPix.Location = new System.Drawing.Point(56, 6);
            this.txt_WidthPix.Name = "txt_WidthPix";
            this.txt_WidthPix.Size = new System.Drawing.Size(100, 20);
            this.txt_WidthPix.TabIndex = 2;
            // 
            // txt_HeightPix
            // 
            this.txt_HeightPix.Location = new System.Drawing.Point(56, 37);
            this.txt_HeightPix.Name = "txt_HeightPix";
            this.txt_HeightPix.Size = new System.Drawing.Size(100, 20);
            this.txt_HeightPix.TabIndex = 3;
            // 
            // txt_WidthPerc
            // 
            this.txt_WidthPerc.Location = new System.Drawing.Point(162, 6);
            this.txt_WidthPerc.Name = "txt_WidthPerc";
            this.txt_WidthPerc.Size = new System.Drawing.Size(58, 20);
            this.txt_WidthPerc.TabIndex = 4;
            // 
            // txt_HeightPerc
            // 
            this.txt_HeightPerc.Location = new System.Drawing.Point(162, 37);
            this.txt_HeightPerc.Name = "txt_HeightPerc";
            this.txt_HeightPerc.Size = new System.Drawing.Size(58, 20);
            this.txt_HeightPerc.TabIndex = 5;
            // 
            // btn_Resize
            // 
            this.btn_Resize.Location = new System.Drawing.Point(81, 63);
            this.btn_Resize.Name = "btn_Resize";
            this.btn_Resize.Size = new System.Drawing.Size(75, 23);
            this.btn_Resize.TabIndex = 6;
            this.btn_Resize.Text = "Resize";
            this.btn_Resize.UseVisualStyleBackColor = true;
            this.btn_Resize.Click += new System.EventHandler(this.btn_Resize_Click);
            // 
            // ResizeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 95);
            this.Controls.Add(this.btn_Resize);
            this.Controls.Add(this.txt_HeightPerc);
            this.Controls.Add(this.txt_WidthPerc);
            this.Controls.Add(this.txt_HeightPix);
            this.Controls.Add(this.txt_WidthPix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResizeWindow";
            this.Text = "Resize Canvas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_WidthPix;
        private System.Windows.Forms.TextBox txt_HeightPix;
        private System.Windows.Forms.TextBox txt_WidthPerc;
        private System.Windows.Forms.TextBox txt_HeightPerc;
        private System.Windows.Forms.Button btn_Resize;
    }
}