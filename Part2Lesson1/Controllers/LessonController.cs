using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entities;

namespace Part2Lesson1.Controllers
{
    public class LessonController
    {
        private List<Lesson> _lessons;
        private List<LessonRoom> _lessonRooms;
        private List<Price> _salaryList;

        public LessonController()
        {
            _lessons = new List<Lesson>();
            _lessonRooms = new List<LessonRoom>();
            _salaryList = new List<Price>();
            CalculateSalaryList(1000);
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

        public bool LinkLessonToRoom(Lesson lesson, Room room)
        {
            bool Result = false;

            if (lesson == null || room == null)
            {
                throw new ArgumentNullException("Obj is null!");
            }
            else
            {
                LessonRoom lessonRoom = new LessonRoom(lesson.Id, room.Id);

                if (_lessonRooms.Contains(lessonRoom))
                {
                    throw new ArgumentException("Both are already linked!");
                }
                else if (_lessonRooms.Any(x => x.RoomId == lessonRoom.RoomId))
                {
                    throw new ArgumentException("Room are already occupied!");
                }
                else
                {
                    Result = true;
                    _lessonRooms.Add(lessonRoom);
                }
            }

            return Result;
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

        public IEnumerable<LessonRoom> GetLinkedPairsOfLessonAndRoom()
        {
            return _lessonRooms;
        }

        public Guid GeRoomId(Lesson lesson)
        {
            if (lesson != null)
            {
                if (_lessonRooms.Any(x => x.LessonId == lesson.Id))
                {
                    return _lessonRooms.FirstOrDefault(x => x.LessonId == lesson.Id).RoomId;
                }
                else
                {
                    throw new AggregateException("Not found!");
                }
            }

            throw new AggregateException("Null value of lesson!");
        }

        public Lesson GetLesson(Guid id)
        {
            return _lessons.FirstOrDefault(x => x.Id == id);
        }

        public void CalculateSalaryList(double baseSalary)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Price price = new Price();
                    price.Class = i + 1;
                    price.Category = (Category)j + 1;
                    price.CurrentPrice = baseSalary + (baseSalary * price.Class / 10) + (baseSalary * (int)price.Category / 2);
                    _salaryList.Add(price);
                }
            }
        }

        public Price GetPriceForTeacherByLesson(Teacher teacher, Lesson lesson)
        {
            return _salaryList.FirstOrDefault(x => x.Category == teacher.Category && x.Class == lesson.TargetClass);
        }
    }
}
