using Api_monopoly.Apps.Client.Dtos.GameLogDtos;
using Api_monopoly.Apps.Client.Dtos.gameRoomDtos;
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
    public class gameLogController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public gameLogController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.gameLogs.ToList();

            List<GameLogGetAllDto> items = _mapper.Map<List<GameLogGetAllDto>>(data);


            return Ok(items);
        }

     

        [HttpPost()]
        public async Task<IActionResult> Create(GameLogPostDto gameRoomPostDto)
        {
            gameLog data = _mapper.Map<gameLog>(gameRoomPostDto);


          await  _context.gameLogs.AddAsync(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GameLogUpdateDto gameLogUpdateDto)
        {
            var exsistData = _context.gameLogs.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.wallet = gameLogUpdateDto.wallet;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.gameLogs.Find(id);
            if (data == null) return BadRequest();
            _context.gameLogs.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
