using Microsoft.AspNetCore.Mvc;
using SnP_Exercise_1.Services;
using System;

namespace SnP_Exercise_1.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UsersController : ControllerBase
    {
        private UserService? _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [Route("")]
        [HttpGet]
        public UsersCollection GetUsers()
        {
            return MapToUsersDTO(_userService.GetAllUsers());
        }

        [Route("active")]
        [HttpGet]
        public UsersCollection GetActive()
        {
            return MapToUsersDTO(_userService.GetActiveUsers());
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
            UsersCollection usersCollection = new UsersCollection { Users = new List<User>() };
            foreach(SnP_Exercise_1.Services.User u in users.Users)
            {
                usersCollection.Users.Add(MapToUserDTO(u));
            }
            return usersCollection;

        }
    }

}
