using System;
using Xunit;
using ColorScheme.Controllers;
using ColorScheme.Data;
using ColorScheme.Models;
using ColorScheme.Models.Interfaces;
using ColorScheme.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject1
{
    public class ColorScheme
    {
        [Fact]
        public void GetPropertiesWork()
        {
            //Arrange
            ColorSchemeM color = new ColorSchemeM();
            color.UserMID = 1;


            //Assert
            Assert.Equal(1, color.UserMID);

        }

        [Fact]
        public void GetPropertiesWorkAgain()
        {
            //Arrange
            ColorSchemeM color = new ColorSchemeM();
            color.UserMID = 1;
            color.SchemeType = "TriadicPalette";


            //Assert
            Assert.Equal("TriadicPalette", color.SchemeType);

        }

        [Fact]
        public void SetPropertiesWork()
        {
            //Arrange
            ColorSchemeM color = new ColorSchemeM();
            color.UserMID = 1;
            color.SchemeType = "TriadicPalette";

            //Act
            color.UserMID = 2;

            //Assert
            Assert.Equal(2, color.UserMID);

        }

        [Fact]
        public void SetPropertiesWorksAgain()
        {
            //Arrange
            ColorSchemeM color = new ColorSchemeM();
            color.UserMID = 1;
            color.SchemeType = "ComplementaryPalette";

            //Act
            color.SchemeType = "TriadicPalette";

            //Assert
            Assert.Equal("TriadicPalette", color.SchemeType);

        }

        [Fact]
        public async void CreateColorSchemeWorks()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("CreateColorScheme").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                ColorSchemeM color = new ColorSchemeM();
                color.UserMID = 1;
                color.SchemeType = "TriadicPalette";

                // Act
                ColorSchemeService service = new ColorSchemeService(context);

                await service.SaveColorScheme(color);
                var created = context.colorScheme.FirstOrDefault(u => u.UserMID == color.UserMID);

                // Assert
                Assert.Equal(color, created);

            }
        }

        [Fact]
        public async void CreateColorSchemeWorksAgain()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("CreateColorScheme").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                ColorSchemeM color = new ColorSchemeM();
                color.UserMID = 2;
                color.SchemeType = "TriadicPalette";

                // Act
                ColorSchemeService service = new ColorSchemeService(context);

                await service.SaveColorScheme(color);
                var created = context.colorScheme.FirstOrDefault(u => u.UserMID == color.UserMID);

                // Assert
                Assert.Equal(color, created);

            }
        }

        [Fact]
        public async void DeleteColorSchemeWorks()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("DeleteColorScheme").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                ColorSchemeM color = new ColorSchemeM();
                color.UserMID = 1;
                color.SchemeType = "TriadicPalette";

                // Act
                ColorSchemeService service = new ColorSchemeService(context);

                await service.SaveColorScheme(color);
                await service.DeleteColorScheme(1);

                var deleted = context.colorScheme.FirstOrDefault(u => u.UserMID == color.UserMID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteColorSchemeWorksAgain()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("DeleteColorScheme").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                ColorSchemeM color = new ColorSchemeM();
                color.UserMID = 2;
                color.SchemeType = "TriadicPalette";

                // Act
                ColorSchemeService service = new ColorSchemeService(context);

                await service.SaveColorScheme(color);
                await service.DeleteColorScheme(2);

                var deleted = context.colorScheme.FirstOrDefault(u => u.UserMID == color.UserMID);

                // Assert
                Assert.Null(deleted);

            }
        }
    }
}
