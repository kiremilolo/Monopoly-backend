using Api_monopoly.Apps.Client.Dtos.gameRoomDtos;
using Api_monopoly.Apps.Client.Dtos.GameRoomUserDtos;
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
    public class gameRoomUserController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public gameRoomUserController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.gameRoomUsers.ToList();

            List<GameRoomUserGetAllDto> items = _mapper.Map<List<GameRoomUserGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.gameRoomUsers.FirstOrDefaultAsync(x => x.gameRoomUserId == id);
            if (data == null) return BadRequest();
            GameRoomUserGetDto dto = _mapper.Map<GameRoomUserGetDto>(data);
            return Ok(dto);
        }


        [HttpPost()]
        public async Task<IActionResult> Create(GameRoomUserPostDto gameRoomUserPostDto)
        {
            gameRoomUser data = _mapper.Map<gameRoomUser>(gameRoomUserPostDto);


            _context.gameRoomUsers.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GameRoomUserUpdateDto gameRoomUserUpdateDto)
        {
            var exsistData = _context.gameRoomUsers.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.userId = gameRoomUserUpdateDto.userId;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.gameRoomUsers.Find(id);
            if (data == null) return BadRequest();
            _context.gameRoomUsers.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
