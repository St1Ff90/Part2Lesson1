using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entitys;

namespace Part2Lesson1.Controllers
{
    public class TeacherController
    {
        private List<Teacher> _teachers;

        public TeacherController()
        {
            _teachers = new List<Teacher>();
        }

        public bool AddTeacher(Teacher teacher)
        {
            bool result = false;

            if (teacher != null && !string.IsNullOrEmpty(teacher.FirstName) && !string.IsNullOrEmpty(teacher.LastName) && (teacher.LastName.Length + teacher.FirstName.Length) > 3)
            {
                result = true;
                Teacher copy = new Teacher(teacher);
                _teachers.Add(copy); 
            }
            else
            {
                throw new ArgumentException("Teacher is null or has a short info!");
            }

            return result;
        }

        public IEnumerable<Teacher> GetListOfTeachersWhoCanDriveLesson(Category category)
        {
            return _teachers.Where(x => x.Category >= category);
        }
    }
}
