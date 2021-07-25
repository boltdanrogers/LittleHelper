using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Data
{
    public class RecipeFood
    {
        [Key]
        public int FoodNeededId { get; set; }
        
        [ForeignKey(nameof(RecipeEntry))]
        public int RecipeId { get; set; }
        public virtual RecipeEntry RecipeEntry { get; set; }

        [ForeignKey(nameof(FoodItem))]
        public int FoodId { get; set; }
        public virtual FoodItem FoodItem { get; set; }
        //[Required]
        public int Quantity { get; set; }
        //[Required]
        public string Unit { get; set; }

    }//end of class RecipeFood
}//end of name space
