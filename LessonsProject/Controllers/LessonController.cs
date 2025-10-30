using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        public IDataContext _context { get; set; }
        public LessonController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<LessonController>
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return _context.lessons;
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var lesson = _context.lessons.FirstOrDefault(l => l.Id == id)!;
            if(lesson != null)
                return Ok(lesson);
            return NotFound();
        }

        // POST api/<LessonController>
        [HttpPost]
        public ActionResult Post([FromBody] Lesson value)
        {
            var l =_context.lessons.FirstOrDefault(x=>x.Id == value.Id);
            if(l != null)
                return Conflict();
            _context.lessons.Add(value);
            return Ok();
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson value)
        {
            var index = _context.lessons.FindIndex(l => l.Id == id);
            if (index >= 0)
            {
                _context.lessons[index].Title = value.Title;
                _context.lessons[index].TeacherId = value.TeacherId;
                _context.lessons[index].Date = value.Date;
                _context.lessons[index].Duration = value.Duration;
                _context.lessons[index].Description = value.Description;
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lesson = _context.lessons.FirstOrDefault(l => l.Id == id);
            if (lesson != null)
            {
                _context.lessons.Remove(lesson);
                return Ok();
            }
            return BadRequest();
        }
    }
}
