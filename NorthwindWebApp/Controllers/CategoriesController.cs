using NorthwindWebApp.BusinessLayer;
using NorthwindWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesBL _CategoriesBL { get; set; }

        public CategoriesController(ICategoriesBL CategoriesBL) 
        {
            _CategoriesBL = CategoriesBL;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_CategoriesBL.GetAll());
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Categories category)
        {

            if (category != null &&
                ModelState.IsValid)
            {
                this._CategoriesBL.Create(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this._CategoriesBL.Get(id.Value);
                return View(category);
            }
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description")] Categories category)
        {
            if (category != null &&
                ModelState.IsValid)
            {
                this._CategoriesBL.Update(category);
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }


        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this._CategoriesBL.Get(id.Value);
                return View(category);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                this._CategoriesBL.Delete(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }


       
    }
}