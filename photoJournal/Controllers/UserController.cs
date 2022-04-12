using Microsoft.AspNetCore.Mvc;
using System;
using photoJournal.Models;
using photoJournal.Repositories;

namespace photoJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);

            if (email == null || user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var user = _userRepository.GetUserById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}


        //[HttpPost]
        //public IActionResult Post(UserProfile userProfile)
        //{
        //    var user = _userRepository.GetByEmail(userProfile.Email);

        //    if (userProfile.Email != user.Email)
        //    {

        //        userProfile.CreateDateTime = DateTime.Now;
        //        userProfile.UserTypeId = UserType.AUTHOR_ID;
        //        _userRepository.Add(userProfile);
        //        return CreatedAtAction(
        //            "GetByEmail",
        //            new { email = userProfile.Email },
        //            userProfile);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}
    }
}
