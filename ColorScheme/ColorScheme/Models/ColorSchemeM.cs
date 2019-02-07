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

        public string ColorSearched { get; set; }

        public string ColorSearchedHex { get; set; }

        public string ColorReceived { get; set; }

        public string ColorReceivedHex { get; set; }

        public string ColorReceivedTwo { get; set; }

        public string ColorReceivedHexTwo { get; set; }

    }

    //enum
    public enum SchemeType
    {
        [Display(Name = "Complementary Palette")]
        ComplementaryPalette,

        [Display(Name = "Split Complementary Palette")]
        SplitComplementaryPalette,

        [Display(Name = "Triadic Palette")]
        TriadicPalette,

        [Display(Name = "Analogous Palette")]
        AnalogousPalette

    }
}
