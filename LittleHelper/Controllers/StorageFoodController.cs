using LittleHelper.Models.StorageFood;
using LittleHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleHelper.Controllers
{
    [Authorize]
    public class StorageFoodController : Controller
    {
        // GET: StorageFood
        //get get all
        public ActionResult Index()
        {
            var service = new StorageFoodService();
            var model = service.GetStorageFoods();
            return View(model);
        }//end of method index

        //get create
        public ActionResult Create()
        {
            //the lists for our dropdown menu
            ViewBag.FoodItemList = new FoodItemService().GetFoodItems();

            ViewBag.StorageAreaList = new StorageAreaService().GetStorageAreas();
            
            return View();
        }


        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StorageFoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new StorageFoodService();
            if (service.CreateStorageFood(model))
            {
                TempData["SaveResutl"] = "The StorageFood was created";
                return RedirectToAction("Index");

            }//end of if create

            //bad
            ModelState.AddModelError("", "The StorageFood was not created");
            return View(model);

        }//end of post method create


        //get one
        public ActionResult Details(int id)
        {
            var service = new StorageFoodService();
            var model = service.GetStorageFoodById(id);

            return View(model);

        }//end of method get details

        //get edit
        public ActionResult Edit(int id)
        {
            var service = new StorageFoodService();
            var detail = service.GetStorageFoodById(id);
            var model = new StorageFoodEdit { StorageFoodId = detail.StorageFoodId, FoodId = detail.FoodId, StorageId = detail.StorageId, Quantity = detail.Quantity, Unit = detail.Unit };
            return View(model);

        }//end of get edit

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StorageFoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StorageFoodId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);

            }//end of id mismatch
            var service = new StorageFoodService();
            if (service.UpdateStorageFood(model))
            {
                TempData["SaveResult"] = "The StorageFood was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Storage was not Updated");
            return View(model);

        }//end of post method edit


        //get delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new StorageFoodService();
            var model = service.GetStorageFoodById(id);
            return View(model);

        }//end of get delete

        //post delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStorageFood(int id)
        {
            var service = new StorageFoodService();
            service.DeleteStorageFood(id);

            TempData["SaveResult"] = "The StorageFood was deleted";
            return RedirectToAction("Index");


        }//end of post deleteStorageFood method



    }//end of class StorageFoodController
}//end of name space