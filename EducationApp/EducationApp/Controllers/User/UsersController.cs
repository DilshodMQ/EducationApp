using EducationApp.Controllers.Teacher.Models;
using EducationApp.Service.User;
using EducationApp.Service.User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService= userService;
        }
        [HttpGet("TeachersOrStudentsWhoUseBeeline")]
        public async Task<IEnumerable<UserModel>> GetUsersWhoUseBeeline()
        {
            var users= await _userService.GetUsersWhoUseBeeline();
            return users;
        }
    }
}
