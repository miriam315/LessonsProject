using LessonsProject.Controllers;
using LessonsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsProjectTest
{
    public class MaterialControllerTest
    {
        [Fact]
        public void Get_ShouldReturnMaterials()
        {
            var controller = new MaterialController();
            var result = controller.Get(1); // lessonId = 1
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Post_ShouldAddMaterial()
        {
            var controller = new MaterialController();
            int countBefore = controller.Get(1).Count();

            var newMaterial = new Material { Title = "מצגת פתיחה", Type = "pdf", Url = "http://test.com" };
            controller.Post(1, newMaterial);

            int countAfter = controller.Get(1).Count();
            Assert.Equal(countBefore + 1, countAfter);
            Assert.Contains(controller.Get(1), m => m.Title == "מצגת פתיחה");
        }

        [Fact]
        public void Put_ShouldUpdateMaterial()
        {
            var controller = new MaterialController();
            var updated = new Material { Title = "חדש", Type = "pdf", Url = "new.com" };

            controller.Put(1, 1, updated);

            var material = controller.Get(1).First(m => m.Id == 1);
            Assert.Equal("חדש", material.Title);
        }

        [Fact]
        public void Delete_ShouldRemoveMaterial()
        {
            var controller = new MaterialController();
            int countBefore = controller.Get(1).Count();

            controller.Delete(1, 1); // lessonId = 1, materialId = 1

            int countAfter = controller.Get(1).Count();
            Assert.Equal(countBefore - 1, countAfter);
        }
    }
}
