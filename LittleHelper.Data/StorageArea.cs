﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Data
{
    //need an enum here for the size of the storage
    public enum Sizes
    {
        small, medium, large
    }//end of enum Sizes



    public class StorageArea
    {
        [Key]
        public int StorageId { get; set; }
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

    }//end of class Storage Area
}//end of name space
