using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Utility;      //use the DLL for setting up the Utility and LogManager
using GraveyardCommon;      //used for common classes and DLLs

namespace GraveyardManager
{
    public partial class frm_GraveyardManager : Form
    {

        #region frm_GraveyardManager Variables
        private FormWindowState fws_LastState;        //the last state of the window
        private Rectangle rect_InitialState;        //the initial state of the window
        private Rectangle rect_PnlInitialState;     //the initial state of the panel
        private Rectangle rect_PnlDrawingInitialState;      //the initial state of the drawing panel
        private int i_MaxWidth;     //the maximum width of the window
        private int i_MaxHeight;        //the maximum height of the window
        #endregion frm_GraveyardManager Variables

        #region public frm_GraveyardManager()
        /// <summary>
        /// frm_GraveyardManager()
        /// The constructor for the main form
        /// </summary>
        public frm_GraveyardManager()
        {
            LogManager.Init(Properties.Settings.Default.s_LoggingPath);     //intialize the LogManager for logging
            LogManager.WriteLine("");       //write a line
            LogManager.WriteLine("Boot -- GraveyardManager application is now starting");
            InitializeComponent();
            this.Resize += Frm_GraveyardManager_Resize;
            fws_LastState = this.WindowState;       //set the window state
            rect_InitialState = new Rectangle(this.Location, this.Size);        //create a new rectangle which indicates the default size of the form
            rect_PnlInitialState = new Rectangle(pnl_MainView.Location, pnl_MainView.Size);     //create a new rectangle which indicates the default size of the panel
            i_MaxWidth = Screen.PrimaryScreen.WorkingArea.Width;       //get the width of the main screen
            i_MaxHeight = Screen.PrimaryScreen.WorkingArea.Height;       //get the height of the main screen
            this.MaximumSize = new Size(i_MaxWidth, i_MaxHeight);       //set the maximum size of this form
            this.pnl_MainView.Size = this.uC_Display1.Size;     //set the size of the panel
            this.pnl_MainView.Resize += Pnl_MainView_Resize;
            DB_Storage.Init();      //initialize the database
#if DEBUG
            Point po_DebugLoc = this.Location;      //set the location for the new debug window
            po_DebugLoc.Y = po_DebugLoc.Y + this.Size.Height;       //adjust the width to be right beside the MainForm window
            DebuggingUI dui = new DebuggingUI();        //create the new form
            dui.Location = po_DebugLoc;     //set the new location of the debug window
            dui.Show();
#endif
        }
        #endregion public frm_GraveyardManager()

        #region private void pnl_MainView_Resize(object sender, EventArgs e)
        private void Pnl_MainView_Resize(object sender, EventArgs e)
        {
            Control[] conta = new Control[pnl_MainView.Controls.Count];     //create an array of controls to hold the controls info
            pnl_MainView.Controls.CopyTo(conta, 0);      //get the controls that the panel has
            //loop through each control that the panel has, not e that there should only be one control in this panel
            foreach (Control c in conta)
            {
                //is the control we're looking at a user control?
                if (c is UserControl)
                {
                    //then the control being examined is a user control, this is that wrapper around each set of controls
                    //all the user control will need to happen is that it will need resized
                    c.Size = new Size(pnl_MainView.Width, pnl_MainView.Height);
                }
            }
        }
        #endregion private void pnl_MainView_Resize(object sender, EventArgs e)

        #region private void Frm_GraveyardManager_Resize(object sender, EventArgs e)
        /// <summary>
        /// frm_GraveyardManager_Resize()
        /// This resized callback prevents the main window from getting oversized and overstretching the user's main window view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_GraveyardManager_Resize(object sender, EventArgs e)
        {
            int i_PnlPadding = 40;       //padding of 5 pixels above and below the panel
            this.Resize -= Frm_GraveyardManager_Resize;     //take the event off before changing the window size
            //has the form gone from maximized to normal?
            if(fws_LastState == FormWindowState.Maximized && this.WindowState == FormWindowState.Normal)
            {
                //the resize is going from maximized to normalthe window should be returned to its last size and initial location
                this.Location = rect_InitialState.Location;
                this.Size = rect_InitialState.Size;
                //resize the panel which holds the user control
                Control[] conta = new Control[pnl_MainView.Controls.Count];        //create an array of controls
                pnl_MainView.Controls.CopyTo(conta, 0);     //copy the controls to the array that has just been created
                //go through each of those controls
                foreach(Control cont in conta)
                {
                    //check to see if the control is a UserControl (Handle a special case for the DrawGraveyard user control
                    if (cont is UC_DrawGraveyard)
                    {
                        //the uc_DrawGraveyard acts a little different then just a standard user control
                        cont.Size = rect_PnlDrawingInitialState.Size;
                    }
                    else if (cont is UserControl)
                    {
                        //then it is safe to resize the user control
                        cont.Size = new Size(rect_PnlInitialState.Width - i_PnlPadding, rect_PnlInitialState.Height - this.menuStrip1.Height - i_PnlPadding);      //resize the panel
                    }
                }
            }
            else if (fws_LastState == FormWindowState.Normal && this.WindowState == FormWindowState.Maximized)
            {
                //then the resize is going from the normal state to the maximized state
                Control[] conta = new Control[pnl_MainView.Controls.Count];        //create an array of controls
                pnl_MainView.Controls.CopyTo(conta, 0);     //copy the controls to the array that has just been created
                //go through each of those controls
                foreach (Control cont in conta)
                {
                    //check to see if the control is a UserControl
                    if (cont is UserControl)
                    {
                        //then it is safe to resize the user control
                        cont.Size = new Size(this.Width - i_PnlPadding, this.Height - this.menuStrip1.Height - i_PnlPadding);      //resize the panel
                    }
                }
            }
            this.Resize += Frm_GraveyardManager_Resize;     //turn the resize event back on
            fws_LastState = this.WindowState;       //set the last state of the window
        }
        #endregion private void Frm_GraveyardManager_Resize(object sender, EventArgs e)

        #region private void inhabitantsToolStripMenuItem_Click()
        /// <summary>
        /// Populates the panel to view the contents of the graveyard (the people)
        /// The tool strip menu item is also known as "View -> Database"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inhabitantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl uc_Display = new UC_Display();      //create a new user control for viewing the DB
            pnl_MainView.Controls.Clear();      //clear the panel so we aren't over writing it
            pnl_MainView.Controls.Add(uc_Display);      //add a new panel view of the DB
            pnl_MainView.Size = this.Size;
        }
        #endregion private void inhabitantsToolStripMenuItem_Click()

        #region private void drawGraveyardToolStripMenuItem_Click()
        private void drawGraveyardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl uc_DrawGraveyard = new UC_DrawGraveyard();      //create a new user control
            pnl_MainView.Controls.Clear();      //clear the panel
            pnl_MainView.Controls.Add(uc_DrawGraveyard);        //add a new panel view
            pnl_MainView.Size = this.Size;
            rect_PnlDrawingInitialState = new Rectangle(pnl_MainView.Location, pnl_MainView.Size);
        }
        #endregion private void drawGraveyardToolStripMenuItem_Click()

        #region private void aboutToolStripMenuItem_Click()
        /// <summary>
        /// Clears the main panel and places an about window on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl uc_About = new UC_About();      //create a new user control for the about window
            pnl_MainView.Controls.Clear();      //clear the panel so nothing overwrites it
            pnl_MainView.Controls.Add(uc_About);        //add the about user control to the panel
        }
        #endregion private void aboutToolStripMenuItem_Click()

        #region private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// Save tool strip menu item click
        /// This method gets called whenever the user wants to just save the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        #region private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// Save File Tool Strip Menu Item CLick
        /// This method gets called whenever the user wants to save the file as a specific file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
    }
}
