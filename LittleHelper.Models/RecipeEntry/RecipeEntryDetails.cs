using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.RecipeEntry
{
    public class RecipeEntryDetails
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Instructions { get; set; }
        //[Required]
        public bool Cooked { get; set; }
        //[Required]
        public bool Cooled { get; set; }

        public ICollection<LittleHelper.Data.RecipeFood> ListOfRecipeFoods { get; set; }

    }//end of class
}//end of name space
