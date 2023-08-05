using Api_monopoly.Apps.Client.Dtos.Product;
using Api_monopoly.Apps.Client.Dtos.Slider;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers.Slider
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class Slider : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public Slider(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.sliders.ToList();

            List<SliderGetAllDto> items = _mapper.Map<List<SliderGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.sliders.FirstOrDefaultAsync(x => x.SliderId == id);
            if (data == null) return BadRequest();
            SliderGetDto dto = _mapper.Map<SliderGetDto>(data);


            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(SliderPostDto sliderPostDto)
        {
            Core.Entities.Slider.Slider data = _mapper.Map<Core.Entities.Slider.Slider>(sliderPostDto);


            _context.sliders.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SliderUpdateDto sliderUpdateDto)
        {
            var exsistData = _context.sliders.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.posterStatus = sliderUpdateDto.posterStatus;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.sliders.Find(id);
            if (data == null) return BadRequest();
            _context.sliders.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
