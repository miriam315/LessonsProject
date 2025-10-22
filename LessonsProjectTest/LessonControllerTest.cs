using LessonsProject.Controllers;
using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsProjectTest
{
    public class LessonControllerTest
    {
        [Fact]
        public void Get_ShouldReturnAllLessons()
        {
            var controller = new LessonController();

            var result = controller.Get();

            Assert.NotEmpty(result);
            Assert.Contains(result, l => !string.IsNullOrEmpty(l.Title));
        }

        [Fact]
        public void Get_WithId_ShouldReturnLesson()
        {
            var controller = new LessonController();

            var result = controller.Get(1) as OkObjectResult;
            Assert.NotNull(result);

            var lesson = result.Value as Lesson;
            Assert.Equal(1, lesson.Id);
        }

        [Fact]
        public void Get_WithInvalidId_ShouldReturnNotFound()
        {
            var controller = new LessonController();

            var result = controller.Get(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ShouldAddLesson()
        {
            var controller = new LessonController();
            int countBefore = controller.Get().Count();

            var newLesson = new Lesson { Title = "חינוך", TeacherId = 1, Date = DateTime.Now, Duration = 60 };
            controller.Post(newLesson);

            int countAfter = controller.Get().Count();
            Assert.Equal(countBefore + 1, countAfter);

            var addedLesson = controller.Get().Last();
            Assert.Equal("חינוך", addedLesson.Title);
        }

        [Fact]
        public void Put_ShouldUpdateLesson()
        {
            var controller = new LessonController();
            var updatedLesson = new Lesson { Title = "עודכן", TeacherId = 1, Date = DateTime.Now, Duration = 90 };

            controller.Put(1, updatedLesson);

            var lesson = controller.Get(1) as OkObjectResult;
            var l = lesson.Value as Lesson;
            Assert.Equal("עודכן", l.Title);
            Assert.Equal(90, l.Duration);
        }

        [Fact]
        public void Delete_ShouldRemoveLesson()
        {
            var controller = new LessonController();
            int countBefore = controller.Get().Count();

            controller.Delete(2); // מוחק שיעור מסוים

            int countAfter = controller.Get().Count();
            Assert.Equal(countBefore - 1, countAfter);
            Assert.DoesNotContain(controller.Get(), l => l.Id == 2);
        }
    }
}
