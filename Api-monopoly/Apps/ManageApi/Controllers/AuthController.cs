using Api_monopoly.Apps.ManageApi.Dtos;
using Api_monopoly.Services;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api_monopoly.Apps.ManageApi.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Jwtservice _jwtservice;

        public AuthController(UserManager<AppUser> userManager, Jwtservice jwtservice)
        {
            _userManager = userManager;
            _jwtservice = jwtservice;
        }



        [HttpGet("createadmin")]

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser
            {
                UserName = "Huseyn",
                IsAdmin = true
            };



            await _userManager.CreateAsync(appUser, "Huseyn12345_");
            await _userManager.AddToRoleAsync(appUser, "superAdmin");


            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(AdminLoginDto dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.UserName);

                if(user == null || !user.IsAdmin)
                return NotFound();

            var token = _jwtservice.Generate(user, await _userManager.GetRolesAsync(user));


            return Ok(new {token= token});
        }
    }
}
