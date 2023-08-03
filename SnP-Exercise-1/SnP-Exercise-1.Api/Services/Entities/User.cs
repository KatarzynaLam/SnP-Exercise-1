using System.ComponentModel;

namespace SnP_Exercise_1.Services
{
    public enum Occupation
    {
        CEO,
        Scientist,
        [Description("Music Composer")]
        MusicComposer,
    }
    public class UsersCollection
    {
        public List<User> Users { get; set; }
    }
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Occupation Occupation { get; set; }
        public bool Active { get; set; }
        public int? Age { get; set; }
    }
}
