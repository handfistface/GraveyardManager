using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace GraveyardManager
{
    /// <summary>
    /// DB_Storage
    /// Author: John Kirschner
    /// Date: 06-05-2018
    /// File Purpose:
    ///     This is the database of the application
    ///     There's a list of sections, where each element contains a list of plots, 
    ///     where each plot contains information about its inhabitants and some data on how to draw the plot
    /// </summary>
    public static class DB_Storage
    {
        #region Public Constants
        public const string s_DEFAULT = "NONE";     //this means that a field is not initialized
        #endregion Public Constants
        #region DB_Storage Variables
        private static List<Section> sectl_Sections = null;        //a list of sections which contain plots, null indicates that this class has not been initialized yet
        #endregion DB_Storage Variables

        #region public static void Init()
        /// <summary>
        /// Init()
        /// Seriously, what do you think this method does...
        /// Call it on program startup to initialize the list of sections
        /// </summary>
        public static void Init()
        {
            sectl_Sections = new List<Section>();
        }
        #endregion public static void Init()

        #region public static void UpdatePlots()
        /// <summary>
        /// UpdatePlots()
        /// This method will update the plots identified in the list of plots passed through the argument
        /// If a plot is not found in the existing relative section then the plot will be added to the end of the plot
        /// </summary>
        /// <param name="plotl_PlotsToUpdate">The list of plots that will update the sectl_Sections list</param>
        /// <param name="s_SectionId">The section ID that will be updated</param>
        public static void UpdatePlots(string s_SectionId, List<Plot> plotl_PlotsToUpdate)
        {
            if (!IsClassInitialized())
                return;     //the DB_Storage is not initialized yet
            bool b_FoundSection = false;        //indicates whether the section was found
            //look through each section for the plot we need to update
            foreach(Section sect in sectl_Sections)
            {
                if(sect.s_SectionId == s_SectionId)
                {
                    //then this is the section that needs the update
                    b_FoundSection = true;      //set the flag indicating the section was modified
                    //now the list of plots must be found
                    //loop through each of the plots existing in the PlotsToUpdate list...
                    for(int i=0; i < plotl_PlotsToUpdate.Count; i++)
                    {
                        //loop through each of the plots existing in the section that is being examined
                        for(int j=0; j < sect.pll_Plots.Count; j++)
                        {
                            //is the plot in the section the plot that we're processing?
                            //the LooseCompareTo will compare basic information, returns true if the plots are similar
                            if(sect.pll_Plots.ElementAt(j).LooseCompareTo(plotl_PlotsToUpdate.ElementAt(i)))
                            {
                                //then the ids match for the section and the plot we're examining
                                //make sure that there is a difference between the two plots
                                //The StrictCompareTo will tell you whether the two plots actually contain a difference
                                if(sect.pll_Plots.ElementAt(j).StrictCompareTo(plotl_PlotsToUpdate.ElementAt(i)))
                                {
                                    sect.pll_Plots.RemoveAt(j);     //remove the index, since you can't update the index based off ElementAt()
                                    sect.pll_Plots.Add(plotl_PlotsToUpdate.ElementAt(i));     //add the plot to the section
                                }
                                plotl_PlotsToUpdate.RemoveAt(i);        //remove the element since we've processed it
                            }
                        }
                    }
                    //now that the existing plots have been procesed it is fine to process the plots that may not have existed previously
                    if(plotl_PlotsToUpdate.Count > 0)
                    {
                        //then there are still some plots to add to the section
                        //loop through the remaining plots that did not previously exist
                        foreach(Plot pl in plotl_PlotsToUpdate)
                        {
                            //add the new plots to the list of plots in the section
                            sect.pll_Plots.Add(pl);     //add a new plot
                        }
                    }
                }
            }
            //if the entire list of sections has been processed and the update plot was not found...
            if(!b_FoundSection)
            {
                //then the list of sections was not found, the section will need created and its list will need updated
                Section sect = new Section(plotl_PlotsToUpdate, s_SectionId);       //create a new section that will get pushed to the list of existing sections
                sectl_Sections.Add(sect);       //aaaand add the new section to the list of existing sections
            }
        }
        #endregion public static void UpdatePlots()

        #region public static void LoadCleansedFile()
        /// <summary>
        /// Loads a cleansed file that was generated in the PatronsIngestion user control
        /// Not sure if this is going to end up being permanant or temporary at this point
        /// </summary>
        /// <param name="s_File">The path to the file and its path</param>
        public static void LoadCleansedFile(string s_File)
        {
            if (!IsClassInitialized())
                return;     //get out of the method if this class isn't initialized yet
            string s_ClassMethod = "DB_Storage.LoadCleansedFile()";
            LogManager.WriteLine(s_ClassMethod + " -- User has loaded the local file: [" + s_File + "]");
            List<Plot> lpl_Read = new List<Plot>();        //holds all of the read in plots
            //use a stream reader to read the file
            using (StreamReader sr = new StreamReader(s_File))
            {
                //read the entire file
                do
                {
                    string s_Line = sr.ReadLine();      //read a line into a string, this string will be used to break everything up
                    char[] ca_Delims = { ',' };       //the comma will be the only thing separating entries
                    string[] sa_Entries = s_Line.Split(ca_Delims, StringSplitOptions.RemoveEmptyEntries);       //split the line of text up into its components, remove the empty entries
                                                                                                                //determine if the string split up correctly
                    if (sa_Entries.Length != 13)
                    {
                        //then there are not 13 entries, only counting notes as one entry currently
                        //if there are not 13 entries then the input string is incorrect and this function will exit
                        sr.Close();     //close the stream reader
                        LogManager.WriteLine(s_ClassMethod + " -- Error encountered while parsing an input string, returning from method");
                        LogManager.WriteLine(s_ClassMethod + " -- sa_Entries.Length: [" + sa_Entries.Length + "]. Content: [" + s_Line + "]");
                        MessageBox.Show("Problem encountered while parsing data file. Cannot load file. Please try another file");
                        return;     //return from the method before anything bad happens
                    }
                    //at this point the sa_Entries will contain all of the relevant information
                    //the indexes should be in the following order
                    //0 - first name, 1 - middle name, 2 - last name
                    //3 - section, 4 - section ID,
                    //5 - DOB, 6 - DOD, 7 - ashes (yes, or no)
                    //8 - plot loc X, 9 - plot loc Y, 10 - plot size width, 11 - plot size height
                    //12 - notes
                    Person per = new Person(sa_Entries[0], sa_Entries[2], sa_Entries[1], sa_Entries[6], sa_Entries[5]);     //create the person object which will be added to the plot
                    //the four entries need parsed, splitting the creating rectangle up into multiple lines to make it more readable
                    Rectangle rect = new Rectangle(int.Parse(sa_Entries[8]), //parse X
                        int.Parse(sa_Entries[9]), //parse Y
                        int.Parse(sa_Entries[10]), //parse the width
                        int.Parse(sa_Entries[11]));     //parse the height
                    List<string> sl_Notes = new List<string>();
                    sl_Notes.Add(sa_Entries[12]);       //as of now, just load the last octet into the 
                    bool b_Ashes = false;       //does the plot contain ashes
                    if (sa_Entries[7].Equals("yes") || sa_Entries[7].Equals("true"))
                        b_Ashes = true;
                    Plot pl = new Plot(per, sa_Entries[3], sa_Entries[4], sl_Notes, b_Ashes, rect);     //create the new incoming plot
                    //determine if the new plot is going to be in a new section or will be in an old section
                    bool b_FoundSection = false;        //indicates whether the plot is in a section that exists previously
                    foreach(Section sect in sectl_Sections)     //loop through each section in the DB list
                    {
                        //determine if the sections are the same
                        if(pl.s_Section.Equals(sect.s_SectionId))
                        {
                            //then this is the same section
                            b_FoundSection = true;      //set the flag indicating the section was found
                            sect.AddPlot(pl);       //add the plot to the section
                            break;      //break from the loop, don't need to examine any other sections
                        }
                    }
                    //determine if the plot was found in the existing sections
                    if(!b_FoundSection)
                    {
                        //then the plot was not found in the existing sections
                        Section sect = new Section(pl);     //create a new section
                        sectl_Sections.Add(sect);       //add the new section to the list of sections
                    }
                } while (!sr.EndOfStream);      //read until the end of the stream
                sr.Close();     //close the stream reader
                LogManager.WriteLine(s_ClassMethod + " -- Successfully loaded the cleansed file");
            }
        }
        #endregion

        #region public static List<Plot> GetAllPlots()
        /// <summary>
        /// Combines all of the sections into one giant list of plots
        /// </summary>
        /// <returns>A list of all of the plots combined into one list, if the class wasn't initialized or an error was encountered then null is returned</returns>
        public static List<Plot> GetAllPlots()
        {
            if (!IsClassInitialized())
                return null;
            List<Plot> lpl_Master = new List<Plot>();
            foreach(Section sect in sectl_Sections)     //go through each section in the list of sections
            {
                lpl_Master.AddRange(sect.pll_Plots);        //add the list of plots to the new master list
            }
            return lpl_Master;      //return the master list
        }
        #endregion

        #region private bool IsClassInitialized()
        /// <summary>
        /// Indicates if this DB_Storage class is initialized
        /// Will pop up a MessageBox if the class is not initialized
        /// </summary>
        /// <returns>True if this class is initialized
        ///         False if this class is not initialized</returns>
        private static bool IsClassInitialized()
        {
            bool b_Initialized = true;      //indicates if this class is initialized
            //check the list of sections
            if (sectl_Sections == null)
            {
                MessageBox.Show("The database is not initialized. The list of sections is set to null");
                b_Initialized = false;     //the DB_Storage class isn't initialized yet
            }
            return b_Initialized;       //return the state of initialization
        }
        #endregion
    }

}
