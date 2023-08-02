using Microsoft.AspNetCore.Mvc;

namespace SnP_Exercise_1.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly User[] Users = { 
            new User { Name="Bill Gates", Occupation="CEO", Active = true }, 
            new User { Name = "Issac Newton", Occupation = "Scientist", Active = false},
            new User { Name = "Jasper Kyd", Occupation = "Music composer", Active = true}
        };
        
        [HttpGet(Name="GetUsers")]
        public User[] Get()
        {
            return Users;
        }
    }
}
