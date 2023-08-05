using Api_monopoly.Apps.Client.Dtos.Chat;
using Api_monopoly.Apps.Client.Dtos.ChatDtos;
using Api_monopoly.Apps.Client.Dtos.gameRoomDtos;
using AutoMapper;
using Core.Entities.gameRoom;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class gameRoomController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public gameRoomController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.gameRooms.ToList();

            List<GameRoomGetAllDto> items = _mapper.Map<List<GameRoomGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.gameRooms.FirstOrDefaultAsync(x => x.gameRoomId == id);
            if (data == null) return BadRequest();
            GameRoomGetDto dto = _mapper.Map<GameRoomGetDto>(data);


            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(GameRoomPostDto gameRoomPostDto)
        {
            gameRoom data = _mapper.Map<gameRoom>(gameRoomPostDto);


            _context.gameRooms.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GameRoomUpdateDto gameRoomUpdateDto)
        {
            var exsistData = _context.gameRooms.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.updateDate = gameRoomUpdateDto.UpdateDate;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.gameRooms.Find(id);
            if (data == null) return BadRequest();
            _context.gameRooms.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
