using Ninject;
using SeminarMVC.Models;
using SeminarMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Controllers
{
    public class RestoranController : Controller
    {
        [Inject]
        public RestoranRepository RestoranRepository { get; set; }
        [Inject]
        public CityRepository CityRepository { get; set; }
        [Inject]
        public StaffRepository StaffRepository { get; set; }
        [Inject]
        public MenuRepository MenuRepository { get; set; }

        public ActionResult DeleteStaff(int id)
        {
            var k=this.StaffRepository.Find(id).RestoranID;
            this.StaffRepository.Delete(id);
            this.StaffRepository.Save();
            return RedirectToAction("Details",new { id=k});
        }

        public ActionResult DeleteMenu(int id)
        {
            var k = this.MenuRepository.Find(id).RestoranID;
            this.MenuRepository.Delete(id);
            this.MenuRepository.Save();
            return RedirectToAction("Details", new { id = k });
        }

        public ActionResult CreateStaff(int id)
        {
            return View(new Staff
            {
                RestoranID = id
            });
        }

        [HttpPost]
        public ActionResult CreateStaff(Staff model)
        {
            if (ModelState.IsValid)
            {
                var k = model.RestoranID;
                this.StaffRepository.Add(model, autoSave: true);
                return RedirectToAction("Details", new { id = k });
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult CreateMenu(int id)
        {
            return View(new Menu { RestoranID = id
            });
        }

        [HttpPost]
        public ActionResult CreateMenu(Menu model)
        {
            if (ModelState.IsValid)
            {
                var k = model.RestoranID;
                this.MenuRepository.Add(model, autoSave: true);
                return RedirectToAction("Details", new { id = k });
            }
            else
            {
                return View(model);
            }
                
        }
        [Route("sve")]
        public ActionResult Index()
        {
            return this.View(this.RestoranRepository.GetList(null));           
        }
        [HttpPost]
        public ActionResult IndexAjax(RestoranFilterModel model)
        {
            return PartialView("_IndexTable", this.RestoranRepository.GetList(model));
        }

        public ActionResult Create()
        {
            this.FillDropDownValues();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restoran model)
        {
            if (ModelState.IsValid)
            {
                this.RestoranRepository.Add(model, autoSave: true);

                return RedirectToAction("Index");
            }
            else
            {
                this.FillDropDownValues();
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            this.FillDropDownValues();

            var model = this.RestoranRepository.Find(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            var model = this.RestoranRepository.Find(id);
            var didUpdateModelSucceed = this.TryUpdateModel(model);

            if (didUpdateModelSucceed && ModelState.IsValid)
            {
                this.RestoranRepository.Update(model, autoSave: true);
                return RedirectToAction("Index");
            }

            this.FillDropDownValues();
            return View(model);
        }

        public ActionResult Details(int? id = null)
        {
            if (id == null)
                return View();

            var model = this.RestoranRepository.Find(id.Value);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            this.RestoranRepository.Delete(id);
            this.RestoranRepository.Save();
            return RedirectToAction("Index");
        }

        private void FillDropDownValues()
        {
            var possibleCities = this.CityRepository.GetList();
            var selectItems = new List<System.Web.Mvc.SelectListItem>();
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);
            
            foreach (var city in possibleCities)
            {
                listItem = new SelectListItem();
                listItem.Text = city.Ime;
                listItem.Value = city.ID.ToString();
                listItem.Selected = false;
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }
    }
}