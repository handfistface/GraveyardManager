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
            this.btn_Undo = new System.Windows.Forms.Button();
            this.btn_MultiplePlots = new System.Windows.Forms.Button();
            this.txt_MultX = new System.Windows.Forms.TextBox();
            this.lbl_By = new System.Windows.Forms.Label();
            this.txt_MultY = new System.Windows.Forms.TextBox();
            this.btn_StopDrawing = new System.Windows.Forms.Button();
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
            this.btn_DrawRect.Location = new System.Drawing.Point(659, 35);
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
            // btn_Undo
            // 
            this.btn_Undo.Enabled = false;
            this.btn_Undo.Location = new System.Drawing.Point(659, 64);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(138, 23);
            this.btn_Undo.TabIndex = 5;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_MultiplePlots
            // 
            this.btn_MultiplePlots.Location = new System.Drawing.Point(659, 93);
            this.btn_MultiplePlots.Name = "btn_MultiplePlots";
            this.btn_MultiplePlots.Size = new System.Drawing.Size(138, 23);
            this.btn_MultiplePlots.TabIndex = 6;
            this.btn_MultiplePlots.Text = "Draw Multiple Plots";
            this.btn_MultiplePlots.UseVisualStyleBackColor = true;
            this.btn_MultiplePlots.Click += new System.EventHandler(this.btn_MultiplePlots_Click);
            // 
            // txt_MultX
            // 
            this.txt_MultX.Location = new System.Drawing.Point(659, 122);
            this.txt_MultX.Name = "txt_MultX";
            this.txt_MultX.Size = new System.Drawing.Size(60, 20);
            this.txt_MultX.TabIndex = 7;
            this.txt_MultX.Text = "2";
            // 
            // lbl_By
            // 
            this.lbl_By.AutoSize = true;
            this.lbl_By.Location = new System.Drawing.Point(721, 125);
            this.lbl_By.Name = "lbl_By";
            this.lbl_By.Size = new System.Drawing.Size(14, 13);
            this.lbl_By.TabIndex = 8;
            this.lbl_By.Text = "X";
            // 
            // txt_MultY
            // 
            this.txt_MultY.Location = new System.Drawing.Point(737, 122);
            this.txt_MultY.Name = "txt_MultY";
            this.txt_MultY.Size = new System.Drawing.Size(60, 20);
            this.txt_MultY.TabIndex = 9;
            this.txt_MultY.Text = "2";
            // 
            // btn_StopDrawing
            // 
            this.btn_StopDrawing.Location = new System.Drawing.Point(659, 6);
            this.btn_StopDrawing.Name = "btn_StopDrawing";
            this.btn_StopDrawing.Size = new System.Drawing.Size(138, 23);
            this.btn_StopDrawing.TabIndex = 10;
            this.btn_StopDrawing.Text = "Stop Drawing";
            this.btn_StopDrawing.UseVisualStyleBackColor = true;
            this.btn_StopDrawing.Click += new System.EventHandler(this.btn_StopDrawing_Click);
            // 
            // UC_DrawGraveyard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_StopDrawing);
            this.Controls.Add(this.txt_MultY);
            this.Controls.Add(this.lbl_By);
            this.Controls.Add(this.txt_MultX);
            this.Controls.Add(this.btn_MultiplePlots);
            this.Controls.Add(this.btn_Undo);
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
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Button btn_MultiplePlots;
        private System.Windows.Forms.TextBox txt_MultX;
        private System.Windows.Forms.Label lbl_By;
        private System.Windows.Forms.TextBox txt_MultY;
        private System.Windows.Forms.Button btn_StopDrawing;
    }
}
