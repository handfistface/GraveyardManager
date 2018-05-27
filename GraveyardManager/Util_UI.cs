using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraveyardManager
{
    /// <summary>
    /// This is a static class which houses a majority of utility functionality for the user interface
    /// </summary>
    public static class Util_UI
    {

        #region public static string ParseOnlyInt(TextBox txt)
        /// <summary>
        /// ParseOnlyInt()
        /// Parse out the text from the text box and eliminates any characters that are not ints
        /// Will play the ./audoi/Windows Ding.wav whenever a non int character is found
        /// </summary>
        /// <param name="txt">The text box that will have its .Text property parsed out</param>
        /// <returns></returns>
        public static string ParseOnlyInt(TextBox txt)
        {
            string s_Ret = ParseOnlyIntHelper(txt.Text);
            return s_Ret;
        }
        #endregion public static string ParseOnlyInt(TextBox txt)
        #region public static string ParseOnlyInt(TextBox txt, int i_Length)
        /// <summary>
        /// ParseOnlyInt()
        /// Parses out the text from the text box and eliminates any characters that are not ints
        /// Will play the ./audio/Windows Ding.wav whenever a non int character is found
        /// </summary>
        /// <param name="txt">The text box that will have its .Text property parsed out</param>
        /// <param name="i_Length">The length of the .Text to parse, will create a substring based on the length and only parse that information</param>
        /// <returns></returns>
        public static string ParseOnlyInt(TextBox txt, int i_Length)
        {
            string s_Ret = ParseOnlyIntHelper(txt.Text.Substring(0, i_Length));      //pass the info to the private helper function
            return s_Ret;
        }
        #endregion public static string ParseOnlyInt(TextBox txt, int i_Length)
        #region private static string ParseOnlyIntHelper(string s_Text)
        /// <summary>
        /// ParseOnlyIntHelper()
        /// Parses out the text and eliminates any characters that are not ints
        /// Will play the Windows Ding.wav whenever a non int character is found
        /// </summary>
        /// <param name="s_Text"></param>
        /// <returns></returns>
        private static string ParseOnlyIntHelper(string s_Text)
        {
            string s_Ret = "";      //used to hold the new return
            bool b_HavePlayedBonk = false;
            //loop through each character in the orginal string
            foreach (char c in s_Text)
            {
                //make sure the character is actually an int
                if (c >= '0' && c <= '9')
                {
                    //then this is a proper int, just append it to the end of the ret
                    s_Ret += c;
                }
                else
                {
                    //otherwise this is not a valid character
                    //if I have not played the bonk sound yet...
                    if(!b_HavePlayedBonk)
                    {
                        using (SoundPlayer sp = new SoundPlayer("./audio/Windows Ding.wav"))
                            sp.Play();
                        b_HavePlayedBonk = true;
                    }
                    //let the loop continue to the next 
                }
            }
            return s_Ret;
        }
        #endregion privaet static string ParseOnlyIntHelper(string s_Text
    }
}
