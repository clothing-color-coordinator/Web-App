using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ColorScheme.Models
{
    public class ColorScheme
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int SchemeType { get; set; }

        public string ColorSchemes { get; set; }

        
    }

    //enum
    public enum SchemeType
    {
        typeOne = 0,
        typeTwo = 1,
        typeThree = 2

    }
}
