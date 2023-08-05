using Api_monopoly.Apps.Client.Dtos.Slider;
using Api_monopoly.Apps.Client.Dtos.Task;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_monopoly.Apps.Client.Controllers.Task
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly MonopolyDbContext _context;
        private readonly IMapper _mapper;

        public TaskController(MonopolyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var data = _context.tasks.ToList();

            List<TaskGetAllDto> items = _mapper.Map<List<TaskGetAllDto>>(data);


            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.tasks.FirstOrDefaultAsync(x => x.TaskId == id);
            if (data == null) return BadRequest();
            TaskGetDto dto = _mapper.Map<TaskGetDto>(data);


            return Ok(dto);
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(TaskPostDto taskPostDto)
        {
            Core.Entities.Task.Task data = _mapper.Map<Core.Entities.Task.Task>(taskPostDto);
            _context.tasks.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskUpdateDto taskUpdateDto)
        {
            var exsistData = _context.tasks.Find(id);
            if (exsistData == null) return BadRequest();
            taskUpdateDto.Name = taskUpdateDto.Name;

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.tasks.Find(id);
            if (data == null) return BadRequest();
            _context.tasks.Remove(data);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
