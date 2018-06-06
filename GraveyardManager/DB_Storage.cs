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
        public static List<Section> sectl_Sections;
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
    }
}
