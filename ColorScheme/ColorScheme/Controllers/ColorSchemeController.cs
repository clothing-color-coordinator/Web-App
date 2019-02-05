using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColorScheme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColorScheme.Models;
using ColorScheme.Models.Interfaces;

namespace ColorScheme.Controllers
{
    public class ColorSchemeController : Controller
    {
        private readonly IColorSchemeManager _context;

        public ColorSchemeController(IColorSchemeManager context)
        {
            _context = context;
        }


        public async Task <IActionResult> Index()
        {
            //return View(await _context.GetColorSchemes());
            return View();
        }

        /// <summary>
        /// Displays the details of the Color Scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var colors = await _context.GetOneColorScheme(id);
            if (colors == null)
            {
                return NotFound();
            }

            return View(colors);
        }


        /// <summary>
        /// Saves color scheme reveived from API
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ColorSchemeM colorScheme)
        {
            if (ModelState.IsValid)
            {
                await _context.SaveColorScheme(colorScheme);
                return RedirectToAction(nameof(Index));
            }
            return View(colorScheme);
        }

        /// <summary>
        /// Prompts an are you sure warning when delete option is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {

            var colorScheme = await _context.DeleteOne(id);

            if (colorScheme == null)
            {
                return NotFound();
            }

            return View(colorScheme);
        }

        /// <summary>
        /// Deletes selected color Scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteColorScheme(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}