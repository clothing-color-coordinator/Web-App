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
    public class User
    {
        [Fact]
        public void GetUserPropertiesWork()
        {
            //Arrange
            UserM user = new UserM();
            user.ID = 1;

            //Assert
            Assert.Equal(1, user.ID);
           
        }

        [Fact]
        public void GetUserPropertiesWorkAgain()
        {
            //Arrange
            UserM user = new UserM();
            user.ID = 1;
            user.Name = "jason";

            //Assert
            Assert.Equal("jason", user.Name);

        }

        [Fact]
        public void SetUserPropertiesWorks()
        {
            //Arrange
            UserM user = new UserM();
            user.ID = 1;
            user.Name = "jason";

            //Act
            user.ID = 2;
            //Assert
            Assert.Equal(2, user.ID);

        }

        [Fact]
        public void SetUserPropertiesWorksAgain()
        {
            //Arrange
            UserM user = new UserM();
            user.ID = 1;
            user.Name = "jason";

            //Act
            user.Name = "Jennifer";
            //Assert
            Assert.Equal("Jennifer", user.Name);

        }

        [Fact]
        public async void CreateUserWorks()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("CreateUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 1;
                user.Name = "jason";

                // Act
                UserService service = new UserService(context);

                await service.CreateUser(user);
                var created = context.User.FirstOrDefault(u => u.ID == user.ID);

                // Assert
                Assert.Equal(user, created);

            }
        }

        [Fact]
        public async void CreateUserWorksAgain()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("CreateUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 2;
                user.Name = "Jennifer";

                // Act
                UserService service = new UserService(context);

                await service.CreateUser(user);
                var created = context.User.FirstOrDefault(u => u.ID == user.ID);

                // Assert
                Assert.Equal(user, created);

            }
        }

        [Fact]
        public async void DeleteUserWorks()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("DeleteUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 1;
                user.Name = "jason";

                UserService service = new UserService(context);

                await service.CreateUser(user);

                // Act

                await service.DeleteUser(1);
                var deleted = context.User.FirstOrDefault(u => u.ID == user.ID);
                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteUserWorksAgain()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("DeleteUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 2;
                user.Name = "Jennifer";

                UserService service = new UserService(context);

                await service.CreateUser(user);

                // Act

                await service.DeleteUser(2);
                var deleted = context.User.FirstOrDefault(u => u.ID == user.ID);
                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void UpdateUserWorks()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("UpdateUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 1;
                user.Name = "Jennifer";

                UserService service = new UserService(context);

                await service.CreateUser(user);

                // Act

                user.Name = "Jason";
                await service.Updateuser(user);
                // Assert
                Assert.Equal("Jason", user.Name);

            }
        }

        /// <summary>
        /// Cant test ID, because it is used a FK in ColorSchemeM
        /// </summary>
        [Fact]
        public async void UpdateUserWorksAgain()
        {
            DbContextOptions<ColorSchemeDbContext> options =
                new DbContextOptionsBuilder<ColorSchemeDbContext>
                ().UseInMemoryDatabase("UpdateUser").Options;

            using (ColorSchemeDbContext context = new ColorSchemeDbContext(options))
            {
                // arrange
                UserM user = new UserM();
                user.ID = 3;
                user.Name = "Jason";

                UserService service = new UserService(context);

                await service.CreateUser(user);

                // Act

                user.Name = "Tom";
                await service.Updateuser(user);
                // Assert
                Assert.Equal("Tom", user.Name);

            }
        }


    }
}
