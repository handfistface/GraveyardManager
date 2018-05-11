namespace GraveyardManager
{
    partial class UC_DrawGraveyard
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
            this.picb_Canvas = new System.Windows.Forms.PictureBox();
            this.btn_Tester = new System.Windows.Forms.Button();
            this.btn_DrawRect = new System.Windows.Forms.Button();
            this.rtxt_Graveyard = new System.Windows.Forms.RichTextBox();
            this.lbl_Cursor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picb_Canvas
            // 
            this.picb_Canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picb_Canvas.Location = new System.Drawing.Point(3, 3);
            this.picb_Canvas.Name = "picb_Canvas";
            this.picb_Canvas.Size = new System.Drawing.Size(650, 794);
            this.picb_Canvas.TabIndex = 0;
            this.picb_Canvas.TabStop = false;
            // 
            // btn_Tester
            // 
            this.btn_Tester.Location = new System.Drawing.Point(659, 638);
            this.btn_Tester.Name = "btn_Tester";
            this.btn_Tester.Size = new System.Drawing.Size(138, 23);
            this.btn_Tester.TabIndex = 1;
            this.btn_Tester.Text = "Tester";
            this.btn_Tester.UseVisualStyleBackColor = true;
            this.btn_Tester.Click += new System.EventHandler(this.btn_Tester_Click);
            // 
            // btn_DrawRect
            // 
            this.btn_DrawRect.Location = new System.Drawing.Point(659, 3);
            this.btn_DrawRect.Name = "btn_DrawRect";
            this.btn_DrawRect.Size = new System.Drawing.Size(138, 23);
            this.btn_DrawRect.TabIndex = 2;
            this.btn_DrawRect.Text = "Draw Plot";
            this.btn_DrawRect.UseVisualStyleBackColor = true;
            this.btn_DrawRect.Click += new System.EventHandler(this.btn_DrawRect_Click);
            // 
            // rtxt_Graveyard
            // 
            this.rtxt_Graveyard.Location = new System.Drawing.Point(659, 248);
            this.rtxt_Graveyard.Name = "rtxt_Graveyard";
            this.rtxt_Graveyard.Size = new System.Drawing.Size(138, 316);
            this.rtxt_Graveyard.TabIndex = 3;
            this.rtxt_Graveyard.Text = "";
            // 
            // lbl_Cursor
            // 
            this.lbl_Cursor.AutoSize = true;
            this.lbl_Cursor.Location = new System.Drawing.Point(659, 576);
            this.lbl_Cursor.Name = "lbl_Cursor";
            this.lbl_Cursor.Size = new System.Drawing.Size(35, 13);
            this.lbl_Cursor.TabIndex = 4;
            this.lbl_Cursor.Text = "label1";
            // 
            // UC_DrawGraveyard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Cursor);
            this.Controls.Add(this.rtxt_Graveyard);
            this.Controls.Add(this.btn_DrawRect);
            this.Controls.Add(this.btn_Tester);
            this.Controls.Add(this.picb_Canvas);
            this.Name = "UC_DrawGraveyard";
            this.Size = new System.Drawing.Size(800, 800);
            ((System.ComponentModel.ISupportInitialize)(this.picb_Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picb_Canvas;
        private System.Windows.Forms.Button btn_Tester;
        private System.Windows.Forms.Button btn_DrawRect;
        private System.Windows.Forms.RichTextBox rtxt_Graveyard;
        private System.Windows.Forms.Label lbl_Cursor;
    }
}
