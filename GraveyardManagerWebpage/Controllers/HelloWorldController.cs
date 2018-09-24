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
        //public ActionResult Index()
        public string Index()
        {
            return "This is my <b>default</b> action.";
            //return View();
        }

        //GET: /HelloWorld/Welcome/
        public string Welcome()
        {
            return "This is the welcome action method";
        }
    }
}