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
        // GET: RecipeEntry
        public ActionResult Index()
        {
            return View();
        }//end of method Index




    }//end of class RecipeEntryController
}//end of name space