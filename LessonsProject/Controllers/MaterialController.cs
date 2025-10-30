using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/lessons/{lessonId}/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        public IDataContext _context { get; set; }
        public MaterialController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<MaterialController>
        [HttpGet]
        public IEnumerable<Material> Get(int lessonId) => _context.materials.Where(m => m.LessonId == lessonId);

        // GET api/<MaterialController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MaterialController>
        [HttpPost]
        public ActionResult Post(int lessonId, [FromBody] Material value)
        {
            var m = _context.materials.FirstOrDefault(x => x.Id==value.Id);
            if (m != null)
                return Conflict();
            _context.materials.Add(value);
            return Ok();
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int lessonId, int id, [FromBody] Material value)
        {
            var index = _context.materials.FindIndex(m => m.Id == id && m.LessonId == lessonId);
            if (index >= 0)
            {
                _context.materials[index].Title = value.Title;
                _context.materials[index].Type = value.Type;
                _context.materials[index].Url = value.Url;
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int lessonId, int id)
        {
            var material = _context.materials.FirstOrDefault(m => m.Id == id && m.LessonId == lessonId);
            if (material != null)
            {
                _context.materials.Remove(material);
                return Ok();
            }
            return BadRequest();
        }
    }
}
