using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorScheme.Models.Interfaces
{
    public interface IUserManager
    {
        //Creates new instance of User
        Task CreateUser(User user);

        //displays all Userss
        Task<IEnumerable<User>> GetUsers();

        //Displays details of User
        Task<User> GetOneuser(int id);

        //displays update view
        Task<User> UpdateOne(int id);

        //allows user to update properties
        Task Updateuser(User user);

        //displays delete view
        Task<User> DeleteOne(int id);

        //deletes User and all children
        Task DeleteUser(int ID);

        //checks if instance exists
        bool UserExist(int id);

    }
}
