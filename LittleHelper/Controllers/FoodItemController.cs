using LittleHelper.Models.FoodItem;
using LittleHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleHelper.Controllers
{
    //need to add the authorize annotation 
    [Authorize]
    //take away or comment out if un logged in users can see the page. might be useful to see about having the index not require that, but the create page need it.... hmmmm wait those are all here. quick search shows the annotation

    public class FoodItemController : Controller
    {

        //start with the private method to create the instance of the FoodItem service
        //though that was more important because it was the same two lines in the last project
        //this time there is no line to set the GUID, so we don't save any time or code by creating a private method
        //it was neat to see visual studio extract the method though

        // GET: FoodItem
        //get all
        //this is one I'd like to not need to be authorized so anyone can see what foods are known to the database
        public ActionResult Index()
        {
            //for our index view of the database, we need to instantiate the service and get all the FoodItems
            var service = new FoodItemService();
            var model = service.GetFoodItems();
            return View(model);
        }//end of method Index


        //get create
        //simplest as there is no model, therefor no need to create a service, only return an empty view call
        public ActionResult Create()
        {

            return View();

        }//end of get create method

        //post create
        //the anti forgery token is sent from the create view 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodItemCreate model)
        {
            //this method is passed a completed FoodCreateItem but we have some checks to be safe

            if (!ModelState.IsValid) return View(model);

            var service = new FoodItemService();

            //right now just leaving it this basic way but probably will change the create method on the service 
            //to return the id not just true, and change this method so that we redirect to the details page of the created food

            if (service.CreateFoodItem(model))
            {

                TempData["SaveResult"] = "Your food was created";
                return RedirectToAction("Index");

            }//end of if created food item

            //if get here bad hehehe
            ModelState.AddModelError("", "Food was not created");
            return View(model);

        }//end of post create method

        //get one
        public ActionResult Details(int id)
        {
            //also simple, just the barest bit more
            //we need the service to get the model and then pass it to the view
            var service = new FoodItemService();
            var model = service.GetFoodItemById(id);
            return View(model);

        }//end of method details


        //get edit
        public ActionResult Edit(int id)
        {
            var service = new FoodItemService();
            var detail = service.GetFoodItemById(id);
            var model = new FoodItemEdit { FoodId = detail.FoodId, Name = detail.Name,Unit = detail.Unit };
            return View(model);

        }//end of get edit

        //post edit
        //the anti forgery token is sent from the edit view 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodItemEdit model)// figure out how this method is called, where it knows to pass in two things from the view
        {
            if (!ModelState.IsValid) return View(model);

            if(model.FoodId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }//end of if id mismatch

            var service = new FoodItemService();
            if (service.UpdateFoodItem(model))
            {
                TempData["SaveResult"] = "The Food was updated";
                return RedirectToAction("Index");
            }//end of if 
            //if get here bad
            ModelState.AddModelError("", "the Food was not updated");
            return View(model);

        }//end of post method edit


        //get delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new FoodItemService();
            var model = service.GetFoodItemById(id);
            return View(model);

        }//end of get method delete



        //post delete
        //the anti forgery token is sent from the create view 
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new FoodItemService();
            service.DeleteFoodItem(id);

            TempData["SaveResut"] = "The Food was deleted";
            return RedirectToAction("Index");

        }//end post delete



    }//end of class FoodItemController
}//end of name space