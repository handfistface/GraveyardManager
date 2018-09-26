using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GraveyardCommon
{
    /// <summary>
    /// Class: SqlHelper
    /// Author: John Kirschner
    /// Date: 09-23-2018
    /// Class Purpose:
    ///     This class helps support SQL functionality
    /// </summary>
    public static class SqlHelper
    {
        #region public static bool DoesDBExist(SqlConnection sql_Conn, string s_DatabaseName)
        /// <summary>
        /// Determines if the passed database name actually exists
        /// The passed SqlConnection will be closed after this query
        /// </summary>
        /// <param name="sql_Conn">The sql connection to use to determine if the DB exists</param>
        /// <param name="s_DatabaseName">The name of the DB</param>
        /// <returns>True if the DB exists, false if the DB does not exist</returns>
        public static bool DoesDBExist(SqlConnection sql_Conn, string s_DatabaseName)
        {
            bool b_DoesExist = false;       //indicates whether the DB exists
            //determine if the database name exists
            string s_DBExistance = "SELECT database_id FROM sys.databases WHERE Name = '" + s_DatabaseName + "'";      //create the command used to determine if the DB exists
            //create the sql command used for DB interaction
            using (SqlCommand sql_DBInteration = new SqlCommand(s_DBExistance, sql_Conn))
            {
                object o_QueryRes = sql_DBInteration.ExecuteScalar();       //execute the command and get the response
                int i_DatabaseID = 0;       //used to hold the database's existance
                if (o_QueryRes != null)
                {
                    //then there was a response from the database
                    int.TryParse(o_QueryRes.ToString(), out i_DatabaseID);      //try to parse the data into the database ID
                }
                if (i_DatabaseID > 0)
                    b_DoesExist = true;     //set the return
                sql_DBInteration.Connection.Close();       //close the connectino
            }
            return b_DoesExist;     //return whether the DB exists
        }
        #endregion

        #region public static bool DoesTableExist(SqlConnection sql_Conn, string s_TableName)
        /// <summary>
        /// Determines if a table exists for the passed connection, please not that the database will need previously assigned
        /// The pass sql_Conn will be closed after the query has been performed
        /// </summary>
        /// <param name="sql_Conn">The sql connection to test, make sure it has a database selected</param>
        /// <param name="s_TableName">The table name to check existance of</param>
        /// <returns></returns>
        public static bool DoesTableExist(SqlConnection sql_Conn, string s_TableName)
        {
            bool b_TableExists = false;     //indicates whether the table exists
            //create the command string to check for table existance
            string s_TableExistance = "SELECT CASE WHEN EXISTS((SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE table_name = '" + s_TableName + "')) THEN 1 ELSE 0 END";
            //create the sql command to use for the interaction
            using (SqlCommand sql_TableExistance = new SqlCommand(s_TableExistance, sql_Conn))
            {
                sql_TableExistance.Connection.Open();       //open the connection before executing the command
                object o_QueryRes = sql_TableExistance.ExecuteScalar();     //execute the command and get the response
                //determine if the query succeeded
                if (o_QueryRes != null)
                {
                    int i_QueryRes = 0;
                    if (int.TryParse(o_QueryRes.ToString(), out i_QueryRes))
                    {
                        //then the parse succeeded, the response is sitting in i_QueryRes
                        if (i_QueryRes == 1)
                            b_TableExists = true;       //then the table exists
                    }
                }
                sql_TableExistance.Connection.Close();
            }
            return b_TableExists;       //return the state of the table existance
        }
        #endregion

        #region public static bool CreateDB(SqlConnection sql_Conn, string s_DatabaseName)
        /// <summary>
        /// Creates a database with the passed string parameter
        /// </summary>
        /// <param name="sql_Conn">The connection to utilize for the creation</param>
        /// <param name="s_DatabaseName">The name of the database</param>
        /// <returns>True indicates that the DB was created, false indicates the DB was not created</returns>
        public static bool CreateDB(SqlConnection sql_Conn, string s_DatabaseName)
        {
            string s_ClassMethod = "SqlHelper.CreateDB()";
            bool b_CreatedDB = false;       //indicates if the database was created
            try
            {
                LogManager.WriteLine(s_ClassMethod + " -- Database [" + s_DatabaseName + "] does not exist. Creating database.");
                using (SqlCommand sql_CreateDB = new SqlCommand("CREATE DATABASE " + s_DatabaseName, sql_Conn))
                {
                    sql_CreateDB.Connection.Open();     //open the command before processing
                    sql_CreateDB.ExecuteNonQuery();     //run the command
                    b_CreatedDB = true;     //set the flag indicating the database was created
                }
            }
            catch (Exception ex)
            {
                //catch an exception
                LogManager.WriteLine(s_ClassMethod + " -- Database creation failed. Returning false");
            }
            return b_CreatedDB;
        }
        #endregion

        #region public static bool CreateTable(SqlConnection sql_Conn, string s_TableName, List<TableEntry> lte_TableEntries)
        /// <summary>
        /// Creates a table in the database connection specified, return will indicate the success of the creation
        /// The connection must have a database selected
        /// The sql_Conn will be closed after opening
        /// </summary>
        /// <param name="sql_Conn">The connection which will have the table created in, must have a DB selected</param>
        /// <param name="s_TableName">The name of the table to create</param>
        /// <param name="lte_TableEntries">The columns of the table that will be created</param>
        /// <returns>True indicates table creation success, false indicates failure</returns>
        public static bool CreateTable(SqlConnection sql_Conn, string s_TableName, List<TableEntry> lte_TableEntries)
        {
            string s_ClassMethod = "SqlHelper.CreateTable()";       //the class method that this is in
            bool b_TableCreated = false;        //indicates whether the table creation was successful
            try
            {
                string s_Command = "CREATE TABLE " + s_TableName + " ( ";       //used to run the command
                //have to use a for loop instead of foreach because we have to catch the last entry in the list and 
                //conditionally format the var declaration in the table
                for(int i=0; i < lte_TableEntries.Count; i++)
                {
                    s_Command += lte_TableEntries.ElementAt(i).ToString();
                    //make sure that the last entry in the list does not get the command added to the end of the command
                    if (i < (lte_TableEntries.Count - 1))
                        s_Command += ", ";
                }
                s_Command += " )";      //end the command
                LogManager.WriteLine("Creating table with the following command: [" + s_Command + "]");
                //using the command to make sure it closes properly when finished with the interaction
                using (SqlCommand sql_CreateTable = new SqlCommand(s_Command, sql_Conn))
                {
                    sql_CreateTable.Connection.Open();      //open the connection before running the command
                    sql_CreateTable.ExecuteNonQuery();      //run the create table command
                }
            }
            catch (Exception ex)
            {
                //catch the generic exception
                LogManager.WriteLine(s_ClassMethod + " -- Exception encountered while creating table. " + ex.ToString());
                b_TableCreated = false;     //indicate failure of the table
            }
            return b_TableCreated;
        }
        #endregion
    }
}
