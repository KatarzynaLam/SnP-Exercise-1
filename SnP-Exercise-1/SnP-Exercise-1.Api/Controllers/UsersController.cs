using Microsoft.AspNetCore.Mvc;

namespace SnP_Exercise_1.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly UsersCollection Users = new UsersCollection
        {
            Users = new User[] 
            { 
                new User { Name = "Bill Gates", Occupation = "CEO", Active = true },
                new User { Name = "Issac Newton", Occupation = "Scientist", Active = false },
                new User { Name = "Jasper Kyd", Occupation = "Music composer", Active = true } 
            }

        };
        
        [HttpGet(Name="GetUsers")]
        public UsersCollection Get()
        {
            return Users;
        }
    }
}
