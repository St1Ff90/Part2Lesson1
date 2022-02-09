using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entitys;

namespace Part2Lesson1.Controllers
{
    public class LessonController
    {
        private List<Lesson> _lessons;

        public LessonController()
        {
            _lessons = new List<Lesson>();
        }

        public bool AddLesson(Lesson lesson)
        {
            bool result = false;

            if (lesson != null && lesson.TargetClass >= 1 && lesson.TargetClass <= 11)
            {
                result = true;
                Lesson copy = new Lesson(lesson);
                _lessons.Add(copy);
            }
            else
            {
                throw new ArgumentException("Invalid lesson data!");
            }

            return result;
        }

        public IEnumerable<Lesson> GetListOfLessonsForTargetClass(int classnum)
        {
            return _lessons.Where(x => x.TargetClass == classnum);
        }

        public IEnumerable<Lesson> GetListOfLessonsForTargetCategory(Category category)
        {
            return _lessons.Where(x => x.MinimumRequiredCategory >= category);
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return _lessons;
        }
    }
}
