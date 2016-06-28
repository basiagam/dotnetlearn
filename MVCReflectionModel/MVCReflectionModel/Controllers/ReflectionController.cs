using MVCReflectionModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReflectionModel.Controllers
{
    public class ReflectionController : Controller
    {
        // GET: Reflection
        public ActionResult Assembly(string id)
        {
            AssemblyModel model = ModelSource.FromName(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}