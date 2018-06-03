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
            this.tbc_MainControl = new System.Windows.Forms.TabControl();
            this.tbp_Drawing = new System.Windows.Forms.TabPage();
            this.btn_Resize = new System.Windows.Forms.Button();
            this.tbp_Graves = new System.Windows.Forms.TabPage();
            this.pnl_Canvas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Canvas)).BeginInit();
            this.tbc_MainControl.SuspendLayout();
            this.tbp_Drawing.SuspendLayout();
            this.pnl_Canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // picb_Canvas
            // 
            this.picb_Canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picb_Canvas.Location = new System.Drawing.Point(3, 3);
            this.picb_Canvas.Name = "picb_Canvas";
            this.picb_Canvas.Size = new System.Drawing.Size(800, 600);
            this.picb_Canvas.TabIndex = 0;
            this.picb_Canvas.TabStop = false;
            // 
            // btn_Tester
            // 
            this.btn_Tester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Tester.Location = new System.Drawing.Point(826, 419);
            this.btn_Tester.Name = "btn_Tester";
            this.btn_Tester.Size = new System.Drawing.Size(138, 23);
            this.btn_Tester.TabIndex = 1;
            this.btn_Tester.Text = "Tester";
            this.btn_Tester.UseVisualStyleBackColor = true;
            this.btn_Tester.Click += new System.EventHandler(this.btn_Tester_Click);
            // 
            // btn_DrawRect
            // 
            this.btn_DrawRect.Location = new System.Drawing.Point(6, 64);
            this.btn_DrawRect.Name = "btn_DrawRect";
            this.btn_DrawRect.Size = new System.Drawing.Size(141, 23);
            this.btn_DrawRect.TabIndex = 2;
            this.btn_DrawRect.Text = "Draw Plot";
            this.btn_DrawRect.UseVisualStyleBackColor = true;
            this.btn_DrawRect.Click += new System.EventHandler(this.btn_DrawRect_Click);
            // 
            // rtxt_Graveyard
            // 
            this.rtxt_Graveyard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt_Graveyard.Location = new System.Drawing.Point(826, 240);
            this.rtxt_Graveyard.Name = "rtxt_Graveyard";
            this.rtxt_Graveyard.Size = new System.Drawing.Size(138, 173);
            this.rtxt_Graveyard.TabIndex = 3;
            this.rtxt_Graveyard.Text = "";
            // 
            // lbl_Cursor
            // 
            this.lbl_Cursor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Cursor.AutoSize = true;
            this.lbl_Cursor.Location = new System.Drawing.Point(879, 210);
            this.lbl_Cursor.Name = "lbl_Cursor";
            this.lbl_Cursor.Size = new System.Drawing.Size(35, 13);
            this.lbl_Cursor.TabIndex = 4;
            this.lbl_Cursor.Text = "label1";
            // 
            // btn_Undo
            // 
            this.btn_Undo.Enabled = false;
            this.btn_Undo.Location = new System.Drawing.Point(6, 35);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(141, 23);
            this.btn_Undo.TabIndex = 5;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_MultiplePlots
            // 
            this.btn_MultiplePlots.Location = new System.Drawing.Point(6, 93);
            this.btn_MultiplePlots.Name = "btn_MultiplePlots";
            this.btn_MultiplePlots.Size = new System.Drawing.Size(141, 23);
            this.btn_MultiplePlots.TabIndex = 6;
            this.btn_MultiplePlots.Text = "Draw Multiple Plots";
            this.btn_MultiplePlots.UseVisualStyleBackColor = true;
            this.btn_MultiplePlots.Click += new System.EventHandler(this.btn_MultiplePlots_Click);
            // 
            // txt_MultX
            // 
            this.txt_MultX.Location = new System.Drawing.Point(6, 122);
            this.txt_MultX.Name = "txt_MultX";
            this.txt_MultX.Size = new System.Drawing.Size(60, 20);
            this.txt_MultX.TabIndex = 7;
            this.txt_MultX.Text = "2";
            // 
            // lbl_By
            // 
            this.lbl_By.AutoSize = true;
            this.lbl_By.Location = new System.Drawing.Point(70, 125);
            this.lbl_By.Name = "lbl_By";
            this.lbl_By.Size = new System.Drawing.Size(14, 13);
            this.lbl_By.TabIndex = 8;
            this.lbl_By.Text = "X";
            // 
            // txt_MultY
            // 
            this.txt_MultY.Location = new System.Drawing.Point(87, 122);
            this.txt_MultY.Name = "txt_MultY";
            this.txt_MultY.Size = new System.Drawing.Size(60, 20);
            this.txt_MultY.TabIndex = 9;
            this.txt_MultY.Text = "2";
            // 
            // btn_StopDrawing
            // 
            this.btn_StopDrawing.Location = new System.Drawing.Point(6, 6);
            this.btn_StopDrawing.Name = "btn_StopDrawing";
            this.btn_StopDrawing.Size = new System.Drawing.Size(141, 23);
            this.btn_StopDrawing.TabIndex = 10;
            this.btn_StopDrawing.Text = "Stop Drawing";
            this.btn_StopDrawing.UseVisualStyleBackColor = true;
            this.btn_StopDrawing.Click += new System.EventHandler(this.btn_StopDrawing_Click);
            // 
            // tbc_MainControl
            // 
            this.tbc_MainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_MainControl.Controls.Add(this.tbp_Drawing);
            this.tbc_MainControl.Controls.Add(this.tbp_Graves);
            this.tbc_MainControl.Location = new System.Drawing.Point(816, 3);
            this.tbc_MainControl.Name = "tbc_MainControl";
            this.tbc_MainControl.SelectedIndex = 0;
            this.tbc_MainControl.Size = new System.Drawing.Size(161, 204);
            this.tbc_MainControl.TabIndex = 11;
            // 
            // tbp_Drawing
            // 
            this.tbp_Drawing.Controls.Add(this.btn_Resize);
            this.tbp_Drawing.Controls.Add(this.btn_StopDrawing);
            this.tbp_Drawing.Controls.Add(this.txt_MultY);
            this.tbp_Drawing.Controls.Add(this.btn_Undo);
            this.tbp_Drawing.Controls.Add(this.lbl_By);
            this.tbp_Drawing.Controls.Add(this.btn_DrawRect);
            this.tbp_Drawing.Controls.Add(this.txt_MultX);
            this.tbp_Drawing.Controls.Add(this.btn_MultiplePlots);
            this.tbp_Drawing.Location = new System.Drawing.Point(4, 22);
            this.tbp_Drawing.Name = "tbp_Drawing";
            this.tbp_Drawing.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Drawing.Size = new System.Drawing.Size(153, 178);
            this.tbp_Drawing.TabIndex = 0;
            this.tbp_Drawing.Text = "Drawing";
            this.tbp_Drawing.UseVisualStyleBackColor = true;
            // 
            // btn_Resize
            // 
            this.btn_Resize.Location = new System.Drawing.Point(6, 149);
            this.btn_Resize.Name = "btn_Resize";
            this.btn_Resize.Size = new System.Drawing.Size(141, 23);
            this.btn_Resize.TabIndex = 11;
            this.btn_Resize.Text = "Resize Canvas";
            this.btn_Resize.UseVisualStyleBackColor = true;
            this.btn_Resize.Click += new System.EventHandler(this.btn_Resize_Click);
            // 
            // tbp_Graves
            // 
            this.tbp_Graves.Location = new System.Drawing.Point(4, 22);
            this.tbp_Graves.Name = "tbp_Graves";
            this.tbp_Graves.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Graves.Size = new System.Drawing.Size(153, 178);
            this.tbp_Graves.TabIndex = 1;
            this.tbp_Graves.Text = "Graves";
            this.tbp_Graves.UseVisualStyleBackColor = true;
            // 
            // pnl_Canvas
            // 
            this.pnl_Canvas.AutoScroll = true;
            this.pnl_Canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Canvas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnl_Canvas.Controls.Add(this.picb_Canvas);
            this.pnl_Canvas.Location = new System.Drawing.Point(3, 3);
            this.pnl_Canvas.Name = "pnl_Canvas";
            this.pnl_Canvas.Size = new System.Drawing.Size(809, 794);
            this.pnl_Canvas.TabIndex = 12;
            // 
            // UC_DrawGraveyard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Canvas);
            this.Controls.Add(this.tbc_MainControl);
            this.Controls.Add(this.lbl_Cursor);
            this.Controls.Add(this.rtxt_Graveyard);
            this.Controls.Add(this.btn_Tester);
            this.Name = "UC_DrawGraveyard";
            this.Size = new System.Drawing.Size(980, 800);
            this.Load += new System.EventHandler(this.UC_DrawGraveyard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picb_Canvas)).EndInit();
            this.tbc_MainControl.ResumeLayout(false);
            this.tbp_Drawing.ResumeLayout(false);
            this.tbp_Drawing.PerformLayout();
            this.pnl_Canvas.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tbc_MainControl;
        private System.Windows.Forms.TabPage tbp_Drawing;
        private System.Windows.Forms.TabPage tbp_Graves;
        private System.Windows.Forms.Button btn_Resize;
        private System.Windows.Forms.Panel pnl_Canvas;
    }
}
