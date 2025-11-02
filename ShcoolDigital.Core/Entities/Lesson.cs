namespace SchoolDigital.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; } // בדקות
        public string Description { get; set; } = string.Empty;
    }
}
