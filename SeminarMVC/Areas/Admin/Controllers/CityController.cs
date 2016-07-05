using Ninject;
using SeminarMVC.Models;
using SeminarMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        [Inject]
        public CityRepository CityRepository { get; set; }

        public ActionResult DeleteCity(int id)
        {
            this.CityRepository.Delete(id);
            this.CityRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult CreateCity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCity(Grad model)
        {
            if (ModelState.IsValid)
            {
                this.CityRepository.Add(model, autoSave: true);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Index()
        {
            var context = new Context();
            var cities = context.Grads.ToList();
            context.Dispose();
            return View(cities);
        }

        
        public ActionResult Details(int? id = null)
        {
            if (id == null)
                return View();

            var context = new Context();
            var model = context.Grads.Find(id.Value);
            context.Dispose();

            return View(model);
        }
        public ActionResult DetailsPartial(int? id = null)
        {
            if (id == null)
                return null;

            var context = new Context();
            var model = context.Grads.Find(id.Value);
            context.Dispose();

            if (model == null)
                return null;

            return PartialView("_DetailsPartial", model);
        }
    }

}