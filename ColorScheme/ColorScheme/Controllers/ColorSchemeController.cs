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

namespace ColorScheme.Controllers
{
    public class ColorSchemeController : Controller
    {
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

                var result = await response.Content.ReadAsStringAsync();

                var colors = JsonConvert.DeserializeObject(result);

                return View(colors);
            }
        }


        ///// <summary>
        ///// Saves color scheme reveived from API
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name")] ColorSchemeM colorScheme)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _context.SaveColorScheme(colorScheme);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(colorScheme);
        //}
         
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