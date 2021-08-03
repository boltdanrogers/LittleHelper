using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.StorageFood
{
    public class StorageFoodEdit
    {
        public int StorageFoodId { get; set; }
        public int StorageId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

    }//end of class StorageFoodEdit
}//end of name space
