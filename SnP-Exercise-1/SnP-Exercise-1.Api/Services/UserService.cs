
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
            UsersCollection UsersByName = new UsersCollection { };
            UsersByName.Users = Users.Users.Where(user => user.FirstName == name).ToList();
            return UsersByName;
        }

        public UsersCollection GetUsersByLastName(string name)
        {
            UsersCollection UsersByName = new UsersCollection { };
            UsersByName.Users = Users.Users.Where(user => user.LastName == name).ToList();
            return UsersByName;
        }

        public UsersCollection GetUsersByName(string name)
        {
            UsersCollection UsersByName = new UsersCollection { };
            UsersByName.Users = Users.Users.Where(user => (user.FirstName + ' ' + user.LastName) == name).ToList();
            return UsersByName;
        }

        public UsersCollection GetUsersByOccupation(string occupation)
        {
            UsersCollection OccupationUsers = new UsersCollection { Users = new List<User>() };
            OccupationUsers.Users = Users.Users.Where(user => (user.Occupation.GetDisplayName() == occupation)).ToList();
            return OccupationUsers;
        }
        public UsersCollection GetUsersByAge(int age)
        {
            UsersCollection UsersByAge = new UsersCollection { Users = new List<User>() };
            UsersByAge.Users = Users.Users.Where(user => (user.Age == age)).ToList();
            return UsersByAge;
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
