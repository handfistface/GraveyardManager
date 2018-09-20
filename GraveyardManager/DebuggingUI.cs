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
    public partial class DebuggingUI : Form
    {
        #region public DebuggingUI()
        public DebuggingUI()
        {
            InitializeComponent();
        }
        #endregion

        #region private void btn_PatronIngestion_Click(object, sender, EventArgs e)
        /// <summary>
        /// Handles clicking the Patron Ingestion button
        /// This button populates the form "PatronIngestion"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PatronIngestion_Click(object sender, EventArgs e)
        {
            PatronsIngestion pi = new PatronsIngestion();       //create a new form
            pi.Location = this.Location;        //draw the location on top of this form
            pi.Show();
        }
        #endregion
    }
}
