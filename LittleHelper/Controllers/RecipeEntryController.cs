using LittleHelper.Models.RecipeEntry;
using LittleHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleHelper.Controllers
{
    [Authorize]
    public class RecipeEntryController : Controller
    {

        //if possible make this method not need authorization
        // get all
        public ActionResult Index()
        {
            var service = new RecipeEntryService();
            var model = service.GetRecipeEntries();
            return View(model);
        }//end of method Index

        //get create
        public ActionResult Create()
        {
            return View();
        }//end of method get create
        
        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeEntryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new RecipeEntryService();
            if (service.CreateRecipeEntry(model))
            {
                TempData["SaveResult"] = "Your recipe was created";
                return RedirectToAction("Index");

            }//end of if created the recipe
            ModelState.AddModelError("", "Recipe was not created");
            return View(model);


        }//end of method post Create

        //get single details
        public ActionResult Details(int id)
        {
            var service =new RecipeEntryService();
            var model = service.GetRecipeEntryById(id);

            return View(model);
        }//end of method get details
        
        //get edit
        public ActionResult Edit(int id)
        {
            var service = new RecipeEntryService();
            var detail = service.GetRecipeEntryById(id);
            var model = new RecipeEntryEdit { RecipeId = detail.RecipeId, Name = detail.Name, Instructions = detail.Instructions, Cooked = detail.Cooked, Cooled = detail.Cooled };

            return View(model);
        }//end of method get edit
        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEntryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("","ID mismatch");
                return View(model);

            }//end of id mismatch

            var service = new RecipeEntryService();
            if (service.UpdateRecipeEntry(model))
            {
                TempData["SaveResult"] = "The Recipe was updated";
                return RedirectToAction("Index");

            }//end of if updated

            ModelState.AddModelError("", "The Recipe was not updated");
            return View(model);

        }//end method post edit

        //get delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new RecipeEntryService();
            var model = service.GetRecipeEntryById(id);

            return View(model);
        }//end of method get delete
        
        //post delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipeEntry(int id)
        {
            var service = new RecipeEntryService();
            service.DeleteRecipeEntry(id);

            TempData["SaveResult"] = "The Recipe was deleted";
            return RedirectToAction("Index");
        }//end of method post delete


    }//end of class RecipeEntryController
}//end of name space