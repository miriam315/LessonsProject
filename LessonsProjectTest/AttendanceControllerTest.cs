using LessonsProject.Controllers;
using LessonsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsProjectTest
{
    public class AttendanceControllerTest
    {
        [Fact]
        public void Get_ShouldReturnAttendanceList()
        {
            var controller = new AttendanceController();
            var result = controller.Get(1); // lessonId = 1
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Post_ShouldAddAttendance()
        {
            var controller = new AttendanceController();
            int countBefore = controller.Get(1).Count();

            var record = new Attendance { StudentId = 2, Status = "נכח" };
            controller.Post(1, record);

            int countAfter = controller.Get(1).Count();
            Assert.Equal(countBefore + 1, countAfter);
            Assert.Contains(controller.Get(1), a => a.StudentId == 2 && a.Status == "נכח");
        }

        [Fact]
        public void Put_ShouldUpdateAttendance()
        {
            var controller = new AttendanceController();
            var updated = new Attendance { StudentId = 2, Status = "היעדרות" };

            controller.Put(1, 1, updated); // lessonId = 1, attendanceId = 1

            var attendance = controller.Get(1).First(a => a.Id == 1);
            Assert.Equal("היעדרות", attendance.Status);
        }

        [Fact]
        public void Delete_ShouldRemoveAttendance()
        {
            var controller = new AttendanceController();
            int countBefore = controller.Get(1).Count();

            controller.Delete(1, 1);

            int countAfter = controller.Get(1).Count();
            Assert.Equal(countBefore - 1, countAfter);
        }
    }
}
