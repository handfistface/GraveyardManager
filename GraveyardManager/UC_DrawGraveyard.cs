using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraveyardManager
{
    public partial class UC_DrawGraveyard : UserControl
    {
        #region public UC_DrawGraveyard()
        public UC_DrawGraveyard()
        {
            InitializeComponent();
            picb_Canvas.Paint += Picb_Canvas_Paint;
        }
        #endregion public UC_DrawGraveyard()

        #region private void picb_CanvasPaint()
        private void Picb_Canvas_Paint(object sender, PaintEventArgs e)
        {
            //create a local version of the graphics object for the picture box
            Graphics g = e.Graphics;

            //draw a string on the picture box
            //g.DrawString("This is a diagonal line drawn on the control", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));
            //draw a line in the picture box
            //g.DrawLine(System.Drawing.Pens.Red, picb_Canvas.Left, picb_Canvas.Top, picb_Canvas.Right, picb_Canvas.Bottom);
        }
        #endregion private void picb_CanvasPaint()

        #region private void btn_Tester_Click()
        private void btn_Tester_Click(object sender, EventArgs e)
        {
            Graphics g = picb_Canvas.CreateGraphics();      //get the graphics to draw on the picture box
            g.DrawRectangle(Pens.Black, new Rectangle(new Point(20, 20), new Size(50, 25)));        //draw a new rectangle
        }
        #endregion private void btn_Tester_Click()
    }
}
