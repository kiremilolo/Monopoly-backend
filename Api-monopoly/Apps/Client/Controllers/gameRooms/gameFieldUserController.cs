using Api_monopoly.Apps.Client.Dtos.GameFieldUserDto;
using Api_monopoly.Apps.Client.Dtos.GameFieldUserDtos;
using Api_monopoly.Apps.Client.Dtos.GameLogDtos;
using AutoMapper;
using Core.Entities.gameRoom;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers.gameRooms
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class gaemFieldUserController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public gaemFieldUserController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.gameFeeldUsers.ToList();

            List<GameFieldUserGetAllDto> items = _mapper.Map<List<GameFieldUserGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.gameFeeldUsers.FirstOrDefaultAsync(x => x.gameFeeldUserId == id);
            if (data == null) return BadRequest();
            gameFeeldUser dto = _mapper.Map<gameFeeldUser>(data);


            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(GameFieldUserPostDto gameFieldUserPostDto)
        {
            gameFeeldUser data = _mapper.Map<gameFeeldUser>(gameFieldUserPostDto);


            _context.gameFeeldUsers.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GameFieldUserUpdateDto gameFieldUserDto)
        {
            var exsistData = _context.gameFeeldUsers.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.fieldName = gameFieldUserDto.FieldName;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.gameFeeldUsers.Find(id);
            if (data == null) return BadRequest();
            _context.gameFeeldUsers.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
