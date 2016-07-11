using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Introduction.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "This is my default action";
        }

        public string Welcome(string name, int ID =1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + ID);
        }

    }
}