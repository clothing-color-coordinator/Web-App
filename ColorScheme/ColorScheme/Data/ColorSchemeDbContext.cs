using ColorScheme.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorScheme.Data
{
    public class ColorSchemeDbContext : DbContext
    {
        public ColorSchemeDbContext(DbContextOptions<ColorSchemeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<UserM> User { get; set; }

        public DbSet<ColorSchemeM> colorScheme { get; set; }

    }
}
