using Core.Entities;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.ManageApi.Controllers
{
    [ApiExplorerSettings(GroupName = "admin_v1")]
    [Route("admin/api/[controller]")]
    [ApiController]

    public class MarketController : ControllerBase
    {
        private readonly MonopolyDbContext _context;


        public MarketController(MonopolyDbContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data =await _context.Products.ToListAsync();
            return Ok(data);
        }

        [HttpGet("GetClass")]
        public async Task<IActionResult> GetClass(string Class)
        {
            var data = await _context.Products.Include(x => x.classes).Where(x=>x.classes.Class == Class).ToListAsync();

            if(data.Count==0) return NotFound();       

            return Ok(data);
           
        }

        [HttpGet("GetCollection")]
        public async Task<IActionResult> GetCollection(string Name)
        {
            var data = await _context.Products.Include(x => x.Collection).Where(x => x.Collection.Name == Name).ToListAsync();

            if (data==null) return NotFound();

            return Ok(data);

        }
    }
}
