using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraveyardCommon
{
    /// <summary>
    /// Author: John Kirschner
    /// Date: 05-06-2018
    /// Class Purpose:
    ///     This class keeps a representation of a graveyard plot
    ///     A plot has a person, a section it exists in, an ID of the grave, whether the inhabitant is ashes, the plot location, 
    ///     and any miscellaneous notes about the person
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

        #region public bool LooseCompareTo(Plot pl)
        /// <summary>
        /// LooseCompareTo()
        /// Does a loose comparison to the Plot passed to the method, only compares one part of the plot
        /// Will compare the rectangle co-ordinates and size and base the equality off only that
        /// </summary>
        /// <param name="pl">The plot that will be compared</param>
        /// <returns>Boolean indicating if the two plots are similar</returns>
        public bool LooseCompareTo(Plot pl)
        {
            bool b_IsSimilar = false;       //indicates if the plot is similar to the one being compared, will be returned
            //null sanity check
            if (rect_Grave != null && pl.rect_Grave != null)
            {
                //then the plot rectangles are valid and they can be compared
                //compare the location
                if (rect_Grave.Location.X == pl.rect_Grave.Location.X &&
                    rect_Grave.Location.Y == pl.rect_Grave.Location.Y)
                {
                    //then the point of origin is equal for the plots
                    //compare the dimensions of the plot
                    if (rect_Grave.Size.Height == pl.rect_Grave.Size.Height &&
                        rect_Grave.Size.Width == pl.rect_Grave.Size.Width)
                    {
                        //then the height and width of the graveyard plots are equal
                        //for all intents and purposes the plt is the same
                        b_IsSimilar = true;     //set the return to true
                    }
                    else
                    {
                        //otherwise the rectangles are not equal, set the return to false (even though its started as false)
                        b_IsSimilar = false;
                    }
                }
            }
            else
            {
                //then a graveyard is null, they cannot be properly compared and will not equal one another
                //set the return to false to indicate inequality
                b_IsSimilar = false;
            }
            return b_IsSimilar;     //return the indicator of loose equality
        }
        #endregion public bool LooseCompareTo(Plot pl)
        #region public bool StrictCompareTo(Plot pl)
        /// <summary>
        /// StrictCompareTo()
        /// Does a strict comparison with all members of a Plot
        /// Will compare the plot location and size first as this is going to likely be the least process intensive way to determine inequality
        /// Please note that the sl_Notes is not compared
        /// A Null reference will cause a short circuit behaviour and will force the method to return false
        /// </summary>
        /// <param name="pl">The Plot that will be compared to</param>
        /// <returns>A bool indicating whether the plots are equal or not, will return false if a null reference is found</returns>
        public bool StrictCompareTo(Plot pl)
        {
            bool b_IsSimilar = false;       //indicates if the plot is similar to the one being compared, will be returned
            //null sanity check
            if (s_Section == null || s_Id == null ||
                pl.s_Section == null || pl.s_Id == null)
            {
                //then there was a null reference, return false to prevent any other issues with comparison
                return false;
            }
            //First do a loose comparison to reduce processing involved with the plot comparison
            if (LooseCompareTo(pl))
            {
                //then the plots are in the same location, this is going to mean that everything else will need compared
                //compare the person
                if (pers.CompareTo(pl.pers))
                {
                    //then the people are the same
                    //compare the s_Section the s_id and the b_Ashes
                    if (s_Section == pl.s_Section &&
                        s_Id == pl.s_Id &&
                        b_Ashes == pl.b_Ashes)
                    {
                        //then all of the variables are equal, set the return variable
                        b_IsSimilar = true;
                    }
                }
                else
                {
                    //the people are not the same
                    b_IsSimilar = false;
                }
            }
            else
            {
                //then the plots are not in the same location, short circuit the logic and exit out of the function to prevent unnecessary comparisons
                b_IsSimilar = false;
            }
            return b_IsSimilar;     //return the indicator of strict equality
        }
        #endregion public bool StrictCompareTo(Plot pl)
    }
}
