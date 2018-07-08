using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraveyardManager
{
    /// <summary>
    /// Section class
    /// Author: John Kirschner
    /// Date: 06-05-2018
    /// Class Purpose:
    ///     The Section class acts as a kind of container for the Plot object, it has a list of plots
    ///     A graveyard will consist of a list of sections
    /// </summary>
    public class Section
    {
        #region Public Variables
        public string s_SectionId;          //The id of the section
        public List<Plot> pll_Plots;       //list of plots which indicates inhabitants of the graveyard
        #endregion Public Variables

        #region public Section()
        /// <summary>
        /// Section()
        /// Constructor for the graveyard section, just sets up the pll_Plots to be a valid object
        /// The s_SectionId is set to DB_Storage.s_DEFAULT
        /// </summary>
        public Section()
        {
            pll_Plots = new List<Plot>();
            s_SectionId = DB_Storage.s_DEFAULT;
        }
        #endregion public Section()
        #region public Section(List<Plot> pll)
        /// <summary>
        /// Section()
        /// Constructor for the graveyard section.
        /// Assigns the pll_Plots to a valid list
        /// </summary>
        /// <param name="pll"></param>
        public Section(List<Plot> pll, string sectionid)
        {
            pll_Plots = pll;                //setup the list
            s_SectionId = sectionid;        //setup the section id
        }
        #endregion public Section(List<Plot> pll)

    }
}
