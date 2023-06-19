using EducationApp.Data;
using EducationApp.Service.User;
using EducationApp.Service.User.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EducationApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly EducationAppContext _context;
        private readonly IUserService _userService;
        public AccountsController(EducationAppContext context, IUserService userService)
        {
            _context= context;
            _userService= userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user=_context.Users.Include(u=>u.Role).FirstOrDefault(u=>u.Email.Equals(username)&&u.Password.Equals(password));
            if (user is null)
                return StatusCode(StatusCodes.Status400BadRequest);

            var claims = new List<Claim>
             {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
             };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            return StatusCode(StatusCodes.Status200OK);


        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
