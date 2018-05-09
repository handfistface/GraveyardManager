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
        #region UC_DrawGraveyard Variables
        private int i_DrawState;        //indicates the drawing state of the 
        private const int i_DSIdle = 0;     //Draw state that indicates an idle drawing state
        private const int i_DSSingleRect = 1;       //Draw state that indicates the user is drawing one rectangle at a time
        #endregion UC_DrawGraveyard Variables
        #region Graphics Variables
        private PictureBox picb_CommittedImage;     //The canvas after the user has made a change to it
        private Size sz_DefaultPlot = new Size(50, 25);     //default size of the plot
        #endregion Graphics Variables

        #region public UC_DrawGraveyard()
        /// <summary>
        /// This class creats a drawable canvas for the user to map the graveyard
        /// Also hooks to a few events that are required for drawing
        /// </summary>
        public UC_DrawGraveyard()
        {
            InitializeComponent();
            picb_Canvas.Paint += Picb_Canvas_Paint;     //hook to a picture box paint event
            picb_Canvas.MouseMove += UC_DrawGraveyard_MouseMove;       //hook to a mouse moving event
            picb_CommittedImage = new PictureBox();
            picb_CommittedImage.Size = picb_Canvas.Size;
            picb_CommittedImage.Location = picb_Canvas.Location;
        }
        #endregion public UC_DrawGraveyard()

        #region private void CopyPictureBox(PictureBox picb_Source, ref PictureBox picb_Dest)
        private void CopyPictureBox(PictureBox picb_Source, ref PictureBox picb_Dest)
        {
            picb_Dest.Image = new Bitmap(picb_Source.Width, picb_Source.Height);
            Graphics g = Graphics.FromImage(picb_Dest.Image);
            g.CopyFromScreen(PointToScreen(picb_Source.Location), new Point(0, 0), new Size(picb_Source.Width, picb_Source.Height));
        }
        #endregion private void CopyPictureBox()

        #region private void UC_DrawGraveyard_MouseMove(object sender, MouseEventArgs e)
        /// <summary>
        /// This callback gets thrown whenever a mouse move is detected on the picb_Canvas picture box
        /// This will be used to detect whenever the user wants to paint on the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_DrawGraveyard_MouseMove(object sender, MouseEventArgs e)
        {
            Point p_MousePos = e.Location;      //get the location that the mouse is in
            if(i_DrawState != i_DSIdle)
            {
                //then the user wants to draw on the canvas
                //then the mouse position is within the canvas bounds
                //start the ladder logic
                if (i_DrawState == i_DSSingleRect)
                {
                    //then a ghost plot needs placed on the screen
                    DrawGhostPlot(p_MousePos);
                }
            }
        }
        #endregion private void UC_DrawGraveyard_MouseMove()

        #region private void picb_CanvasPaint()
        private void Picb_Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;        //create a local version of the graphics object for the picture box
        }
        #endregion private void picb_CanvasPaint()

        #region private void btn_Tester_Click()
        private void btn_Tester_Click(object sender, EventArgs e)
        {
            Graphics g = picb_Canvas.CreateGraphics();      //get the graphics to draw on the picture box
            g.DrawRectangle(Pens.Black, new Rectangle(new Point(20, 20), new Size(50, 25)));        //draw a new rectangle
        }
        #endregion private void btn_Tester_Click()

        #region private void btn_DrawRect_Click()
        /// <summary>
        /// This method handles the button that is used for drawing a plot
        /// All this does is set a flag for the mouse move event
        /// Will also change the button text to indicate that the user can stop painting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DrawRect_Click(object sender, EventArgs e)
        {
            //if the draw state is sitting in an idle state...
            if(i_DrawState == i_DSIdle)
            {
                //then set the flag to indicate that the user wants to start drawing plots
                i_DrawState = i_DSSingleRect;
                //now flip the button to indicate that the user has an option to stop drawing
                btn_DrawRect.Text = "Stop Plotting";
            }
            else if (i_DrawState == i_DSSingleRect)
            {
                //then the flag indicates that the user is drawing a single plot
                //this means that the user wants to stop drawing
                i_DrawState = i_DSIdle;     //set the idle state
                //now flip the button to indicate that the user sees they have an option to start drawing again
                btn_DrawRect.Text = "Draw Plot";
            }
        }
        #endregion private void btn_DrawRect_Click()
        #region private void DrawGhostPlot(Point p_MousePos)
        /// <summary>
        /// DrawGhostPlot()
        /// This method gets the location of the mouse pointer and then draws a 
        /// ghost plot, which is a temporary plot that just gives the user an idea of where their plot is going to be drawn
        /// </summary>
        private void DrawGhostPlot(Point p_MousePos)
        {
            PictureBox picb_Temp = picb_CommittedImage;     //create a temporary image to draw on (not drawin on the active form because it would create a dragging effect)
            Graphics g = picb_Temp.CreateGraphics();        //create a graphics object which will be used to draw with 
            g.DrawRectangle(Pens.Black, new Rectangle(p_MousePos, sz_DefaultPlot));     //draw a rectangle at the current position
            picb_Canvas = picb_Temp;
            //CopyPictureBox(picb_Temp, ref picb_Canvas);
        }
        #endregion private void DrawGhostPlot(Point p_MousePos)
    }
}
