

namespace SchoolDigital
{
    public class DataContext
    {
        public List<Lesson> lessons { get; set; }
        public List<User> users { get; set; }
        public List<Attendance> attendanceList { get; set; }
        public List<Material> materialsList { get; set; }
        public DataContext()
        {
            lessons = new List<Lesson> { new Lesson { Id = 1, Title = "תנ\"ך – פרשת השבוע", TeacherId = 1, Date = DateTime.Parse("2025-10-25"), Duration = 90, Description = "לימוד פרשת השבוע" } };
            users = new List<User>
            {
            new User { Id = 1, Name = "ישראל כהן", Role = "teacher", Email = "israel@example.com" },
            new User { Id = 2, Name = "שרה לוי", Role = "student", Email = "sara@example.com" }
            };
            attendanceList = new List<Attendance>();
            materialsList = new List<Material>();
        }

    }
}


