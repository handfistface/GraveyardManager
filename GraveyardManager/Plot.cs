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
        public Person per_Patron;       //the person identifier
        public string s_Section;        //the section this plot exists in
        public string s_Id;             //The ID of the grave
        public List<string> s_Notes;          //any special notes of the plot
        public Rectangle rect_Grave;        //the rectangle representing the plot in the graveyard, origin point and the height/width
    }
}
