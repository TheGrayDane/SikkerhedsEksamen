using BrokenAccess.Data;
using BrokenAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokenAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            var users = Storage.UserList();
            var userFound = users.FirstOrDefault(u => u.Id == id);
            return Ok(userFound);
        }


        [HttpPut]
        public IActionResult UpdateProfile(UserModel user)
        {
            var users = Storage.UserList();
            var userFound = users.FirstOrDefault(u => u.Id == user.Id);

            if (userFound == null)
                return NotFound("Error in updating user");

            userFound.UserName = user.UserName;
            userFound.PassWord = user.PassWord;
            return Ok("User updated");
        }

    }
}
