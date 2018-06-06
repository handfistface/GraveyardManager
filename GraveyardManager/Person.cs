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
    ///     Can be assigned a default value, which will be housed in DB_Storage.s_DEFAULT
    /// </summary>
    public class Person
    {
        #region Person variables
        //The first, middle, and last names are all self explanatory
        public string s_FirstName;      //first name
        public string s_MiddleName;     //middle name
        public string s_LastName;       //last name
        public string s_DODMonth;       //date of death, month
        public string s_DODDay;         //date of death, day
        public string s_DODYear;        //date of death, year
        public string s_DOBMonth;       //date of birth, month
        public string s_DOBDay;         //date of birth, day
        public string s_DOBYear;        //date of birth, year
        #endregion Person variables

        #region public Person(string firstname, string middlename, string lastname, string dodmonth, string dodday, string dodyear)
        /// <summary>
        /// public Person()
        /// Constructor for the person class
        /// Initializes all of the class variables to the relative variables
        /// </summary>
        /// <param name="firstname">The first name of the inhabitant</param>
        /// <param name="middlename">The middle name of the inhabitant</param>
        /// <param name="lastname">The last name of the inhabitant</param>
        /// <param name="dodmonth">The date of death month</param>
        /// <param name="dodday">The date of death day</param>
        /// <param name="dodyear">The date of death year</param>
        /// <param name="dobmonth">Optional - The date of birth month</param>
        /// <param name="dobday">Optional - The date of birth day</param>
        /// <param name="dobyear">Optional - The date of birth year</param>
        public Person(string firstname, string middlename, string lastname,
            string dodmonth, string dodday, string dodyear,
            string dobmonth = DB_Storage.s_DEFAULT, string dobday = DB_Storage.s_DEFAULT, string dobyear = DB_Storage.s_DEFAULT)
        {
            //assign the name properties
            s_FirstName = firstname;        //set the first name
            s_MiddleName = middlename;      //set the middle name
            s_LastName = lastname;          //set the last name
            //assign the date of death properties
            s_DODMonth = dodmonth;          //set the date of death month
            s_DODDay = dodday;      //set the date of death day
            s_DODYear = dodyear;        //set the date of death year
            //assign the date of birth properties
            s_DOBMonth = dobmonth;
            s_DOBDay = dobday;
            s_DOBYear = dobyear;
        }
        #endregion public Person(string firstname, string middlename, string lastname, string dodmonth, string dodday, string dodyear)
        #region public Person()
        /// <summary>
        /// The constructor which will assign everything to a default value (value is sitting in DB_Storage.s_DEFAULT)
        /// </summary>
        public Person()
        {
            //assign the name properties
            s_FirstName = DB_Storage.s_DEFAULT;
            s_MiddleName = DB_Storage.s_DEFAULT;
            s_LastName = DB_Storage.s_DEFAULT;
            //assign the date of death properties
            s_DODMonth = DB_Storage.s_DEFAULT;
            s_DODDay = DB_Storage.s_DEFAULT;
            s_DODYear = DB_Storage.s_DEFAULT;
            //assign the date of birth properties
            s_DOBMonth = DB_Storage.s_DEFAULT;
            s_DOBDay = DB_Storage.s_DEFAULT;
            s_DOBYear = DB_Storage.s_DEFAULT;
        }
        #endregion public Person()

        #region public void SetNames(string s_First, string s_Mid, string s_Last)
        /// <summary>
        /// SetNames()
        /// Obviously this method sets the name of the person
        /// </summary>
        /// <param name="s_First">The first name</param>
        /// <param name="s_Last">The last name</param>
        /// <param name="s_Mid">Optional - The middle name, set to DB_Storage.s_DEFAULT if not passed</param>
        public void SetNames(string s_First, string s_Last, string s_Mid = DB_Storage.s_DEFAULT)
        {
            s_FirstName = s_First;      //set the first name
            s_MiddleName = s_Mid;       //set the middle name
            s_LastName = s_Last;        //set the last name
        }
        #endregion public void SetNames(string s_First, string s_Mid, string s_Last)

        #region public void SetDOD(string s_Year, string s_Month, string s_Day)
        /// <summary>
        /// SetDOD()
        /// This sets the person's date of death, the optional parameters are assigned to DB_Storage.s_DEFAULT
        /// </summary>
        /// <param name="s_Year">The year of death</param>
        /// <param name="s_Month">Optional - The month of death</param>
        /// <param name="s_Day">Optional - The day of death</param>
        public void SetDOD(string s_Year, string s_Month = DB_Storage.s_DEFAULT, string s_Day = DB_Storage.s_DEFAULT)
        {
            s_DODYear = s_Year;         //set the date of death year
            s_DODMonth = s_Month;       //set the date of death month
            s_DODDay = s_Day;           //set the date of death day
        }
        #endregion public void SetDOD(string s_Year, string s_Month, string s_Day)

        #region public void SetDOB(string s_Year, string s_Month, string s_Day)
        /// <summary>
        /// SetDODSetDOB()
        /// This sets the person's date of birth, the optional parameters are assigned to DB_Storage.s_DEFAULT
        /// </summary>
        /// <param name="s_Year">The year of birth</param>
        /// <param name="s_Month">Optional - The month of deathbirth</param>
        /// <param name="s_Day">Optional - The day of birth</param>
        public void SetDOB(string s_Year, string s_Month = DB_Storage.s_DEFAULT, string s_Day = DB_Storage.s_DEFAULT)
        {
            s_DOBYear = s_Year;         //set the date of birth year
            s_DOBMonth = s_Month;       //set the date of birth month
            s_DOBDay = s_Day;           //set the date of birth day
        }
        #endregion public void SetDOB(string s_Year, string s_Month, string s_Day)
    }
}
