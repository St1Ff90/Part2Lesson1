using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entities;

namespace Part2Lesson1.Controllers
{
    public class TeacherController
    {
        private List<Teacher> _teachers;
        private List<LessonTeacher> _lessonTeachers;

        public TeacherController()
        {
            _teachers = new List<Teacher>();
            _lessonTeachers = new List<LessonTeacher>();
        }

        public bool AddTeacher(Teacher teacher)
        {
            bool result = false;

            if (IsTeacherValid(teacher))
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

        private bool IsTeacherValid(Teacher teacher)
        {
            bool result = false;

            if (teacher != null && !string.IsNullOrEmpty(teacher.FirstName) && !string.IsNullOrEmpty(teacher.LastName) && (teacher.LastName.Length + teacher.FirstName.Length) > 3)
            {
                result = true;
            }

            return result;
        }

        public bool LinkTeacherToLesson(Lesson lesson, Teacher teacher)
        {
            bool result = false;

            if (lesson == null || teacher == null)
            {
                throw new ArgumentNullException("Obj is null!");
            }
            else
            {
                LessonTeacher lessonTeacher = new LessonTeacher(lesson.Id, teacher.Id);

                if (_lessonTeachers.Contains(lessonTeacher))
                {
                    result = true;
                }
                else
                {
                    result = true;
                    _lessonTeachers.Add(lessonTeacher);
                }
            }

            return result;
        }

        public IEnumerable<Teacher> GetListOfTeachersWhoCanDriveLesson(Category category)
        {
            return _teachers.Where(x => x.Category >= category).Select(x => x.Clone() as Teacher);
        }

        public IEnumerable<LessonTeacher> GetLinkedPairsOfTeacherAndLesson()
        {
            return _lessonTeachers.Select(x => x.Clone() as LessonTeacher);
        }

        public Guid GetLessonId(Guid teacherId)
        {
            if (_lessonTeachers.Any(x => x.TeacherId == teacherId))
            {
                return _lessonTeachers.First(x => x.TeacherId == teacherId).LessonId;
            }
            else
            {
                throw new AggregateException("Not found!");
            }

            throw new AggregateException("Null value of teacher!");
        }
    }
}
