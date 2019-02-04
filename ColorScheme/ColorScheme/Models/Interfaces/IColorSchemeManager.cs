using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorScheme.Models.Interfaces
{
    public interface IColorSchemeManager
    {
        //Creates new instance of ColorSchemeM
        Task SaveColorScheme(ColorSchemeM colorScheme);

        //displays all ColorSchemes
        Task<IEnumerable<ColorSchemeM>> GetColorSchemes();

        //Displays details of ColorScheme
        Task<ColorSchemeM> GetOneColorScheme(int id);


        //displays delete view
        Task<ColorSchemeM> DeleteOne(int id);

        //deletes ColorScheme
        Task DeleteColorScheme(int ID);

        //checks if instance exists
        bool ColorSchemeExist(int id);
    }
}
