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
            return View();
        }//end of method Index

        //get create
        public ActionResult Create()
        {
            return View();
        }//end of method
        //post create

        //get single details
        public ActionResult Details()
        {
            return View();
        }//end of method
        //get edit
        public ActionResult Edit()
        {
            return View();
        }//end of method
        //post edit

        //get delete
        public ActionResult Delete()
        {
            return View();
        }//end of method
        //post delete

    }//end of class RecipeEntryController
}//end of name space