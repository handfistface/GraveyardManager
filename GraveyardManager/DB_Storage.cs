using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static List<Section> sectl_Sections;
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
    }
}
