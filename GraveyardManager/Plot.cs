using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraveyardManager
{
    /// <summary>
    /// Author: John Kirschner
    /// Date: 05-06-2018
    /// Class Purpose:
    ///     This class keeps a representation of a graveyard plot
    ///     A plot has a person, a section it exists in, and an ID of the grave
    /// </summary>
    public class Plot
    {
        #region Public Constants
        public const int i_DEFAULTPLOT = 0;     //indicates that the rect_Grave is in a default state
        #endregion Public Constants
        #region Public Variables
        public Person pers;       //the person description, names, date of death, date of birth
        public string s_Section;        //the section this plot exists in
        public string s_Id;             //The ID of the grave
        public List<string> sl_Notes;          //any special notes of the plot
        public bool b_Ashes;        //indicates if the inhabitant is ashes or a corpse
        public Rectangle rect_Grave;        //the rectangle representing the plot in the graveyard, origin point and the height/width
        #endregion Public Variables

        #region public Plot()
        /// <summary>
        /// The constructor for the Plot object
        /// Initializes everything to a default value
        /// Ashes is assigned to false, rectangle is assigned null, person is calls the Person() constructor (everything is DB_Storage.s_DEFAULT)
        /// </summary>
        public Plot()
        {
            pers = new Person();      //the person will be assigned to default values
            s_Section = DB_Storage.s_DEFAULT;
            s_Id = DB_Storage.s_DEFAULT;
            sl_Notes = new List<string>();      //create an empty string list to hold the notes
            b_Ashes = false;        //set to false to indicate that we're still dealing with a corpse
            rect_Grave = new Rectangle(i_DEFAULTPLOT, i_DEFAULTPLOT, i_DEFAULTPLOT, i_DEFAULTPLOT);     //assign everything to 0, X, Y, height, and width
        }
        #endregion public Plot()
        #region public Plot(Person per, string section, string id, List<string> notes, bool ashes, Rectangle grave)
        /// <summary>
        /// Plot()
        /// The constructor that builds all the information for the plot
        /// </summary>
        /// <param name="per">The person that resides in the plot</param>
        /// <param name="section">The section of the graveyard this is in</param>
        /// <param name="id">The ID of the grave (kind of like a sub identifier of the grave)</param>
        /// <param name="notes">Any notes of the plot</param>
        /// <param name="ashes">Whether the corpse is ashes</param>
        /// <param name="grave">The rectangle representing the positioning of the grave</param>
        public Plot(Person per, string section, string id, List<string> notes, bool ashes, Rectangle grave)
        {
            pers = per;     //set the person
            s_Section = section;    //set the section of the graveyard
            s_Id = id;      //set the ID of the graveyard
            sl_Notes = notes;       //set the notes of the plot
            b_Ashes = ashes;        //set whether the corpse is ashes
            rect_Grave = grave;     //set the grave rectangle
        }
        #endregion public Plot(Person per, string section, string id, List<string> notes, bool ashes, Rectangle grave)
    }
}
