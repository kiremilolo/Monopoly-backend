using Api_monopoly.Apps.Client.Dtos.UserDtos;
using Api_monopoly.Services;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
namespace Api_monopoly.Apps.Client.Controllers
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Jwtservice _jwtservice;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, Jwtservice jwtservice)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtservice = jwtservice;
        }

        public readonly RoleManager<IdentityRole> RoleManager;


        [HttpGet("")]
        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("Member"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));


            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {

            if (_userManager.Users.Any(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("Email", "Email has already taken");
                return BadRequest(ModelState);
            }

            if (_userManager.Users.Any(x => x.UserName == registerDto.Username))
            {
                ModelState.AddModelError("Username", "Username has already taken");
                return BadRequest(ModelState);
            }


            AppUser user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                IsAdmin = false

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);


            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Password is not correct format");
                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(user, "Member");

            return Ok();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return BadRequest();


            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return BadRequest();


            var tokenStr = _jwtservice.Generate(user, _userManager.GetRolesAsync(user).Result);

            return Ok(new { token = tokenStr });
        }



        [HttpPut("UpdateUserName")]
        public async Task<IActionResult> UpdateUserName( UserUpdateDto userUpdateDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(userUpdateDto.Email);

            if(user == null) return BadRequest();    
                            
            user.UserName= userUpdateDto.Username;
            return Ok();
        }

        [HttpPut("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(UpdateEmailDto userUpdateDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(userUpdateDto.Email);

            if (user == null) return BadRequest();

            user.Email = userUpdateDto.Email;
            return Ok();
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            return Ok(user);
        }
    }
}
