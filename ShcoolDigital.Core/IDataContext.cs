using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Service
{
    interface IDataContext
    {
        public List<Lesson> lessons { get; set; }
        public List<User> users { get; set; }
        public List<Attendance> attendanceList { get; set; }
        public List<Material> materialsList { get; set; }
    }
}
