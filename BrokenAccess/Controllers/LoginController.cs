using BrokenAccess.Data;
using BrokenAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokenAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetUser()
        {
            var userlist = new List<UserModel>();

            userlist.AddRange(Storage.UserList());

            userlist.AddRange(Storage.LoggedIn());
            return Ok(userlist);
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserModel user)
        {
            var users = Storage.UserList();
            var userFound = users.FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
            if (userFound != null)
            {
                Storage.LoggedIn().Add(userFound);
                var response = new UserResponseModel();
                response.Id = userFound.Id;
                response.UserName = userFound.UserName;
                return Ok(response);
            }

                return NotFound("No user found with Email or Access Code");
        }
    }
}
