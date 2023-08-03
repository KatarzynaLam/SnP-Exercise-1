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

        [Route("name/{name}")]
        [HttpGet]
        public UsersCollection GetUsersByName(string name)
        {
            return MapToUsersDTO(_userService.GetUsersByName(name));
        }

        [Route("occupation/{occupation}")]
        [HttpGet]
        public UsersCollection GetUsersByOccupation(string occupation)
        {
            return MapToUsersDTO(_userService.GetUsersByOccupation(occupation));
        }

        [Route("lastname/{lastname}")]
        [HttpGet]
        public UsersCollection GetUsersByLastName(string lastname)
        {
            return MapToUsersDTO(_userService.GetUsersByLastName(lastname));
        }

        [Route("firstname/{firstname}")]
        [HttpGet]
        public UsersCollection GetUsersByFirstName(string firstname)
        {
            return MapToUsersDTO(_userService.GetUsersByFirstName(firstname));
        }


        [Route("age/{age}")]
        [HttpGet]
        public UsersCollection GetUsersByAge(int age)
        {
            return MapToUsersDTO(_userService.GetUsersByAge(age));
        }


        private User MapToUserDTO(SnP_Exercise_1.Services.User user)
        {
            return new User
            {
                Name = user.FirstName + ' ' + user.LastName,
                Occupation = user.Occupation.GetDisplayName(),
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
