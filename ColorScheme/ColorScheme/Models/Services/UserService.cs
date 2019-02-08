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
    public class UserService : IUserManager 
    {
        /// <summary>
        /// Bring in the DB
        /// </summary>
        private ColorSchemeDbContext _context { get; }

        public UserService(ColorSchemeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates new instance of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateUser(UserM user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Prompts are you sure notice when delete is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserM> DeleteOne(int id)
        {
            return await _context.User.FindAsync(id);
        }

        /// <summary>
        /// Deletes user and all asociated children
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);

            var children = _context.colorScheme.Where(f => f.UserMID == id);

            foreach (var i in children)
            {
                _context.colorScheme.Remove(i);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Shows the details of a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ColorSchemeM>> GetOneuser(int id)
        {
            return _context.colorScheme.Where(u=>u.UserMID == id).ToList();
        }

        /// <summary>
        /// Gets all users and sends to View
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserM>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        /// <summary>
        /// Shows the details when edit is selected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserM> UpdateOne(int id)
        {
            return await _context.User.FindAsync(id);
        }

        /// <summary>
        /// Allows for updating details of user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task Updateuser(UserM user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks to see if instance of User exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserExist(int id)
        {
           return _context.User.Any(i => i.ID == id);
        }

        /// <summary>
        /// Deletes one saved color scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteScheme(int id)
        {
            ColorSchemeController schemeController = new ColorSchemeController(_context);

            await schemeController.DeleteConfirmed(id);
        }
    }
}
