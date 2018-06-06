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
        List<Plot> pll_Plots;       //list of plots which indicates inhabitants of the graveyard
        #endregion Public Variables

        #region public Section()
        /// <summary>
        /// Section()
        /// Constructor for the graveyard section, just sets up the pll_Plots to be a valid object
        /// </summary>
        public Section()
        {
            pll_Plots = new List<Plot>();
        }
        #endregion public Section()
        #region public Section(List<Plot> pll)
        /// <summary>
        /// Section()
        /// Constructor for the graveyard section.
        /// Assigns the pll_Plots to a valid list
        /// </summary>
        /// <param name="pll"></param>
        public Section(List<Plot> pll)
        {
            pll_Plots = pll;
        }
        #endregion public Section(List<Plot> pll)

    }
}
