using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Utility;
using System.IO;

namespace GraveyardManager
{
    public partial class UC_Display : UserControl
    {
        #region UC_Display Variables
        private SqlConnection sql_Connection;       //used to describe the sql connection
        private const string s_DatabaseName = "Graveyard";      //the name of the local database
        #endregion

        #region public UC_Display()
        public UC_Display()
        {
            string s_ClassMethod = "UC_Display.Constructor()";
            InitializeComponent();
            //please note that the columns must be setup through the interface in the properties of the list view designer
            //it's kind of a strange way, but I'm leaving it static, this code may not be gone back over after being written
            //the list view group identifies an entry
            /*string[] sa_Item = { "John", "David", "Kirschner", "C1", "9", "n/a" };
            lstv_Patrons.Items.Add(new ListViewItem(sa_Item));
            */
            this.Resize += UC_Display_Resize;
            this.HandleDestroyed += UC_Display_HandleDestroyed;
            // User Id=DESKTOP-04CJ33M\\John; Password=sidis3po;  User ID=masterowner; Password=sidis3po; tempdb Database=tempdb;
            //the Trusted_Connection forces the user to be the current logged in windows user
            string s_SqlConnectionString = "Data Source=DESKTOP-04CJ33M\\SQLEXPRESS; Trusted_Connection=SSPI;";
            sql_Connection = new SqlConnection(s_SqlConnectionString);      //connect to the database
            sql_Connection.Open();      //start the connection
            //Determine if the data exists or not
            if (SqlHelper.DoesDBExist(sql_Connection, s_DatabaseName))
            {
                Util.rtxtWriteLine(s_ClassMethod + " -- Database " + s_DatabaseName + " exists");
            }
            else
            {
                //otherwise the database does not exist
                Util.rtxtWriteLine(s_ClassMethod + " -- Database " + s_DatabaseName + " exists");
            }
#if !DEBUG
            //then this is not the debug branch, it is the release, the debugging interface will need removed
            pnl_Debug.Visible = false;      //set the debug interface invisible
            pnl_Debug.Enabled = false;      //set the debug interface disabled
#endif
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

        #region private void UC_Display_HandleDestroyed(object sender, EventArgs e)
        /// <summary>
        /// Handles whenever this user control is being destroyed
        /// Closes up the sql connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_Display_HandleDestroyed(object sender, EventArgs e)
        {
            sql_Connection.Close();     //close the sql connection
            sql_Connection.Dispose();       //dispose the sql connection
        }
        #endregion

        #region private void btn_TestSql_Click(object sender, EventArgs e)
        /// <summary>
        /// Handles the test sql button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TestSql_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region private void btn_SetupDB_Click(object sender, EventArgs e)
        /// <summary>
        /// Sets up the database to interface with, based off the plot and person storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SetupDB_Click(object sender, EventArgs e)
        {
            string s_ClassMethod = "UC_Display.btn_SetupDB_Click()";
            SqlCommand sql_Command = new SqlCommand("SELECT * FROM TestTable", sql_Connection);
            sql_Command.Connection.Open();      //open the connection to the sql servert
            SqlDataReader sql_Reader = sql_Command.ExecuteReader();      //execute the command, put the results back in the data reader
            //read the query that was just received
            while (sql_Reader.Read())
            {
                string s_Read = sql_Reader.GetString(0);
                Util.rtxtWriteLine(s_ClassMethod + " -- Database: [" + s_Read + "]");
            }
        }
        #endregion

        #region private void btn_LoadCleansedFile_Click(object sender, EventArgs e)
        /// <summary>
        /// Loads a cleansed file that was generated from the PatronsIngestion user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadCleansedFile_Click(object sender, EventArgs e)
        {
            //use an OpenFileDialog object to get the new file
            OpenFileDialog ofd = new OpenFileDialog();      //create a new open file dialog for getting the new file
            //open up the dialog for the user to choose a new file
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //then a file was chosen, this is the file that will be loaded
                DB_Storage.LoadCleansedFile(ofd.FileName);      //load the cleansed file into the local DB
                //setup the new interface to have a representation of all the inhabitants of the graveyard
                List<Plot> lpl_Plots = DB_Storage.GetAllPlots();        //get all of the plots that were just loaded
                foreach(Plot pl in lpl_Plots)       //go through each plot that was just loaded
                {
                    //sa_Line contains the line of text that will be displayed to the user
                    string[] sa_Line = { pl.pers.s_FirstName, pl.pers.s_MiddleName, pl.pers.s_LastName,
                        pl.s_Section, pl.s_Id, pl.pers.s_DODDate, 
                        pl.sl_Notes.ElementAt(0) };
                    lstv_Patrons.Items.Add(new ListViewItem(sa_Line));      //add the patron to the UI
                }
            }
        }
        #endregion
    }
}
