using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnP_Exercise_1.Services
{
    public interface IUserService
    {
        UsersCollection GetActiveUsers();
        UsersCollection GetFilteredUsers(string? firstname, string? lastname, string? occupation, int? age, bool? active);
        UsersCollection GetAllUsers();
    }
}
