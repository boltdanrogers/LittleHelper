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




        // GET: FoodItem
        public ActionResult Index()
        {
            return View();
        }//end of method Index











    }//end of class FoodItemController
}//end of name space