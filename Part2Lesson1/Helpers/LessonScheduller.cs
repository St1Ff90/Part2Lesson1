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

        public List<LessonRoom> SchedulleLessons(LessonController lessons, RoomController rooms)
        {
            List<LessonRoom> lessonRooms = new List<LessonRoom>();

            if (lessons == null || rooms == null)
            {
                throw new ArgumentNullException("Obj is null!");
            }
            else if (lessons.GetLessons().Count() > rooms.GetRooms().Count())
            {
                throw new ArgumentNullException("Lessons couldn't be scheduled, too many lessons!");
            }
            else
            {
                List<Room> roomList = rooms.GetRooms().ToList();

                foreach (Lesson lesson in lessons.GetLessons())
                {
                    Room currentRoom = roomList.First();
                    lessonRooms.Add(new LessonRoom(lesson.Id, currentRoom.Id));
                    roomList.Remove(currentRoom);
                }
            }

            return lessonRooms;
        }

        public List<LessonTeacher> SchedulleTeachers(LessonController lessons, TeacherController teachers)
        {
            List<LessonTeacher> lessonTeachers = new List<LessonTeacher>();

            if (lessons == null || teachers == null)
            {
                throw new ArgumentNullException("Obj is null!");
            }
            else
            {
                foreach (Lesson lesson in lessons.GetLessons())
                {
                    foreach(Teacher teacher in teachers.GetListOfTeachersWhoCanDriveLesson(lesson.MinimumRequiredCategory))
                    {
                        if(lessonTeachers.FirstOrDefault(x => x.TeacherId == teacher.Id) == null)
                        {
                            lessonTeachers.Add(new LessonTeacher(lesson.Id, teacher.Id));
                            break;
                        }
                    }
                    if(lessonTeachers.FirstOrDefault(x => x.LessonId == lesson.Id) == null)
                    {
                        throw new Exception("Theare are no teacher for lesson with id" + lesson.Id);
                    }
                }
            }

            return lessonTeachers;
        }

        public IEnumerable<Lesson> recomendedLessons(LessonController lessonController, Student student)
        {
            return lessonController.GetListOfLessonsForTargetClass(student.Class);
        }
    }
}
