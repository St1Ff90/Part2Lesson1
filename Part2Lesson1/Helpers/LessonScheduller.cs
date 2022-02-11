using Part2Lesson1.Controllers;
using Part2Lesson1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Helpers
{
    public class LessonScheduller
    {
        public IEnumerable<Lesson> recomendedLessons(LessonController lessonController, Student student)
        {
            return lessonController.GetListOfLessonsForTargetClass(student.Class);
        }
    }
}
