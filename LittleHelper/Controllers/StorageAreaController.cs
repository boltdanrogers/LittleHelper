using LittleHelper.Models.StorageArea;
using LittleHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleHelper.Controllers
{
    [Authorize]
    public class StorageAreaController : Controller
    {
        // get all
        public ActionResult Index()
        {
            var service = new StorageAreaService();
            var model = service.GetStorageItems();

            return View(model);

        }//end of Index method

        //get create
        public ActionResult Create()
        {

            return View();
        }//end of get create

        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StorageAreaCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new StorageAreaService();
            if (service.CreateStorageArea(model))
            {
                TempData["SaveResult"] = "Your storage area was created";
                return RedirectToAction("Index");

            }//end of if created the storage area
            ModelState.AddModelError("", "Storage was not created");
            return View(model);

        }//end of post create


        //get single details
        public ActionResult Details(int id)
        {
            var service = new StorageAreaService();
            var model = service.GetStorageAreaById(id);
            return View(model);

        }//end of method get details

        //get edit
        public ActionResult Edit(int id)
        {
            var service = new StorageAreaService();
            var detail = service.GetStorageAreaById(id);
            var model = new StorageAreaEdit { StrorageId = detail.StorageId, Name = detail.Name, Size = detail.Size, Powered = detail.Powered, Spaces = detail.Spaces, SpaceNames = detail.SpaceNames };
            return View(model);

        }//end of get edit

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StorageAreaEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StrorageId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }//end of if id mismatch

            var service = new StorageAreaService();
            
            if (service.UpdateStorageArea(model))
            {
                TempData["SaveResult"] = "Your storage area was updated";
                return RedirectToAction("Index");

            }//end of if created the storage area
            ModelState.AddModelError("", "Storage was not updated");
            return View(model);

        }//end of post edit


        //get delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new FoodItemService();
            var model = service.GetFoodItemById(id);
            return View(model);

        }//end of get method delete



        //post delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStorage(int id)
        {
            var service = new StorageAreaService();
            service.DeleteStorageArea(id);

            TempData["SaveResult"] = "Your storage was deleted";
            return RedirectToAction("Index");

        }//end of method deleteStorage


    }//end of class StorageAreaController
}//end of name space