using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.RecipeFood
{
    public class RecipeFoodDetails
    {

        public int RecipeFoodId { get; set; }
        public int RecipeId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }


    }//end of class RecipeFoodDetails
}//end of name space
