
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace SnP_Exercise_1.Services
{

    public class UserService : IUserService
    {
        private static readonly UsersCollection Users = new UsersCollection
        {
            Users = new List<User>
            {
                new User { FirstName = "Bill", LastName="Gates", Occupation = Occupation.CEO, Active = true, Age = 100 },
                new User { FirstName = "Issac", LastName="Newton", Occupation = Occupation.Scientist, Active = false, Age = 10 },
                new User { FirstName = "Jasper", LastName="Kyd", Occupation = Occupation.MusicComposer, Active = true, Age = 10 }
            }
        };

        public UsersCollection GetFilteredUsers(string? firstname, string? lastname, string? occupation, int? age, bool? active)
        {
            return new UsersCollection
            {
                Users = Users.Users.Where(user =>
                (user.FirstName == firstname || firstname == null)
                && (user.LastName == lastname || lastname == null)
                && (user.Age == age || age == null)
                && (user.Active == active || active == null)
                && (user.Occupation.GetDisplayName() == occupation || occupation == null)
                ).ToList()
            };
        }

        public UsersCollection GetActiveUsers()
        {
            UsersCollection ActiveUsers = new UsersCollection { Users = new List<User>() };
            foreach (User u in Users.Users)
            {
                if (u.Active == true)
                {
                    User activeUser = u;
                    ActiveUsers.Users.Add(activeUser);
                }
            }
            return ActiveUsers;
        }
        public UsersCollection GetAllUsers()
        {
            return Users;
        }
    }
}