using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraveyardManagerWebpage.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        #region public ActionResult Index()
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region public string Welcome(string name, int ID = 1)
        /// <summary>
        /// The action that is called ont he HelloWorldController whenever the Welcome path is navigated to
        /// If no additional path is stated in the URL then the name and ID will be empty strings
        /// The page can be navigated to and properly populated with the following url: HelloWorld/Welcome/John/2
        /// This URL will populate name and ID with John and 2 respectively
        /// </summary>
        /// <param name="name">The name to be displayed and set for the ViewBag</param>
        /// <param name="ID">The ID to be displayed and set for the ViewBag</param>
        /// <returns>An actionresult which contains the html required for printing the page out</returns>
        public ActionResult Welcome(string name, int ID = 1)
        {
            ViewBag.name = name;
            ViewBag.ID = ID;
            return View();
        }
        #endregion

    }
}