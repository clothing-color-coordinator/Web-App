using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColorScheme.Data;
using ColorScheme.Models.Interfaces;
using ColorScheme.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ColorScheme.Models.Services
{
    public class ColorSchemeService : IColorSchemeManager
    {
        /// <summary>
        /// Bring in the DB
        /// </summary>
        private ColorSchemeDbContext _context { get; }

        public ColorSchemeService(ColorSchemeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves color scheme returned from API
        /// </summary>
        /// <param name="colorScheme"></param>
        /// <returns></returns>
        public async Task SaveColorScheme(ColorSchemeM colorScheme)
        {
            _context.Add(colorScheme);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Displays all saved schemes to view
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ColorSchemeM>> GetColorSchemes()
        {
            return await _context.colorScheme.ToListAsync();
        }

        /// <summary>
        /// Prompt are you sure warning when delete is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ColorSchemeM> DeleteOne(int id)
        {
            return await _context.colorScheme.FindAsync(id);
        }

        /// <summary>
        /// Deletes a saved color scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteColorScheme(int id)
        {
            var scheme = await _context.colorScheme.FindAsync(id);
            _context.colorScheme.Remove(scheme);
            await _context.SaveChangesAsync();
        }

    }
}
