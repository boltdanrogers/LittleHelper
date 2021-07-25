using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Data
{
public    class StorageFood
    {
        [Key]
        public int FoodStoredId { get; set; }
        
        [ForeignKey(nameof(StorageArea))]
        public int StorageId { get; set; }
        public virtual StorageArea StorageArea { get; set; }
        
        [ForeignKey(nameof(FoodItem))]
        public int FoodId { get; set; }
        public virtual FoodItem FoodItem { get; set; }
        //[Required]
        public int Quantity { get; set; }
        //[Required]
        public string Unit { get; set; }

    }//end of class StorageFood
}//end of name space
