using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.RecipeEntry
{
    public class RecipeEntryEdit
    {

        [Required]
        public int RecipeId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least two characters long")]
        [MaxLength(100, ErrorMessage = "Too many characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "instructions must be at least two characters long")]
        [MaxLength(8000, ErrorMessage = "Too many characters")]
        public string Instructions { get; set; }
        //[Required]
        public bool Cooked { get; set; }
        //[Required]
        public bool Cooled { get; set; }


    }//end of class 
}//name space
