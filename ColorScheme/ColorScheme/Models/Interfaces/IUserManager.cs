using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorScheme.Models.Interfaces
{
    public interface IUserManager
    {
        //Creates new instance of User
        Task CreateUser(UserM user);

        //displays all Userss
        Task<IEnumerable<UserM>> GetUsers();

        //Displays details of User
        Task<IEnumerable<ColorSchemeM>> GetOneuser(int id);

        //displays update view
        Task<UserM> UpdateOne(int id);

        //allows user to update properties
        Task Updateuser(UserM user);

        //displays delete view
        Task<UserM> DeleteOne(int id);

        //deletes User and all children
        Task DeleteUser(int ID);

        //checks if instance exists
        bool UserExist(int id);

        //deletes one saved color scheme
        Task DeleteScheme(int id);
    }
}
