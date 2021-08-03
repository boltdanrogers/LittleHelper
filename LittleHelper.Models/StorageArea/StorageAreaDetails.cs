using LittleHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.StorageArea
{
    public class StorageAreaDetails
    {
        public int StorageId { get; set; }
        public string Name { get; set; }
        public Sizes Size { get; set; }
        public bool Powered { get; set; }
        public int Spaces { get; set; }
        public string SpaceNames { get; set; }

    }//end of class
}//end of name space
