
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.OpenApi.Extensions;
using SnP_Exercise_1.Api;

namespace SnP_Exercise_1.Services
{

    public class UserService
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

        public UsersCollection GetUsersByFirstName(string name)
        {
            return new UsersCollection{
                Users = Users.Users.Where(user => user.FirstName == name).ToList()
        };
        }

        public UsersCollection GetUsersByLastName(string name)
        {
            return new UsersCollection {
                Users = Users.Users.Where(user => user.LastName == name).ToList()
            };
        }

        public UsersCollection GetUsersByName(string name)
        {
            return new UsersCollection {
                Users = Users.Users.Where(user => (user.FirstName + ' ' + user.LastName) == name).ToList()
        };
        }

        public UsersCollection GetUsersByOccupation(string occupation)
        {
            return new UsersCollection {
                Users = Users.Users.Where(user => (user.Occupation.GetDisplayName() == occupation)).ToList()
            };
        }

        public UsersCollection GetUsersByAge(int age)
        {
            return new UsersCollection{
                Users = Users.Users.Where(user => (user.Age == age)).ToList()
            };
        }
        public UsersCollection GetActiveUsers()
        {
            UsersCollection ActiveUsers = new UsersCollection {Users = new List<User>() };
            foreach(User u in Users.Users)
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
