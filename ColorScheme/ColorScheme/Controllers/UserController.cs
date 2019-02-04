using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColorScheme.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColorScheme.Models;

namespace ColorScheme.Controllers
{
    public class UserController : Controller
    {
        private readonly ColorSchemeDbContext _context;

        public UserController(ColorSchemeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Shows all users on home page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        /// <summary>
        /// Displays the details of the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Displays the create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new Instance of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Displays edit view when edit option is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
           
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Allows user to edit User instance
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] User user)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Prompts an are you sure warning when delete option is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
         
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Deletes selected user and all connected Color Schemes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);

            var children = _context.colorScheme.Where(f => f.UserID == id);

            foreach (var i in children)
            {
                _context.colorScheme.Remove(i);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks to see if instance of User exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True or False</returns>
        private bool UserExists(int id)
        {
            return _context.User.Any(i => i.ID == id);
        }





    }
}