using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class LessonTeacher : ICloneable
    {
        public Guid LessonId { get; set; }
        public Guid TeacherId { get; set; }

        public LessonTeacher(Guid lessonId, Guid teacherId)
        {
            LessonId = lessonId;
            TeacherId = teacherId;
        }

        public object Clone()
        {
            return new LessonTeacher(LessonId, TeacherId);
        }
    }
}
