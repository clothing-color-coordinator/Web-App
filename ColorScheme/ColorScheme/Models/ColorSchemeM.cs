﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ColorScheme.Models
{
    public class ColorSchemeM
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int SchemeType { get; set; }

        public string ColorSchemes { get; set; }

        
    }

    //enum
    public enum SchemeType
    {
        [Display(Name = "Complementary")]
        typeOne = 0,
        [Display(Name = "Analogous")]
        typeTwo = 1,
        [Display(Name = "Triadic")]
        typeThree = 2

    }
}
