using NorthwindWebApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesBL _CategoriesBL { get; set; }
        

        // GET: Categories
        public ActionResult Index()
        {
            _CategoriesBL = new CategoriesBL();
            return View(_CategoriesBL.GetAll());
        }




    }
}