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
        public IActionResult Login([FromBody] LoginModel login)
        {
                if (login.UseExtModel)
                {
                    
                    var users = Storage.UserExtList();
                    var userFound = users.FirstOrDefault(u => u.UserName == login.UserName && u.PassWord == login.PassWord);
                    
                    if (userFound == null)
                        return NotFound("No user found with Email or Access Code");
                    
                    var guid = Guid.NewGuid();
                    Storage.ExtloggedInUsers().Add(guid, userFound.Id);
                    var extResponse = new UserExtResponseModel()
                    {
                        Id = guid,
                        IsAdmin = userFound.IsAdmin,
                        UserName = userFound.UserName,
                        MayUpdate = userFound.MayUpdate,
                        MayDelete = userFound.MayDelete
                    };
                    return Ok(extResponse);
                }
                else
                {
                    var users = Storage.UserList();
                    var userFound = users.FirstOrDefault(u => u.UserName == login.UserName && u.PassWord == login.PassWord);
                    if (userFound == null)
                        return NotFound("No user found with Email or Access Code");
                    
                    Storage.LoggedIn().Add(userFound);
                    var response = new UserResponseModel()
                    {
                        Id = userFound.Id,
                        UserName = userFound.UserName
                    };
                    return Ok(response);
                }
        }
    }
}
