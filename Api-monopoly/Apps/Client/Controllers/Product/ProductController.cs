using Api_monopoly.Apps.Client.Dtos.GameLogDtos;
using Api_monopoly.Apps.Client.Dtos.Product;
using AutoMapper;
using Core.Entities.gameRoom;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers.Product
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.Products.ToList();

            List<ProductGetAllDto> items = _mapper.Map<List<ProductGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (data == null) return BadRequest();
            ProductGetDto dto = _mapper.Map<ProductGetDto>(data);


            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(ProductPostDto productPostDto)
        {
            Core.Entities.Product.Product data = _mapper.Map<Core.Entities.Product.Product>(productPostDto);


            _context.Products.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto ProductUpdateDto)
        {
            var exsistData = _context.Products.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.Name = ProductUpdateDto.Name;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.Products.Find(id);
            if (data == null) return BadRequest();
            _context.Products.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
