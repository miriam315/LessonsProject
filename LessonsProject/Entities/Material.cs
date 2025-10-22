namespace LessonsProject.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // pdf / video / link
        public string Url { get; set; } = string.Empty;
    }
}
