using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class LessonRoom : ICloneable
    {
        public Guid LessonId { get; set; }
        public Guid RoomId { get; set; }

        public LessonRoom(Guid lessonId, Guid roomId)
        {
            LessonId = lessonId;
            RoomId = roomId;
        }

        public object Clone()
        {
            return new LessonRoom(LessonId, RoomId);
        }
    }
}
