using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraveyardManager
{
    /// <summary>
    /// Author: John Kirschner
    /// Date: 05-10-2018
    /// Class Purpose:
    ///     This class is a miscellaneous collection of methods that don't really match up any order
    ///     I could not get my import from work functional with the ClrDump.dll for whatever reason, 
    ///     so I'm just going to be writing my own for debugging
    /// </summary>
    public static class Util
    {
        #region Util Variables
        private static RichTextBox rtxt_Stat = null;      //used in combination with rtxtWriteLine, initialize through Init() before calling rtxtWriteLine(), default value of null for error detection
        #endregion Util Variables

        #region public static void Init(RichTextBox rtxt)
        /// <summary>
        /// This method initializes the static Util class
        /// It is advised to call this before calling any other methods
        /// </summary>
        /// <param name="rtxt">A rich text box that will be used in conjuction with rtxtWriteLine()</param>
        public static void Init(RichTextBox rtxt)
        {
            rtxt_Stat = rtxt;       //set the static rich text box
        }
        #endregion public static void Init(RichTextBox rtxt)

        #region public static void rtxtWriteLine(string s_Line)
        /// <summary>
        /// This method prints s_Line to a rich text box, will print a new line at the end of the string automatically
        /// </summary>
        /// <param name="s_Line">The line that will be printed to the rich text box</param>
        /// <exception cref="NullReferenceException">Thrown whenever the rtxt_Stat is null</exception>
        public static void rtxtWriteLine(string s_Line)
        {
            //first do a sanity check that the rtxtWriteLine is looking a valid text box
            if(rtxt_Stat == null)
            {
                //then an invalid text box is being accessed, this is an issue
                throw new NullReferenceException("rtxt_Stat is not assigned to a valid value. Please call Init() before calling rtxtWriteLine()");
            }
            //then its fine to print a line of text
            //first check if Invoke is needed (if we are cross thread accessing the text box)
            if(rtxt_Stat.InvokeRequired)
            {
                //then this is a cross thread access
                rtxt_Stat.Invoke((MethodInvoker)delegate
                {
                    rtxt_Stat.Text += s_Line + Environment.NewLine;     //tack on a new line character onto the end of the text box
                });
            }
            else
            {
                //otherwise this is not a cross thread access, just access the text box normally
                rtxt_Stat.Text += s_Line + Environment.NewLine;     //tack on a new line character onto hte end of the text box
            }
        }
        #endregion public static void rtxtWriteLine(string s_Line)
    }
}
