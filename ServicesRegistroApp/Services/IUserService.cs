using ServicesRegistroApp.Model;
using System.Collections.Generic;

namespace ServicesRegistroApp
{
    public interface IUserService
    {
        IList<User> GetUsers();
        bool CreateUser(User user);
        bool UpdateUser(User user);
        IList<Area> GetAreas();
        User GetUserById(int idUser);
    }
}
