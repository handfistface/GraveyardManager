using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;      //use the utility dll

namespace GraveyardManager
{
    public partial class PatronsIngestion : Form
    {
        #region PatronsIngestion Variables
        private List<string> sl_Lines;      //each line of the file
        private int i_ListIndex;        //the index that is currently being examined
        #endregion

        #region public PatronsIngestion()
        public PatronsIngestion()
        {
            InitializeComponent();
            sl_Lines = new List<string>();      //create a new list
            txt_OutputFile.Text = @"D:\App_Dev\GraveyardManager\Documentation\PatronsCleansed.dat";     //set the output of the text field
        }
        #endregion

        #region private void btn_FileDialog_Click(object sender, EventArgs e)
        private void btn_FileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();      //create a new open file dialog
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                //then it is okay to load the file into memory, use a stream reader to read the memory in
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    do
                    {
                        string s_Line = sr.ReadLine();      //read a line
                        sl_Lines.Add(s_Line);       //add the line to the list of lines being examined
                    } while (!sr.EndOfStream);      //read until the end of the stream
                    sr.Close();         //close up the stream reader
                }
                //if we are starting from a different index
                if (ck_StartIndex.Checked)
                    i_ListIndex = int.Parse(txt_Index.Text);        //parse the int from the text box
                else
                    i_ListIndex = 0;        //set the list index to 0
                PopulateTextBoxes();        //populate the text boxes
            }
        }
        #endregion

        #region void PopulateTextBoxes()
        /// <summary>
        /// Populates the text boxes, based on the i_ListIndex
        /// </summary>
        void PopulateTextBoxes()
        {
            string s_ToParse = sl_Lines.ElementAt(i_ListIndex);     //get the line that is currently being examined
            char[] ca_Delims = { '\t', ',', ' ' };      //deliminators used to split up each line
            string[] sa_Values = s_ToParse.Split(ca_Delims, StringSplitOptions.RemoveEmptyEntries);        //split up the line of text
            if (sa_Values.Length >= 1)
                txt_Last.Text = sa_Values[0];       //set the last name
            txt_Middle.Text = "*";      //middle is not normally inputted
            if (sa_Values.Length >= 2)
                txt_First.Text = sa_Values[1];      //set the first name
            if (sa_Values.Length >= 3)
                txt_Section.Text = sa_Values[2];        //set the section
            if (sa_Values.Length >= 4)
                txt_Id.Text = sa_Values[3];     //set the Id text
            txt_DOB.Text = "*";     //the date of birth is not normally recorded
            if (sa_Values.Length >= 5)
                txt_DOD.Text = sa_Values[4];        //set the date of death
            else
                txt_DOD.Text = "*";     //otherwise the date of death is unknown
            txt_Ashes.Text = "n";       //populate ashes
            txt_Notes.Text = "*";
            txt_Raw.Text = s_ToParse;       //set the raw text text box
            txt_Index.Text = i_ListIndex.ToString();       //assign the text field
        }
        #endregion

        #region private void btn_Commit_Click(object sender, EventArgs e)
        /// <summary>
        /// Handles clicking the commit button
        /// Commits all the text boxes to a line of cleansed data in the output file
        /// Output file will have the lines separated by commas and nothing else
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Commit_Click(object sender, EventArgs e)
        {
            //create the line of text that will be commited to the output file
            string s_Line = txt_First.Text + "," + txt_Middle.Text + "," + txt_Last.Text + "," +
                txt_Section.Text + "," + txt_Id.Text + "," + txt_DOB.Text + "," + txt_DOD.Text + "," +
                txt_Ashes.Text +        //whether the person is ashes
                ",0,0,0,0," + //plot location X, plot location Y, plot size width, plot size height
                txt_Notes.Text + ",";
            FileInfo fi = new FileInfo(txt_OutputFile.Text);        //get the file info
            if (!fi.Exists)
            {
                //fi.Create();
                System.Threading.Thread.Sleep(200);
            }
            using (StreamWriter sw = new StreamWriter(txt_OutputFile.Text, true))
            {
                sw.WriteLine(s_Line);       //write the line to the file
                sw.Close();     //close the stream writer since we're done writing
            }
            //log the person and the index we have examined
            LogManager.WriteLine("PatronsIngestion.btn_Commit_Click() -- Committed the data for the index [" + i_ListIndex + "] for the person: [" + txt_First.Text + " " + txt_Last.Text + "]");
            i_ListIndex++;      //increment the list index
            if (i_ListIndex > sl_Lines.Count)
                MessageBox.Show("End of the list reached");
            PopulateTextBoxes();        //populate the text boxes for the next entry
        }
        #endregion
    }
}
