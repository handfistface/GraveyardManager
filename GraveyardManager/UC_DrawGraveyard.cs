using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Media;

namespace GraveyardManager
{
    public partial class UC_DrawGraveyard : UserControl
    {
        #region UC_DrawGraveyard Variables
        private int i_DrawState;        //indicates the drawing state of the canvas
        private const int i_DSIdle = 0;     //Draw state that indicates an idle drawing state
        private const int i_DSSingleRect = 1;       //Draw state that indicates the user is drawing one rectangle at a time
        private const int i_DSMultiRect = 2;        //draw that that indicates the user is dawing multiple rectangles at a time
        private ResizeWindow rw = null;     //used to resize the canvas
        #endregion UC_DrawGraveyard Variables
        #region Graphics Variables
        private PictureBox picb_CommittedImage;     //The canvas after the user has made a change to it
        private Size sz_DefaultPlot = new Size(50, 25);     //default size of the plot
        private Stack<Point> post_Rects;      //the stack of rectangle origin points
        private const int i_GCIterMax = 50;      //the maximum count i_GCIteration is allowed to reach before running GC.Collect()
        private int i_GCIteration;        //counter that how many iterations before GC.Collect is run (bitmaps are scary)
        private const int i_Spacing = 2;      //pixel spacing between the plots
        private const int i_Snapping = 10;     //number of pixels within a line to snap to
        #endregion Graphics Variables
        #region Undo Variables
        private int i_UndoMaxStack = 11;     //max amount of undo's before the stack dries up
        private Stack<PictureBox> spicb_Undo;       //a stack of picture boxes used to revert the canvas (post_Rects needs 
        private Stack<int> ist_PlotsAdded;      //how many plots are added at a time?
        #endregion Undo Variables

        #region public UC_DrawGraveyard()
        /// <summary>
        /// This class creats a drawable canvas for the user to map the graveyard
        /// Also hooks to a few events that are required for drawing
        /// </summary>
        public UC_DrawGraveyard()
        {
            InitializeComponent();
            post_Rects = new Stack<Point>();      //create a new list of points
            spicb_Undo = new Stack<PictureBox>();       //create a new stack for the picture box
            ist_PlotsAdded = new Stack<int>();      //create a new stack which keeps track of how many plots are added at once
            i_GCIteration = 0;      //set the counter to 0
            picb_Canvas.Paint += Picb_Canvas_Paint;     //hook to a picture box paint event
            picb_Canvas.MouseMove += UC_DrawGraveyard_MouseMove;       //hook to a mouse moving event
            picb_Canvas.MouseLeave += Picb_Canvas_MouseLeave;
            picb_Canvas.MouseClick += Picb_Canvas_MouseClick;
            txt_MultX.TextChanged += Txt_MultX_TextChanged;
            txt_MultY.TextChanged += Txt_MultY_TextChanged;
            System.Timers.Timer t_Init = new System.Timers.Timer();     //use a timer for the initialization because this thing is finicky
            t_Init.Elapsed += T_Init_Elapsed;
            t_Init.Interval = 500;
            t_Init.AutoReset = false;       //make sure this timer doesn't reset itself automatically
            t_Init.Start();
        }

        private void T_Init_Elapsed(object sender, ElapsedEventArgs e)
        {
            Util.Init(rtxt_Graveyard);      //setup util to print to the graveyard text box
            //make sure the interface access is thread safe
            if (picb_Canvas.InvokeRequired)
            {
                //then this thread is not the thread the interface was created on, it will need a delegate
                picb_Canvas.Invoke((MethodInvoker)delegate
                {
                    picb_Canvas.Image = new Bitmap(picb_Canvas.Width, picb_Canvas.Height);
                    Graphics g = Graphics.FromImage(picb_Canvas.Image);
                    picb_CommittedImage = new PictureBox();
                    picb_CommittedImage.Image = (Image)picb_Canvas.Image.Clone();
                });
            }
            else
            {
                //otherwise it is fine to regularly access the canvas
                picb_Canvas.Image = new Bitmap(picb_Canvas.Width, picb_Canvas.Height);
                Graphics g = picb_Canvas.CreateGraphics();
                picb_Canvas.Update();
                picb_CommittedImage = new PictureBox();
                picb_CommittedImage.Image = (Image)picb_Canvas.Image.Clone();
            }
        }
        #endregion public UC_DrawGraveyard()

        #region private void Picb_Canvas_MouseClick(object sender, MouseEventArgs e)
        /// <summary>
        /// This method will be used for detecting when a user clicks in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picb_Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            Point p_MousePos = e.Location;      //get the location that the mouse is in
            if (i_DrawState != i_DSIdle)
            {
                //then the user wants to draw on the canvas
                //then the mouse position is within the canvas bounds
                //start the ladder logic
                if (i_DrawState == i_DSSingleRect)
                {
                    //then a plot needs placed on the screen
                    CommitPlot(p_MousePos);     //commit a single plot based on the mouse location
                }
                else if (i_DrawState == i_DSMultiRect)
                {
                    //then a multi dimensional plot needs placed on the screen
                    CommitMultiPlot(p_MousePos);        //commit multiple plots based on the mouse location
                }
            }
        }
        #endregion private void Picb_Canvas_MouseClick(object sender, MouseEventArgs e)
        #region private void Picb_Canvas_MouseLeave(object sender, EventArgs e)
        /// <summary>
        /// picb_Canvas_MouseLeave()
        /// This method will revert the drawable canvas to a committed image whenever the mouse leaves the screen
        /// Will get called whenever the mouse leaves the screen (initialized through the class constructor)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picb_Canvas_MouseLeave(object sender, EventArgs e)
        {
            //null sanity check before reverting the image (necessary for startup)
            if(picb_CommittedImage != null && picb_Canvas != null && 
                picb_CommittedImage.Image != null && picb_Canvas.Image != null)
                picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //revert the canvas back to the committed image
        }
        #endregion private void Picb_Canvas_MouseLeave(object sender, EventArgs e)

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
                else if (i_DrawState == i_DSMultiRect)
                {
                    //then multiple ghost plots need placed on the screen
                    DrawMultiGhostPlot(p_MousePos);
                }
            }
            //update the label indicating the mouse position
            if(lbl_Cursor.InvokeRequired)
            {
                //then this is a cross thread access
                lbl_Cursor.Invoke((MethodInvoker)delegate
                {
                    lbl_Cursor.Text = "(" + p_MousePos.X + ", " + p_MousePos.Y + ")";
                });
            }
            else
            {
                //then this is a standard access to the lable
                lbl_Cursor.Text = "(" + p_MousePos.X + ", " + p_MousePos.Y + ")";
            }
        }
        #endregion private void UC_DrawGraveyard_MouseMove()

        #region private void picb_Canvas_Paint()
        private void Picb_Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;        //create a local version of the graphics object for the picture box
        }
        #endregion private void picb_Canvas_Paint()

        #region private void btn_Tester_Click()
        private void btn_Tester_Click(object sender, EventArgs e)
        {
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone the committed image in memory so we're working off a fresh copy
            Graphics g = Graphics.FromImage(picb_Canvas.Image);     //create a graphics that will draw on the canvas image
            g.FillRectangle(Brushes.Green, new Rectangle(new Point(20, 20), new Size(50, 25)));        //draw a new rectangle
        }
        #endregion private void btn_Tester_Click()

        #region private void btn_Undo_Click()
        /// <summary>
        /// btn_Undo_Click()
        /// This will pop an item off the stack of picture boxes and reassign the committed picture box
        /// If the stack empties itself then it will disable the button
        /// The button will be re-enabled on a CommitPlot() call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Undo_Click(object sender, EventArgs e)
        {
            int i_PlotsToPop = ist_PlotsAdded.Pop();        //how many plots were added in the last commit?
            PictureBox picb_Popped = spicb_Undo.Pop();      //pop off a picture box from the stack of undo picture boxes
            //pop off a rect off the stack based on how many items there were to pop off
            for(int i=0; i < i_PlotsToPop; i++)
                post_Rects.Pop();        //pop the last drawn plot off the stack
            picb_CommittedImage.Image = (Image)picb_Popped.Image.Clone();
            //is this update a cross threaded access?
            if (picb_Canvas.InvokeRequired)
            {
                //then a cross thread access is being requested
                picb_Canvas.Invoke((MethodInvoker)delegate
                {
                    picb_Canvas.Image = (Image)picb_Popped.Image.Clone();
                });
            }
            else
            {
                picb_Canvas.Image = (Image)picb_Popped.Image.Clone();
            }
            //has the beginning of the stack been reached?
            if (ist_PlotsAdded.Count <= 0)
                btn_Undo.Enabled = false;       //then the stack is exhausted, disable the button to prevent any further pops
        }
        #endregion private void btn_Undo_Click()

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
            if(i_DrawState != i_DSSingleRect || i_DrawState != i_DSIdle)
            {
                StopDrawing();
                //then set the flag to indicate that the user wants to start drawing plots
                i_DrawState = i_DSSingleRect;
                //now flip the button to indicate that the user has an option to stop drawing
                btn_DrawRect.BackColor = Color.DarkGray;
            }
            else
            {
                //then the flag indicates that the user is drawing a single plot
                //this means that the user wants to stop drawing
                StopDrawing();
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
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone the committed image in memory so we're working off a fresh copy
            Graphics g = Graphics.FromImage(picb_Canvas.Image);     //create a graphics that will draw on the canvas image
            Pen pen;       //used for colouring the rectangle that will be drawn as a ghost
            p_MousePos = SnapOrigin(p_MousePos);
            if (IsWithinPlot(p_MousePos))
                pen = Pens.Red;     //the color needs to be red if we're intersecting a grave
            else
                pen = Pens.Gray;        //otherwise the cursor doesn't intersect another plot
            g.DrawRectangle(pen, new Rectangle(p_MousePos, sz_DefaultPlot));     //draw a rectangle at the current position
            i_GCIteration++;        //increment the garbage collection counter
            if(i_GCIteration >= i_GCIterMax)
            {
                GC.Collect();
                i_GCIteration = 0;
            }
        }
        #endregion private void DrawGhostPlot(Point p_MousePos)
        #region private void CommitPlot(Point p_MousePos)
        /// <summary>
        /// This method is called whenever a user clicks on the drawing canvas
        /// All that this does is commit the location of the rectangle on the canvas 
        /// and add it to a list of points which are used for 
        /// </summary>
        /// <param name="p_MousePos"></param>
        private void CommitPlot(Point p_MousePos)
        {
            p_MousePos = SnapOrigin(p_MousePos);
            //don't save the plot position onto the canvas if we're intersecting another plot
            if (IsWithinPlot(p_MousePos))
            {
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                {
                    sp_Bonk.Play();
                }
                //return so that the plot is not committed
                return;
            }
            //otherwise its fine to draw on the canvas
            //create a canvas and push it onto the stack before doing any modificiations
            PictureBox picb_Stack = new PictureBox();
            picb_Stack.Image = (Image)picb_CommittedImage.Image.Clone();        //clone the image onto the new stack entry
            spicb_Undo.Push(picb_Stack);        ///push a new entry onto the stack
            Graphics g = Graphics.FromImage(picb_CommittedImage.Image);     //get the graphics from the committed image because now this image needs modified
            g.DrawRectangle(Pens.Black, new Rectangle(p_MousePos, sz_DefaultPlot));     //draw a rectangle on the point we're looking at
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone that sucker onto the canvas that's being displayed
            post_Rects.Push(p_MousePos);      //add the point to the list of rectangle points
            ist_PlotsAdded.Push(1);     //there has only been 1 added plot
            //has the btn_Undo button been disabled?
            if (!btn_Undo.Enabled)
                btn_Undo.Enabled = true;        //then the button was disabled, re-enable it
        }
        #endregion private void CommitPlot(Point p_MousePos)

        #region private Point SnapOrigin(Point p)
        /// <summary>
        /// SnapOrigin()
        /// This method will take a an unmodified point and figure out a new point to place the origin at
        /// Bases the new point on a previously existing plot
        /// </summary>
        /// <param name="p">The unmodified point of the mouse pointer</param>
        /// <returns>A modified point of where to snap the rectangle, if the point is not near another plot then this will return the point argument</returns>
        private Point SnapOrigin(Point p)
        {
            Point p_Mod = p;      //create a new point
            //loop through each plot in pol_Rects
            foreach (Point p_Origin in post_Rects)
            {
                //are we near the left side of the rectangle?
                if( (p.Y >= p_Origin.Y - i_Snapping) && 
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X - sz_DefaultPlot.Width - i_Spacing, p_Origin.Y);
                    break;
                }
                //are we near the right side of the rectangle?
                if ((p.Y >= p_Origin.Y - i_Snapping) &&
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X + sz_DefaultPlot.Width - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X + sz_DefaultPlot.Width + i_Spacing, p_Origin.Y);
                    break;
                }
                //are we near the top side of the rectangle?
                if ((p.Y >= p_Origin.Y - i_Snapping) &&
                    (p.Y <= p_Origin.Y + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X, p_Origin.Y - sz_DefaultPlot.Height - i_Spacing);
                    break;
                }
                //are we near the bottom side of the rectangle? 
                if ((p.Y >= p_Origin.Y + sz_DefaultPlot.Height - i_Snapping) &&
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X, p_Origin.Y + sz_DefaultPlot.Height + i_Spacing);
                    break;
                }
            }
            return p_Mod;       //return the new modified origin point
        }
        #endregion private Point SnapOrigin(Point p)
        #region private Point SnapOrigin(Point p, Size sz_NewPlots)
        /// <summary>
        /// SnapOrigin()
        /// This method will take a an unmodified point and figure out a new point to place the origin at
        /// Bases the new point on an existing plot
        /// </summary>
        /// <param name="p">The unmodified point of the mouse pointer</param>
        /// <returns>A modified point of where to snap the rectangle, if the point is not near another plot then this will return the point argument</returns>
        private Point SnapOrigin(Point p, Size sz_NewPlots)
        {
            Point p_Mod = p;      //create a new point
            //loop through each plot in pol_Rects
            foreach (Point p_Origin in post_Rects)
            {
                //are we near the top left side of the rectangle?
                if ((p.Y >= p_Origin.Y - i_Snapping) &&
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X - sz_NewPlots.Width - i_Spacing, p_Origin.Y);
                    break;
                }
                //are we near the right side of the rectangle?
                if ((p.Y >= p_Origin.Y - i_Snapping) &&
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X + sz_DefaultPlot.Width - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X + sz_DefaultPlot.Width + i_Spacing, p_Origin.Y);
                    break;
                }
                //are we near the top side of the rectangle?
                if ((p.Y >= p_Origin.Y - i_Snapping) &&
                    (p.Y <= p_Origin.Y + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X, p_Origin.Y - sz_NewPlots.Height - i_Spacing);
                    break;
                }
                //are we near the bottom side of the rectangle? 
                if ((p.Y >= p_Origin.Y + sz_DefaultPlot.Height - i_Snapping) &&
                    (p.Y <= p_Origin.Y + sz_DefaultPlot.Height + i_Snapping) &&
                    (p.X >= p_Origin.X - i_Snapping) &&
                    (p.X <= p_Origin.X + sz_DefaultPlot.Width + i_Snapping)
                  )
                {
                    p_Mod = new Point(p_Origin.X, p_Origin.Y + sz_DefaultPlot.Height + i_Spacing);
                    break;
                }
            }
            return p_Mod;       //return the new modified origin point
        }
        #endregion private Point SnapOrigin(Point p, Size sz_NewPlot)

        #region private bool IsWithinPlot(Point p)
        /// <summary>
        /// This method detects if a point is inside of a plot
        /// This will be used for a number of applications like changing color of the ghost rectangle
        /// Or will be used for identifying The GraveId the user clicks on
        /// </summary>
        /// <param name="p">The origin point being examined</param>
        /// <returns></returns>
        private bool IsWithinPlot(Point p)
        {
            bool b_Inside = false;      //indicates whether the point falls inside a grave
            //every single grave must be processed to determine if the point argument is inside
            foreach(Point p_GraveOrigin in post_Rects)
            {
                //catch the origin point
                if(p.X >= p_GraveOrigin.X &&
                   p.X <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the top right
                if (p.X + sz_DefaultPlot.Width >= p_GraveOrigin.X &&
                   p.X + sz_DefaultPlot.Width <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the bottom left
                if (p.X + sz_DefaultPlot.Width >= p_GraveOrigin.X &&
                   p.X + sz_DefaultPlot.Width <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the bottom right
                if (p.X + sz_DefaultPlot.Width >= p_GraveOrigin.X &&
                   p.X + sz_DefaultPlot.Width <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y + sz_DefaultPlot.Height >= p_GraveOrigin.Y &&
                   p.Y + sz_DefaultPlot.Height <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
            }
            return b_Inside;        //return the flag indicating if the point is within a grave
        }
        #endregion private bool IsWithinPlot(Point p)
        #region private bool IsWithinPlot(Point p, Size sz_PlotSize
        /// <summary>
        /// IsWithinPlot()
        /// This method will examine if a point and a size have any intersecting points
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sz_PlotSize"></param>
        /// <returns></returns>
        private bool IsWithinPlot(Point p, Size sz_PlotSize)
        {
            bool b_Inside = false;      //indicates whether the point falls inside a grave
            //every single grave must be processed to determine if the point argument is inside
            foreach (Point p_GraveOrigin in post_Rects)
            {
                //catch the origin point
                if (p.X >= p_GraveOrigin.X &&
                   p.X <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the top right
                if (p.X + sz_PlotSize.Width >= p_GraveOrigin.X &&
                   p.X + sz_PlotSize.Width <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the bottom left
                if (p.X >= p_GraveOrigin.X &&
                   p.X <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y + sz_PlotSize.Height >= p_GraveOrigin.Y &&
                   p.Y + sz_PlotSize.Height <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
                //catch the bottom right
                if (p.X + sz_PlotSize.Width >= p_GraveOrigin.X &&
                   p.X + sz_PlotSize.Width <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y + sz_PlotSize.Height >= p_GraveOrigin.Y &&
                   p.Y + sz_PlotSize.Height <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
            }
            return b_Inside;
        }
        #endregion private bool IsWithinPlot(Point p, Size sz_PlotSize

        #region private void btn_MultiplePlots_Click()
        /// <summary>
        /// This button will handle turning on drawing multiple plots at a time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MultiplePlots_Click(object sender, EventArgs e)
        {
            //if the draw state is sitting in an idle state...
            if (i_DrawState != i_DSMultiRect || i_DrawState != i_DSIdle)
            {
                StopDrawing();
                //then set the flag to indicate that the user wants to start drawing plots
                i_DrawState = i_DSMultiRect;
                //now flip the button to indicate that the user has an option to stop drawing
                btn_MultiplePlots.BackColor = Color.DarkGray;
            }
            else
            {
                //then the flag indicates that the user is drawing a single plot
                //this means that the user wants to stop drawing
                StopDrawing();
            }
        }
        #endregion private void btn_MultiplePlots_Click()
        #region private void txt_MultX_TextChanged()
        /// <summary>
        /// txt_MultX_TextChanged()
        /// Handles cleaning the input on the X text box
        /// Makes sure the input isn't too large and is an integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_MultX_TextChanged(object sender, EventArgs e)
        {
            //call the CleanseMultiDrawTextBox() method to cleanse the txt_MultX text box
            CleanseMultiDrawTextBox(txt_MultX);
        }
        #endregion private void txt_MultX_TextChanged()
        #region private void txt_MultY_TextChanged()
        /// <summary>
        /// txt_MultY_TextChanged()
        /// Handles cleaning the input on the Y text box
        /// Makes sure the input isn't too large and is an integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_MultY_TextChanged(object sender, EventArgs e)
        {
            //call the CleanseMultiDrawTextBox() method to cleanse the txt_MultY text box
            CleanseMultiDrawTextBox(txt_MultY);
        }
        #endregion private void txt_MultY_TextChanged()
        #region private void CleanseMultiDrawTextBox(TextBox txt)
        /// <summary>
        /// CleanseMultiDrawTextBox()
        /// Cleans up the input on a text box 
        /// </summary>
        /// <param name="txt"></param>
        private void CleanseMultiDrawTextBox(TextBox txt)
        {
            int i_Max = 10;     //the max value that the text box is allowed to have
            if (txt.Text.Length < 1)
                return;         //then there's nothing to parse
            //since this is run every time all we have to do is look at the last digit of the text box
            string s_NewText = "";       //the new text of the text box
            //if the character is not a valid integer...
            foreach (char c in txt.Text)
            {
                //bound the character 
                if (!(c >= '0' && c <= '9'))
                {
                    //then the character is not in a valid range
                    //prevent the character from being added onto the end of s_NewText
                }
                else
                {
                    //otherwise this is just a regular character
                    s_NewText += c;
                }
            }
            //does the new text == the old text?
            if(s_NewText != txt.Text)
            {
                //then the new text does not equal the old text, it will need updated
                //make sure to make the text box access thread safe
                if (txt.InvokeRequired)
                {
                    //then this is a cross thread access, invoke a delegate
                    txt.Invoke((MethodInvoker)delegate
                    {
                        txt.Text = s_NewText;       //update the text
                        txt.SelectionStart = txt.Text.Length;
                    });
                }
                else
                {
                    //then invoking is not required
                    txt.Text = s_NewText;
                    txt.SelectionStart = txt.Text.Length;
                }
                //now play a sound so the user knows they've done something wrong
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                {
                    sp_Bonk.Play();
                }
            }
            //now that any invalid characters are parsed out, any values that are too high must be parsed out and prevented
            int i_Parsed;       //used to hold a parse result
            if(int.TryParse(txt.Text, out i_Parsed))
            {
                //has the max value for the text box been exceeded
                if(i_Parsed > i_Max)
                {
                    //then the max value for the text box has been exceeded
                    //the value must be updated to max value, check for a cross thread access
                    if(txt.InvokeRequired)
                    {
                        //then this is a cross thread access and invoke is required
                        txt.Invoke((MethodInvoker)delegate
                        {
                            txt.Text = i_Max.ToString();       //set the text to the maximum value
                            txt.SelectionStart = txt.Text.Length;
                        });
                    }
                    else
                    {
                        //otherwise cross threading access is not required
                        txt.Text = i_Max.ToString();        //set the text to the maximum value
                        txt.SelectionStart = txt.Text.Length;
                    }
                    //now play a sound so the user knows they've done something wrong
                    using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                    {
                        sp_Bonk.Play();
                    }
                }
            }
        }
        #endregion private void CleanseMultiDrawTextBox(TextBox txt)
        #region private void DrawMultiGhostPlot(Point p_MousePos)
        /// <summary>
        /// DrawMultiGhostPlot()
        /// This method builds on top of DrawGhostPlot() and draws a multi-dimension plot
        /// If there are any interections this method will prevent the drawing
        /// </summary>
        /// <param name="p_MousePos">The origin point at which to draw the ghost plot</param>
        private void DrawMultiGhostPlot(Point p_MousePos)
        {
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone the committed image in memory so we're working off a fresh copy
            Graphics g = Graphics.FromImage(picb_Canvas.Image);
            Pen pen;        //used for colouring the rectangle that will be drawn as a ghost
            int i_XDim = int.Parse(txt_MultX.Text);     //get the x dimension
            int i_YDim = int.Parse(txt_MultY.Text);     //get the y dimension
            //calculate the end drawing point for the x and y dimensions
            int i_XEndDim = p_MousePos.X + i_XDim * sz_DefaultPlot.Width + i_XDim * i_Spacing - i_Spacing;       //calculate the end point for the x dimension
            int i_YEndDim = p_MousePos.Y + i_YDim * sz_DefaultPlot.Height + i_YDim * i_Spacing - i_Spacing;      //calculate the end point for the y dimension
            Size sz_FullMultiDimSize = new Size(i_XEndDim - p_MousePos.X, i_YEndDim - p_MousePos.Y);      //calculate the size of the full plot
            Point p_Mod = SnapOrigin(p_MousePos, sz_FullMultiDimSize);
            //now make sure that the drawing point does not have any plots that exist within its boundaries, if it does then highlight all of the boxes red
            if (IsWithinPlot(p_Mod, sz_FullMultiDimSize))
                pen = Pens.Red;
            else
                pen = Pens.Gray;
            //for each x dimension
            for (int x = 0; x < i_XDim; x++)
            {
                //for each y dimension
                for(int y = 0; y < i_YDim; y++)
                {
                    //calculate the origin of the rectangle
                    Point p_Org = new Point();
                    p_Org.X = p_Mod.X + sz_DefaultPlot.Width * x + i_Spacing * x;
                    p_Org.Y = p_Mod.Y + sz_DefaultPlot.Height * y + i_Spacing * y;
                    g.DrawRectangle(pen, new Rectangle(p_Org, sz_DefaultPlot));        //draw a rectangle at the current position
                }
            }
            i_GCIteration++;        //increment the garbage collection counter
            //if the garbage collection iteration counter indicates that the GC needs run...
            if(i_GCIteration >= i_GCIterMax)
            {
                GC.Collect();
                i_GCIteration = 0;
            }
        }
        #endregion privaet void DrawMultiGhostPlot(Point p_MousePos)
        #region private void CommitMultiPlot(Point p)
        /// <summary>
        /// CommitMultiPlot()
        /// Commits a user click to the canvas whenever the user is in the drawing state of drawing multiple plots
        /// </summary>
        /// <param name="p"></param>
        private void CommitMultiPlot(Point p)
        {
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone the committed image in memory so we're working off a fresh copy
            Graphics g = Graphics.FromImage(picb_Canvas.Image);     //get the graphics from the canvas
            int i_XDim = int.Parse(txt_MultX.Text);     //get the x dimension
            int i_YDim = int.Parse(txt_MultY.Text);     //get the y dimension
            //calculate the end drawing point for the x and y dimensions
            int i_XEndDim = p.X + i_XDim * sz_DefaultPlot.Width + i_XDim * i_Spacing - i_Spacing;       //calculate the end point for the x dimension
            int i_YEndDim = p.Y + i_YDim * sz_DefaultPlot.Height + i_YDim * i_Spacing - i_Spacing;      //calculate the end point for the y dimension
            Size sz_FullMultiDimSize = new Size(i_XEndDim - p.X, i_YEndDim - p.Y);      //calculate the size of the full plot
            Point p_Mod = SnapOrigin(p, sz_FullMultiDimSize);
            //now make sure that the drawing point does not have any plots that exist within its boundaries
            bool b_InsideAnotherPlot = IsWithinPlot(p_Mod, sz_FullMultiDimSize);
            if (b_InsideAnotherPlot)
            {
                //then the plot is within another plot, prevent the user from drawing here and play a windows bing
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                {
                    sp_Bonk.Play();
                }
                return;     //return from the method without letting the user draw since there will be overlap
            }
            //otherwise it is fine to draw the actual plot
            //first push the canvas onto the undo stack
            PictureBox picb_Stack = new PictureBox();       //create a new picture box which will go onto the top of the undo stack
            picb_Stack.Image = (Image)picb_Canvas.Image.Clone();        //copy the image of the canvas onto the stack picturebox
            spicb_Undo.Push(picb_Stack);        //finally push the new image onto the top of the stack
            //for each x dimension
            for (int x = 0; x < i_XDim; x++)
            {
                //for each y dimension
                for (int y = 0; y < i_YDim; y++)
                {
                    //calculate the origin of the rectangle
                    Point p_Org = new Point();
                    p_Org.X = p_Mod.X + sz_DefaultPlot.Width * x + i_Spacing * x;
                    p_Org.Y = p_Mod.Y + sz_DefaultPlot.Height * y + i_Spacing * y;
                    Rectangle rect_NewPlot = new Rectangle(p_Org, sz_DefaultPlot);
                    post_Rects.Push(p_Org);
                    g.DrawRectangle(Pens.Black, rect_NewPlot);        //draw a rectangle at the current position
                }
            }
            ist_PlotsAdded.Push(i_XDim * i_YDim);       //update the stack on how many plots were just committed
            picb_CommittedImage.Image = (Image)picb_Canvas.Image.Clone();       //place the new canvas into the committed image
            //if the undo button is disabled...
            if (btn_Undo.Enabled == false)
                btn_Undo.Enabled = true;        //then the button needs to be enabled
        }
        #endregion private void CommitMultiPlot(Point p)

        #region private void btn_StopDrawing_Click()
        /// <summary>
        /// btn_StopDrawing_Click()
        /// Stops the program from drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StopDrawing_Click(object sender, EventArgs e)
        {
            StopDrawing();
        }
        #endregion private void btn_StopDrawing_Click()
        #region private void StopDrawing()
        /// <summary>
        /// StopDrawing()
        /// This method stops the application from drawing, is used in multiple places
        /// </summary>
        private void StopDrawing()
        {
            i_DrawState = i_DSIdle;     //set the idle state
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();
            //set the color for the buttons
            btn_DrawRect.BackColor = Color.LightGray;
            btn_MultiplePlots.BackColor = Color.LightGray;
        }
        #endregion private void StopDrawing()

        #region private void btn_Resize_Click(object sender, EventArgs e)
        /// <summary>
        /// btn_Resize_Click()
        /// This method gets called whenever the user clicks the resize button
        /// The canvas will need to be resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Resize_Click(object sender, EventArgs e)
        {
            //is the ResizeWindow initialized already?
            if(rw == null)
            {
                //then the resize window needs initialized
                rw = new ResizeWindow(picb_Canvas.Size);        //setup a new window
                rw.FormClosing += Rw_FormClosing;
                rw.Show();
            }
            else
            {
                //then just focus the resize window
                rw.Show();
            }
        }
        #endregion private void btn_Resize_Click(object sender, EventArgs e)
        #region private void Rw_FormClosing(object sender, FormClosingEventArgs e)
        /// <summary>
        /// Rw_FormClosing()
        /// This event handler will set the canvas size based on the public variable in the class' rw variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rw_FormClosing(object sender, FormClosingEventArgs e)
        {
            picb_Canvas.Size = rw.sz_Resized;       //get the resize size before closing the window
            rw = null;
        }
        #endregion private void Rw_FormClosing(object sender, FormClosingEventArgs e)
    }
}
