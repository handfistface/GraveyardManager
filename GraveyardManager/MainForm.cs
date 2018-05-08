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
        public frm_GraveyardManager()
        {
            InitializeComponent();
        }

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
