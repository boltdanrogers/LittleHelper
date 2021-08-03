using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.FoodItem
{
    public class FoodItemEdit
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "Name must be at least two characters long")]
        [MaxLength(100,ErrorMessage ="Too many characters")]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
    }//end of class
}//end of name space
