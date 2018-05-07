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
    public partial class UC_Display : UserControl
    {
        #region public UC_Display()
        public UC_Display()
        {
            InitializeComponent();
            //please note that the columns must be setup through the interface in the properties of the list view designer
            //it's kind of a strange way, but I'm leaving it static, this code may not be gone back over after being written
            //the list view group identifies an entry
            string[] sa_Item = { "John", "David", "Kirschner", "C1", "9", "n/a" };
            lstv_Patrons.Items.Add(new ListViewItem(sa_Item));
            if(!GlobalVariables.b_EnableDebugging)
            {
                //if debugging is disabled...
                pnl_Tester.Enabled = false;
                pnl_Tester.Visible = false;
            }
        }
        #endregion public UC_Display()

        #region private void btn_LoadCemetery_Click()
        /// <summary>
        /// btn_LoadCemetery_Click()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadCemetery_Click(object sender, EventArgs e)
        {
            
        }
        #endregion private void btn_LoadCemetery_Click()
    }
}
