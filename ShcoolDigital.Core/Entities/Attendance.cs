namespace SchoolDigital.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = string.Empty; // present / absent
    }
}
