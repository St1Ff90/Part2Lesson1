using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entitys;

namespace Part2Lesson1.Controllers
{
    public class StudentController
    {
        private List<Student> _students;

        public StudentController()
        {
            _students = new List<Student>();
        }

        public bool AddStudent(Student student)
        {
            bool result = false;

            if (student != null && !string.IsNullOrEmpty(student.FirstName) && !string.IsNullOrEmpty(student.LastName) && (student.LastName.Length + student.FirstName.Length) > 3)
            {
                result = true;
                Student copy = new Student(student);
                _students.Add(copy);
            }
            else
            {
                throw new ArgumentException("Student is null or has a short info!");
            }

            return result;
        }

        public IEnumerable<Student> GetListOfStudentsWhoCanVisitLesson(int classnum)
        {
            return _students.Where(x => x.Class == classnum);
        }
    }
}
