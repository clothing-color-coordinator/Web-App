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
using System.Drawing;
namespace ColorScheme.Controllers
{
    public class ColorSchemeController : Controller
    {
        private readonly ColorSchemeDbContext _context;

        public ColorSchemeController(ColorSchemeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// gets user request and redirects it to the results method
        /// </summary>
        /// <param name="SchemeType"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(string SchemeType, string color)
        {
            return RedirectToAction("Results", new { SchemeType, color });
        }



        public async Task <IActionResult> Index()
        {
            
            return View();
        }

        /// <summary>
        /// Makes a call to the API, then builds a object and sends it to the view
        /// </summary>
        /// <param name="SchemeType"></param>
        /// <param name="color"></param>
        /// <returns>Object</returns>
        [HttpGet]
        public async Task<IActionResult> Results(string SchemeType, string color)

        {
            if (color != null)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        //call made to the api
                        client.BaseAddress = new Uri("https://colorwheelapi20190205024526.azurewebsites.net");

                        var response = await client.GetAsync($"/api/Get{SchemeType}/{color}");

                        response.EnsureSuccessStatusCode();
                        //Reades JSON file received from API
                        string result = await response.Content.ReadAsStringAsync();

                        dynamic colors = JsonConvert.DeserializeObject(result);
                        //Build object
                        ColorSchemeM schemeM = new ColorSchemeM();
                        schemeM.SchemeType = SchemeType;
                        schemeM.ColorSearched = colors.palette[0].colorName;
                        schemeM.ColorSearchedHex = colors.palette[0].hexCode;
                        schemeM.ColorReceived = colors.palette[1].colorName;
                        schemeM.ColorReceivedHex = colors.palette[1].hexCode;
                        if (colors.palette.Count > 2)
                        {
                            schemeM.ColorReceivedTwo = colors.palette[2].colorName;
                            schemeM.ColorReceivedHexTwo = colors.palette[2].hexCode;
                        }
                        else
                        {
                            schemeM.ColorReceivedTwo = "NA";
                            schemeM.ColorReceivedHexTwo = "NA";
                        }
                        ViewData["ID"] = new SelectList(_context.User, "ID", "Name");
                        return View(schemeM);

                    }
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));

        }


        // <summary>
        // Saves color scheme reveived from API
        // </summary>
        // <param name = "user" ></ param >
        // < returns ></ returns >
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserMID,SchemeType,ColorSearched,ColorSearchedHex,ColorReceived,ColorReceivedHex,ColorReceivedTwo,ColorReceivedHexTwo")] ColorSchemeM colorScheme)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(colorScheme);
                await _context.SaveChangesAsync();
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

            var colorScheme = await _context.colorScheme.FindAsync(id);

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
            var scheme = await _context.colorScheme.FindAsync(id);
            _context.colorScheme.Remove(scheme);
            await _context.SaveChangesAsync();
            var path = "../User/Details";
            return RedirectToAction(path);
        }


    }
}