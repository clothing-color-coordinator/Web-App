using System;
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

        public int UserMID { get; set; }

        public string SchemeType { get; set; }

        public string ColorSchemes { get; set; }
        
    }

    //enum
    public enum SchemeType
    {
        [Display(Name = "Complementary")]
        ComplimentaryPalette,
        [Display(Name = "Analogous")]
        AnalogousPalette,
        [Display(Name = "Triadic")]
        TriadicPalette 

    }
}
