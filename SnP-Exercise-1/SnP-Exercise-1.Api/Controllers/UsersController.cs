using Microsoft.AspNetCore.Mvc;
using SnP_Exercise_1.Services;
using System;

namespace SnP_Exercise_1.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService? _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet(Name = "GetUsers")]
        public UsersCollection Get()
        {
            return MapToUsersDTO(_userService.GetAllUsers());
        }
        private User MapToUserDTO(SnP_Exercise_1.Services.User user)
        {
            return new User
            {
                Name = user.FirstName + ' ' + user.LastName,
                Occupation = user.Occupation.ToString(),
                Active = user.Active
            };
        }

        private UsersCollection MapToUsersDTO(SnP_Exercise_1.Services.UsersCollection users)
        {

            return new UsersCollection
            {
                Users = new User[]{ 
                    MapToUserDTO(users.Users[0]),
                    MapToUserDTO(users.Users[1]),
                    MapToUserDTO(users.Users[2]),
                }
            };
               
        
        }




}

}
