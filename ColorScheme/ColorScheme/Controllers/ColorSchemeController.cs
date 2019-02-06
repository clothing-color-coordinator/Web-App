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
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace ColorScheme.Controllers
{
    public class ColorSchemeController : Controller
    {
        private readonly ColorSchemeDbContext _context;

        public ColorSchemeController(ColorSchemeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(string SchemeType, string color)
        {
            return RedirectToAction("Results", new { SchemeType, color });
        }



        public async Task <IActionResult> Index()
        {
            //return View(await _context.GetColorSchemes());
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Results(string SchemeType, string color)

        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://colorwheelapi20190205024526.azurewebsites.net");

                var response = await client.GetAsync($"/api/Get{SchemeType}/{color}");

                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                dynamic colors = JsonConvert.DeserializeObject(result);
                
                ColorSchemeM schemeM = new ColorSchemeM();
                schemeM.ColorSearched = colors.palette[0].colorName;
                schemeM.ColorSearchedHex = colors.palette[0].hexCode;
                schemeM.ColorReceived = colors.palette[1].colorName;
                schemeM.ColorReceivedHex = colors.palette[1].hexCode;
                if (colors.palette.Count > 2) { 
                schemeM.ColorReceivedTwo = colors.palette[2].colorName;
                schemeM.ColorReceivedHexTwo = colors.palette[2].hexCode;
                }
                else
                {
                    schemeM.ColorReceivedTwo = "NA";
                    schemeM.ColorReceivedHexTwo = "NA";
                }
                return View(schemeM);

            }


        }


        // <summary>
        // Saves color scheme reveived from API
        // </summary>
        // <param name = "user" ></ param >
        // < returns ></ returns >
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ColorSchemeM colorScheme)
        {
            if (ModelState.IsValid)
            {
                ViewData["ID"] = new SelectList(_context.User, "ID", "Name");
                _context.Add(colorScheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorScheme);
        }

        ///// <summary>
        ///// Prompts an are you sure warning when delete option is selected
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IActionResult> Delete(int id)
        //{

        //    var colorScheme = await _context.DeleteOne(id);

        //    if (colorScheme == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(colorScheme);
        //}

        ///// <summary>
        ///// Deletes selected color Scheme
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _context.DeleteColorScheme(id);
        //    return RedirectToAction(nameof(Index));
        //}


    }
}