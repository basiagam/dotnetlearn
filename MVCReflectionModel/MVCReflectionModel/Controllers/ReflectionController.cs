// Listing 20-34
using System.Web.Mvc;
using MVCReflectionModel.Models;

namespace MvcReflectionView.Controllers
{
    public class ReflectionController : Controller
    {
        //public ActionResult Assembly(string id)
        // Pierwszy wiersz zmodyfikowany na potrzeby listingu 20-41
        public ActionResult Assembly(string assemblyName)
        {
            AssemblyModel model = ModelSource.FromName(assemblyName);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // Listing 20-38
        //public ActionResult Type(string id, string typeName)
        // Pierwszy wiersz zmodyfikowany na potrzeby listingu 20-41
        public ActionResult Type(string assemblyName, string typeName)
        {
            TypeModel model = ModelSource.GetTypeModel(assemblyName, typeName);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // Listing 20-46
        public ActionResult Index()
        {
            return View(ModelSource.GetReflectionModel());
        }

    }
}
