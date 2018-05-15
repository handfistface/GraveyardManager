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
        #endregion UC_DrawGraveyard Variables
        #region Graphics Variables
        private PictureBox picb_CommittedImage;     //The canvas after the user has made a change to it
        private Size sz_DefaultPlot = new Size(50, 25);     //default size of the plot
        private Stack<Point> pos_Rects;      //the list of rectangle origin points
        private const int i_GCIterMax = 5;      //the maximum count i_GCIteration is allowed to reach before running GC.Collect()
        private int i_GCIteration;        //counter that how many iterations before GC.Collect is run (bitmaps are scary)
        #endregion Graphics Variables
        #region Undo Variables
        private int i_UndoMaxStack = 11;     //max amount of undo's before the stack dries up
        private Stack<PictureBox> spicb_Undo;       //a stack of picture boxes used to revert the canvas
        #endregion Undo Variables

        #region public UC_DrawGraveyard()
        /// <summary>
        /// This class creats a drawable canvas for the user to map the graveyard
        /// Also hooks to a few events that are required for drawing
        /// </summary>
        public UC_DrawGraveyard()
        {
            InitializeComponent();
            pos_Rects = new Stack<Point>();      //create a new list of points
            spicb_Undo = new Stack<PictureBox>();       //create a new stack for the picture box
            i_GCIteration = 0;      //set the counter to 0
            picb_Canvas.Paint += Picb_Canvas_Paint;     //hook to a picture box paint event
            picb_Canvas.MouseMove += UC_DrawGraveyard_MouseMove;       //hook to a mouse moving event
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
                    //then a ghost plot needs placed on the screen
                    CommitPlot(p_MousePos);
                }
            }
        }
        #endregion private void Picb_Canvas_MouseClick(object sender, MouseEventArgs e)

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
                //then set the flag to indicate that the user wants to start drawing plots
                i_DrawState = i_DSSingleRect;
                //now flip the button to indicate that the user has an option to stop drawing
                btn_DrawRect.Text = "Stop Plotting";
                btn_MultiplePlots.Text = "Draw Multiple Plots";     //make sure to update the multiple plots as well
            }
            else
            {
                //then the flag indicates that the user is drawing a single plot
                //this means that the user wants to stop drawing
                i_DrawState = i_DSIdle;     //set the idle state
                //now flip the button to indicate that the user sees they have an option to start drawing again
                btn_DrawRect.Text = "Draw Plot";
                btn_MultiplePlots.Text = "Draw Multiple Plots";      //make sure to update the multiple plots as well
                picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();
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
            if (IsWithinPlot(p_MousePos))
                pen = Pens.Red;     //the color needs to be red if we're intersecting a grave
            else
                pen = Pens.Gray;        //otherwise the cursor doesn't intersect another plot
            p_MousePos = SnapOrigin(p_MousePos);
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
            Graphics g = Graphics.FromImage(picb_CommittedImage.Image);     //get the graphics from the committed image because now this image needs modified
            p_MousePos = SnapOrigin(p_MousePos);
            g.DrawRectangle(Pens.Black, new Rectangle(p_MousePos, sz_DefaultPlot));     //draw a rectangle on the point we're looking at
            picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();       //clone that sucker onto the canvas that's being displayed
            pos_Rects.Push(p_MousePos);      //add the point to the list of rectangle points
            Util.rtxtWriteLine("New plot: (" + p_MousePos.X + ", " + p_MousePos.Y + ")");
            //start working with the picture box stack used for undoing
            PictureBox picb_Stack = new PictureBox();
            picb_Stack.Image = (Image)picb_Canvas.Image.Clone();        //clone the image onto the new stack entry
            //has the max stack size been reached?
            if (spicb_Undo.Count > i_UndoMaxStack)
                spicb_Undo.Pop();       //then the max stack has been reached, pop an entry off before putting another one
            spicb_Undo.Push(picb_Stack);        ///push a new entry onto the stack
            //has the btn_Undo button been disabled?
            if (!btn_Undo.Enabled)
                btn_Undo.Enabled = true;        //then the button was disabled, re-enable it
        }
        #endregion private void CommitPlot(Point p_MousePos)
        #region private Point SnapOrigin(Point p)
        /// <summary>
        /// SnapOrigin()
        /// This method will take a an unmodified point and figure out a new point to place the origin at
        /// </summary>
        /// <param name="p">The unmodified point of the mouse pointer</param>
        /// <returns>A modified point of where to snap the rectangle, if the point is not near another plot then this will return the point argument</returns>
        private Point SnapOrigin(Point p)
        {
            Point p_Mod = p;      //create a new point
            int i_Spacing = 2;      //pixel spacing between the plots
            int i_Snapping = 10;     //number of pixels within a line to snap to
            //loop through each plot in pol_Rects
            foreach (Point p_Origin in pos_Rects)
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

        #region private bool IsWithinPlot(Point p)
        /// <summary>
        /// This method detects if a point is inside of a plot
        /// This will be used for a number of applications like changing color of the ghost rectangle
        /// Or will be used for identifying The GraveId the user clicks on
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool IsWithinPlot(Point p)
        {
            bool b_Inside = false;      //indicates whether the point falls inside a grave
            //every single grave must be processed to determine if the point argument is inside
            foreach(Point p_GraveOrigin in pos_Rects)
            {
                if(p.X >= p_GraveOrigin.X &&
                   p.X <= p_GraveOrigin.X + sz_DefaultPlot.Width &&
                   p.Y >= p_GraveOrigin.Y &&
                   p.Y <= p_GraveOrigin.Y + sz_DefaultPlot.Height)
                {
                    //then the passed point falls within the grave
                    b_Inside = true;
                    break;      //break from the loop since no more processing is required
                }
            }
            return b_Inside;        //return the flag indicating if the point is within a grave
        }
        #endregion private bool IsWithinPlot(Point p)

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
            PictureBox picb_Popped = spicb_Undo.Pop();      //pop off a picture box from the stack of undo picture boxes
            pos_Rects.Pop();        //pop the last drawn plot off the stack
            //has the beginning of the stack been reached?
            if (spicb_Undo.Count <= 0)
                btn_Undo.Enabled = false;       //then the stack is exhausted, disable the button to prevent any further pops
            picb_CommittedImage.Image = (Image)picb_Popped.Image.Clone();
            //is this update a cross threaded access?
            if(picb_Canvas.InvokeRequired)
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
        }
        #endregion private void btn_Undo_Click()

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
                //then set the flag to indicate that the user wants to start drawing plots
                i_DrawState = i_DSMultiRect;
                //now flip the button to indicate that the user has an option to stop drawing
                btn_MultiplePlots.Text = "Stop Plotting";
                btn_DrawRect.Text = "Draw Plot";     //make sure to update the multiple plots as well
            }
            else
            {
                //then the flag indicates that the user is drawing a single plot
                //this means that the user wants to stop drawing
                i_DrawState = i_DSIdle;     //set the idle state
                //now flip the button to indicate that the user sees they have an option to start drawing again
                btn_DrawRect.Text = "Draw Plot";
                btn_MultiplePlots.Text = "Draw Multiple Plots";      //make sure to update the multiple plots as well
                picb_Canvas.Image = (Image)picb_CommittedImage.Image.Clone();
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
    }
}
