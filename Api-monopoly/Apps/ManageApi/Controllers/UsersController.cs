using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_monopoly.Apps.ManageApi.Controllers
{
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [Route("/admin/api/[controller]")]
        [ApiController]

    public class UsersController : ControllerBase
    {

            private readonly MonopolyDbContext _context;
            private readonly IMapper _mapper;

            public UsersController(MonopolyDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }



            [HttpGet("")]
            public async Task<IActionResult> GetAll()
            {
                var data = _context.AppUsers.ToList();



                return Ok(data);
            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(string name)
            {
                var data = _context.AppUsers.FirstOrDefault(x=>x.UserName== name);
                if (data == null) return BadRequest();
                _context.AppUsers.Remove(data);

                _context.SaveChanges();

                return NoContent();
            }
        


    }
}
