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
    public partial class UC_About : UserControl
    {
        public UC_About()
        {
            InitializeComponent();
            txt_Version.Text = GlobalVariables.s_ApplicationVersion;        //set the text box indicating the application version
        }
    }
}
