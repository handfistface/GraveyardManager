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
    ///     This GlobalVariables class is a static reference to all global variables
    ///     This ensures that an application wide varaible may be accessed at any time by any class
    /// </summary>
    public static class GlobalVariables
    {
        public const string s_ApplicationVersion = "0.1";       //the application version
        public static bool b_EnableDebugging = true;        //dont use a constant because the compiler complains when I use it in an if statement
    }
}
