using SnP_Exercise_1.Api;

namespace SnP_Exercise_1.Services
{
    public enum Occupation
    {
        CEO,
        Scientist,
        MusicComposer,
    }

    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Occupation Occupation { get; set; }
        public bool Active { get; set; }
        public int? Age { get; set; }
    }
    public class UsersCollection
    {
        public User?[] Users { get; set; }
    }
    public class UserService
    {
        private static readonly UsersCollection Users = new UsersCollection
        {
            Users = new User[]
            {
                new User { FirstName = "Bill", LastName="Gates", Occupation = Occupation.CEO, Active = true },
                new User { FirstName = "Issac Newton", LastName="Newton", Occupation = Occupation.Scientist, Active = false },
                new User { FirstName = "Kyd", LastName="Kyd", Occupation = Occupation.MusicComposer, Active = true }
            }

        };
        public UsersCollection GetUsers()
        {
            return Users;
        }
    }
}
