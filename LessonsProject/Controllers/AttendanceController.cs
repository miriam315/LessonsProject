using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public static List<Attendance> attendanceList = new List<Attendance>();
        // GET: api/<AttendanceController>
        [HttpGet]
        public IEnumerable<Attendance> Get(int lessonId) => attendanceList.Where(a => a.LessonId == lessonId);


        // GET api/<AttendanceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AttendanceController>
        [HttpPost]
        public void Post(int lessonId, [FromBody] Attendance value)
        {
            value.Id = attendanceList.Count + 1;
            value.LessonId = lessonId;
            attendanceList.Add(value);
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int lessonId, int id, [FromBody] Attendance value)
        {
            var index = attendanceList.FindIndex(a => a.Id == id && a.LessonId == lessonId);
            if (index >= 0)
            {
                attendanceList[index].StudentId = value.StudentId;
                attendanceList[index].Status = value.Status;
            }
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int lessonId, int id)
        {
            var record = attendanceList.FirstOrDefault(a => a.Id == id && a.LessonId == lessonId);
            if (record != null) attendanceList.Remove(record);
        }
    }
}
