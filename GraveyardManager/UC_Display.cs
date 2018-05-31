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
            this.Resize += UC_Display_Resize;
        }
        #endregion public UC_Display()

        #region private void UC_Display_Resize(object sender, EventArgs e)
        /// <summary>
        /// Uc_Display_Resize()
        /// This method gets called whenever the user control resizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_Display_Resize(object sender, EventArgs e)
        {
            //resize the lstv_Patrons item
            int i_Padding = 5;      //5 pixels padding on the bottom & top of the item
            lstv_Patrons.Size = new Size(lstv_Patrons.Width, this.Height - i_Padding * 2);      //adjust the size (padding * 2 because I gotta pad the top and the bottom
        }
        #endregion private void UC_Display_Resize(object sender, EventArgs e)

        #region private void btn_Add_Click(object sender, EventArgs e)
        private void btn_Add_Click(object sender, EventArgs e)
        {

        }
        #endregion private void btn_Add_Click(object sender, EventArgs e)
    }
}
