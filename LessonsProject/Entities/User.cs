﻿namespace LessonsProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // teacher / student / admin
        public string Email { get; set; } = string.Empty;
    }
}
