using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
       
        // GET: api/<LessonController>
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return lessons;
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id)!;
            if(lesson != null)
                return Ok(lesson);
            return NotFound();
        }

        // POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] Lesson value)
        {
            value.Id = lessons.Count + 1;
            lessons.Add(value);
        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lesson value)
        {
            var index = lessons.FindIndex(l => l.Id == id);
            if (index >= 0)
            {
                lessons[index].Title = value.Title;
                lessons[index].TeacherId = value.TeacherId;
                lessons[index].Date = value.Date;
                lessons[index].Duration = value.Duration;
                lessons[index].Description = value.Description;
            }
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var lesson = lessons.FirstOrDefault(l => l.Id == id);
            if (lesson != null)
                lessons.Remove(lesson);
        }
    }
}
