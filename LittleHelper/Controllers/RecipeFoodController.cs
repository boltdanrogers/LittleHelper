using LittleHelper.Models.RecipeFood;
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
    public class RecipeFoodController : Controller
    {
        // GET: RecipeFood
        //get get all
        public ActionResult Index()
        {
            var service = new RecipeFoodService();
            var model = service.GetRecipeFoods();
            return View(model);
        }//end of method index

        //get create
        public ActionResult Create()
        {

            return View();
        }


        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeFoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new RecipeFoodService();
            if (service.CreateRecipeFood(model))
            {
                TempData["SaveResutl"] = "The RecipeFood was created";
                return RedirectToAction("Index");

            }//end of if create

            //bad
            ModelState.AddModelError("", "The RecipeFood was not created");
            return View(model);

        }//end of post method create


        //get one
        public ActionResult Details(int id)
        {
            var service = new RecipeFoodService();
            var model = service.GetRecipeFoodById(id);

            return View(model);

        }//end of method get details

        //get edit
        public ActionResult Edit(int id)
        {
            var service = new RecipeFoodService();
            var detail = service.GetRecipeFoodById(id);
            var model = new RecipeFoodEdit { RecipeFoodId = detail.RecipeFoodId, FoodId = detail.FoodId, RecipeId = detail.RecipeId, Quantity = detail.Quantity, Unit = detail.Unit };
            return View(model);

        }//end of get edit

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeFoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RecipeFoodId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);

            }//end of id mismatch
            var service = new RecipeFoodService();
            if(service.UpdateRecipeFood(model))
            {
                TempData["SaveResult"] = "The RecipeFood was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Recipe was not Updated");
            return View(model);

        }//end of post method edit


        //get delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new RecipeFoodService();
            var model = service.GetRecipeFoodById(id);
            return View(model);

        }//end of get delete

        //post delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipeFood(int id)
        {
            var service = new RecipeFoodService();
            service.DeleteRecipeFood(id);

            TempData["SaveResult"] = "The RecipeFood was deleted";
            return RedirectToAction("Index");


        }//end of post deleteRecipeFood method

    }//end of class RecipeFoodController
}//end of name space