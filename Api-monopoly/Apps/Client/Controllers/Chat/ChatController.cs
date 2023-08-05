using Api_monopoly.Apps.Client.Dtos.Chat;
using Api_monopoly.Apps.Client.Dtos.ChatDtos;
using AutoMapper;
using Core.Entities.Chat;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers.Chat
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public ChatController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.chat.ToList();

            List<ChatGetAllDto> items = _mapper.Map<List<ChatGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.chat.FirstOrDefaultAsync(x => x.ChatId == id);
            if (data == null) return BadRequest();
            ChatGetDto dto = _mapper.Map<ChatGetDto>(data);
            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(ChatDto chatDto)
        {
            Core.Entities.Chat.Chat data = _mapper.Map<Core.Entities.Chat.Chat>(chatDto);


            _context.chat.Add(data);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ChatDto chatDto)
        {
            var exsistData = _context.chat.Find(id);
            if (exsistData == null) return BadRequest();
            exsistData.chatText = chatDto.ChatText;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.chat.Find(id);


            if (data == null) return BadRequest();
            _context.chat.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
