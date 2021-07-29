using LittleHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Models.StorageArea
{
    public class StorageAreaEdit
    {
        [Required]
        public int StrorageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Sizes Size { get; set; }
        //[Required]
        public bool Powered { get; set; }
        //[Required]
        public int Spaces { get; set; }
        //[Required]
        public string SpaceNames { get; set; }

    }//end of class
}//end of name space
