using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraveyardCommon
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
        public string s_DODDate;        //mm-dd-yyyy OR yyyy - Date of death
        public string s_DOBDate;        //mm-dd-yyyy OR yyyy - Date of birth
        #endregion Person variables

        #region public Person(string firstname, string middlename, string lastname, string doddate, string dobdate)
        /// <summary>
        /// public Person()
        /// Constructor for the person class
        /// Initializes all of the class variables to the relative variables
        /// </summary>
        /// <param name="firstname">The first name of the inhabitant</param>
        /// <param name="lastname">The last name of the inhabitant</param>
        /// <param name="middlename">Optional - The middle name of the inhabitant</param>
        /// <param name="doddate">Optional - The date of death month</param>
        /// <param name="dobdate">Optional - The date of birth month</param>
        public Person(string firstname, string lastname, string middlename = DB_Storage.s_DEFAULT,
            string doddate = DB_Storage.s_DEFAULT,
            string dobdate = DB_Storage.s_DEFAULT)
        {
            //assign the name properties
            s_FirstName = firstname;        //set the first name
            s_MiddleName = middlename;      //set the middle name
            s_LastName = lastname;          //set the last name
            //assign the date of death properties
            s_DODDate = doddate;          //set the date of death
            //assign the date of birth properties
            s_DOBDate = dobdate;        //set the date of birth
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
            s_DODDate = DB_Storage.s_DEFAULT;
            //assign the date of birth properties
            s_DOBDate = DB_Storage.s_DEFAULT;
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
        /// <param name="doddate">The date of death, in the format mm-dd-yyyy</param>
        public void SetDOD(string doddate)
        {
            s_DODDate = doddate;         //set the date of death
        }
        #endregion public void SetDOD(string s_Year, string s_Month, string s_Day)

        #region public void SetDOB(string s_Year, string s_Month, string s_Day)
        /// <summary>
        /// SetDODSetDOB()
        /// This sets the person's date of birth, the optional parameters are assigned to DB_Storage.s_DEFAULT
        /// </summary>
        /// <param name="dobdate">The year of birth</param>
        public void SetDOB(string dobdate)
        {
            s_DOBDate = dobdate;         //set the date of birth
        }
        #endregion public void SetDOB(string s_Year, string s_Month, string s_Day)

        #region public bool CompareTo(Person pers)
        /// <summary>
        /// CompareTo()
        /// This function compares the calling object with the argument passed
        /// Return value will indicate equality
        /// All variables of the objects are compared
        /// Any null references will cause a return of false
        /// </summary>
        /// <param name="pers">The person that this instance will be compared to</param>
        /// <returns>A bool indicating equality, true indicates equality, false indicates inequality</returns>
        public bool CompareTo(Person pers)
        {
            bool b_IsSimilar = false;       //indicates equality, is the return variable
            //compare the names by calling the class function
            if (NameCompareTo(pers))
            {
                //then the names are equal
                //compare the date of birth
                if (DOBCompareTo(pers))
                {
                    //then the date of birth is equal
                    //compare the date of death variables
                    if (DODCompareTo(pers))
                    {
                        //then the date of death variables are equal, its fine to say this is the same person
                        b_IsSimilar = true;
                    }
                    else
                    {
                        //otherwise the date of death variables are not equal
                        b_IsSimilar = false;
                    }
                }
                else
                {
                    //otherwise the date of birth is not equal
                    b_IsSimilar = false;
                }
            }
            else
            {
                //otherwise the names are not equal
            }
            return b_IsSimilar;
        }
        #endregion
        #region public bool NameCompareTo(Person pers)
        /// <summary>
        /// NameCompareTo()
        /// This function compares the calling object with the argument passed
        /// Only compares the first, middle, and last names of both objects
        /// Any null references will cause a return of false
        /// </summary>
        /// <param name="per">The person that will be compared</param>
        /// <returns></returns>
        public bool NameCompareTo(Person per)
        {
            bool b_IsSimilar = false;       //indicates equality, is the return variable
            //catch any null issues
            if (s_FirstName == null || s_MiddleName == null || s_LastName == null ||
                per.s_FirstName == null || per.s_MiddleName == null || per.s_LastName == null)
            {
                //then there are some null references there, equality cannot be achieved
                return false;
            }
            //compare the group of names
            if (s_FirstName == per.s_FirstName &&
                s_MiddleName == per.s_MiddleName &&
                s_LastName == per.s_LastName)
            {
                //then the names are equal
                b_IsSimilar = true;     //indicate equality
            }
            else
            {
                //then the names are not equal
                b_IsSimilar = false;        //indicate inequality
            }
            return b_IsSimilar;     //indicate that the names are not similar
        }
        #endregion
        #region public bool DOBCompareTo(Person pers)
        /// <summary>
        /// DOBCompareTo()
        /// This function compraes the calling object with the argument passed
        /// Return value with indicate equality
        /// Only compares the DOB (date of birth) variables
        /// Any null references will cause a return of false
        /// </summary>
        /// <param name="pers">The object that will be compared to</param>
        /// <returns>A bool indicating equality</returns>
        public bool DOBCompareTo(Person pers)
        {
            bool b_IsSimilar = false;        //indicates equality
            //null sanity check
            if (s_DOBDate == null || pers.s_DOBDate == null)
            {
                //then there was a null reference somewhere in there, return false
                return false;
            }
            //now compare the DOB variables
            if (s_DOBDate == pers.s_DOBDate)
            {
                //then the day, month, and year are equal, it's fine to set the return value
                b_IsSimilar = true;
            }
            else
            {
                //otherwise something did not match up
                b_IsSimilar = false;
            }
            return b_IsSimilar;
        }
        #endregion
        #region public bool DODCompareTo(Person pers)
        /// <summary>
        /// DODCompareTo()
        /// This function compares the calling object with the argument passed
        /// Return value will indicate equality
        /// Only the DOD (date of death) variables are compared
        /// Any null references will cause a return of false
        /// </summary>
        /// <param name="pers">The person that will be compared</param>
        /// <returns>A bool, true indicates equality, false indicates inequality</returns>
        public bool DODCompareTo(Person pers)
        {
            bool b_IsSimilar = false;       //indicates equality, is the return variable
            //null sanity check
            if (s_DODDate == null || pers.s_DODDate == null)
            {
                //then there was a null reference somewhere, return false
                return false;       //indicate failure
            }
            //compare the date of death variables now
            if (s_DODDate == pers.s_DODDate)
            {
                //then the date of death variables are all equal, set the return
                b_IsSimilar = true;
            }
            else
            {
                //otherwise the date of death variables are not equal, set the return
                b_IsSimilar = false;
            }
            return b_IsSimilar;     //return the indicator for equality
        }
        #endregion
    }
}
