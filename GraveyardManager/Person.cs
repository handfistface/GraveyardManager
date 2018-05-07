using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraveyardManager
{
    /// <summary>
    /// Author: John Kirschner
    /// Date: 05-06-2018
    /// Class Purpose:
    ///     This class is a representation of a person
    ///     This class is used in combination with Plot to specify who is buried in a grave
    /// </summary>
    public class Person
    {
        #region Person variables
        //The first, middle, and last names are all self explanatory
        public string s_FirstName;
        public string s_MiddleName;
        public string s_LastName;
        public string s_DODMonth;       //date of death, month
        public string s_DODDay;         //date of death, day
        public string s_DODYear;        //date of death, year
        #endregion Person variables

        #region public Person(string firstname, string middlename, string lastname, string dodmonth, string dodday, string dodyear)
        /// <summary>
        /// public Person()
        /// Constructor for the person class
        /// Initializes all of the class variables to the relative variables
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="middlename"></param>
        /// <param name="lastname"></param>
        /// <param name="dodmonth"></param>
        /// <param name="dodday"></param>
        /// <param name="dodyear"></param>
        public Person(string firstname, string middlename, string lastname, string dodmonth, string dodday, string dodyear)
        {
            s_FirstName = firstname;        //set the first name
            s_MiddleName = middlename;      //set the middle name
            s_LastName = lastname;          //set the last name
            s_DODMonth = dodmonth;          //set the date of death month
            s_DODDay = dodday;      //set the date of death day
            s_DODYear = dodyear;        //set the date of death year
        }
        #endregion public Person()
    }
}
