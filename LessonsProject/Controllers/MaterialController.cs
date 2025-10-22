using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public static List<Material> materialsList = new List<Material>();
        // GET: api/<MaterialController>
        [HttpGet]
        public IEnumerable<Material> Get(int lessonId) => materialsList.Where(m => m.LessonId == lessonId);

        // GET api/<MaterialController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MaterialController>
        [HttpPost]
        public void Post(int lessonId, [FromBody] Material value)
        {
            value.Id = materialsList.Count + 1;
            value.LessonId = lessonId;
            materialsList.Add(value);
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public void Put(int lessonId, int id, [FromBody] Material value)
        {
            var index = materialsList.FindIndex(m => m.Id == id && m.LessonId == lessonId);
            if (index >= 0)
            {
                materialsList[index].Title = value.Title;
                materialsList[index].Type = value.Type;
                materialsList[index].Url = value.Url;
            }
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public void Delete(int lessonId, int id)
        {
            var material = materialsList.FirstOrDefault(m => m.Id == id && m.LessonId == lessonId);
            if (material != null) materialsList.Remove(material);
        }
    }
}
