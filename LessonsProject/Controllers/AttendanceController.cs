using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public IDataContext _context { get; set; }
        public AttendanceController(IDataContext context)
        {
            _context = context;
        }

        // GET: api/<AttendanceController>
        [HttpGet]
        public IEnumerable<Attendance> Get(int lessonId) => _context.attendances.Where(a => a.LessonId == lessonId);


        // GET api/<AttendanceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AttendanceController>
        [HttpPost]
        public ActionResult Post(int lessonId, [FromBody] Attendance value)
        {
            var attendance = _context.attendances.Find(a => a.Id == value.Id && a.LessonId == lessonId);
            if (attendance != null)
                return Ok(attendance);
            return NotFound();
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int lessonId, int id, [FromBody] Attendance value)
        {
            var index = _context.attendances.FindIndex(a => a.Id == id && a.LessonId == lessonId);
            if (index >= 0)
            {
                _context.attendances[index].StudentId = value.StudentId;
                _context.attendances[index].Status = value.Status;
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int lessonId, int id)
        {
            var record = _context.attendances.FirstOrDefault(a => a.Id == id && a.LessonId == lessonId);
            if (record != null)
            {
                _context.attendances.Remove(record);
                return Ok();
            }
            return BadRequest();
        }
    }
}
