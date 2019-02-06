using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ColorScheme.Models
{
    public class UserM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<ColorSchemeM> colorSchemes { get; set; }
    }
}
