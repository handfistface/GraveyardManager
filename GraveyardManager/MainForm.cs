using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraveyardManager
{
    public partial class frm_GraveyardManager : Form
    {

        #region frm_GraveyardManager Variables
        private FormWindowState fws_LastState;        //the last state of the window
        private Rectangle rect_InitialState;        //the initial state of the window
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
            InitializeComponent();
            this.Resize += Frm_GraveyardManager_Resize;
            fws_LastState = this.WindowState;       //set the window state
            rect_InitialState = new Rectangle(this.Location, this.Size);        //create a new rectangle which indicates the default size of the form
            i_MaxWidth = Screen.PrimaryScreen.Bounds.Width;       //get the width of the main screen
            i_MaxHeight = Screen.PrimaryScreen.Bounds.Height;       //get the height of the main screen
            this.pnl_MainView.Size = this.uC_Display1.Size;     //set the size of the panel
        }
        #endregion public frm_GraveyardManager()

        #region private void Frm_GraveyardManager_Resize(object sender, EventArgs e)
        /// <summary>
        /// frm_GraveyardManager_Resize()
        /// This resized callback prevents the main window from getting oversized and overstretching the user's main window view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_GraveyardManager_Resize(object sender, EventArgs e)
        {
            if(this.Height > i_MaxHeight)
            {
                //then the resize needs to be stopped
                this.Height = i_MaxHeight;      //prevent the resize from happening
            }
            if(this.Width > i_MaxWidth)
            {
                //then the resize needs to be stopped because the max width will exceed the screen
                this.Width = i_MaxWidth;
            }
            //has the form gone from the window 
            if(fws_LastState == FormWindowState.Maximized && this.WindowState == FormWindowState.Normal)
            {
                //the window should be returned to its last size and initial location
                this.Resize -= Frm_GraveyardManager_Resize;     //take the event off before chaning the window size
                this.Location = rect_InitialState.Location;
                this.Size = rect_InitialState.Size;
                this.Resize += Frm_GraveyardManager_Resize;     //put the event back on since we've changed the window size
            }
            //resize the panel which holds the user control
            int i_PnlPadding = 5;       //padding of 5 pixels above and below the panel
            pnl_MainView.Size = new Size(this.Width, this.Height - this.menuStrip1.Height - i_PnlPadding * 2);      //resize the panel
            uC_Display1.Size = pnl_MainView.Size;       //set the size of the user control
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
        }
        #endregion private void inhabitantsToolStripMenuItem_Click()

        #region private void drawGraveyardToolStripMenuItem_Click()
        private void drawGraveyardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl uc_DrawGraveyard = new UC_DrawGraveyard();      //create a new user control
            pnl_MainView.Controls.Clear();      //clear the panel
            pnl_MainView.Controls.Add(uc_DrawGraveyard);        //add a new panel view
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
    }
}
