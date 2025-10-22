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
    public class UserControllerTest
    {
        [Fact]
        public void Get_ReturnList()
        {
            var controller = new UserController();
            var result = controller.Get();
            Assert.IsType<List<User>>(result);
        }
        [Fact]
        public void Get_ReturnCount()
        {
            var controller = new UserController();
            var result = controller.Get();
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void GetById_ReturnOk()
        {
            var id = 1;
            var controller = new UserController();
            var result = controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetById_ReturnNotFound()
        {
            var id = 8;
            var controller = new UserController();
            var result = controller.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ShouldAddUser()
        {
            var controller = new UserController();
            int countBefore = controller.Get().Count();

            var newUser = new User { Name = "משה לוי", Role = "student", Email = "moshe@example.com" };
            controller.Post(newUser);

            int countAfter = controller.Get().Count();
            Assert.Equal(countBefore + 1, countAfter);

            var addedUser = controller.Get().Last();
            Assert.Equal("משה לוי", addedUser.Name);
        }
        [Fact]
        public void Put_ShouldUpdateUser()
        {
            var controller = new UserController();

            var updatedUser = new User { Name = "עודכן", Role = "teacher", Email = "new@example.com" };
            controller.Put(1, updatedUser);

            var user = controller.Get(1) as OkObjectResult;
            var u = user.Value as User;
            Assert.Equal("עודכן", u.Name);
            Assert.Equal("teacher", u.Role);
            Assert.Equal("new@example.com", u.Email);
        }

        [Fact]
        public void Delete_ShouldRemoveUser()
        {
            var controller = new UserController();
            int countBefore = controller.Get().Count();

            controller.Delete(2); // מוחק את "שרה לוי"

            int countAfter = controller.Get().Count();
            Assert.Equal(countBefore - 1, countAfter);
            Assert.DoesNotContain(controller.Get(), u => u.Id == 2);
        }

    }
}
