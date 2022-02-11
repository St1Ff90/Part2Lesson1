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
        private static int _baseSalary = 1000;

        public LessonController()
        {
            _lessons = new List<Lesson>();
            _lessonRooms = new List<LessonRoom>();
            _salaryList = new List<Price>();
            CalculateSalaryList(_baseSalary);
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
            bool result = false;

            if (lesson == null || room == null)
            {
                throw new ArgumentNullException("Obj is null!");
            }

            LessonRoom lessonRoom = new LessonRoom(lesson.Id, room.Id);

            if (_lessonRooms.Contains(lessonRoom))
            {
                result = true;
            }
            else if (_lessonRooms.Any(x => x.RoomId == lessonRoom.RoomId))
            {
                throw new ArgumentException("Room are already occupied!");
            }
            else
            {
                result = true;
                _lessonRooms.Add(lessonRoom);
            }

            return result;
        }

        public IEnumerable<Lesson> GetListOfLessonsForTargetClass(int classnum)
        {
            return _lessons.Where(x => x.TargetClass == classnum).Select(x => x.Clone() as Lesson);
        }

        public IEnumerable<Lesson> GetListOfLessonsForTargetCategory(Category category)
        {
            return _lessons.Where(x => x.MinimumRequiredCategory >= category).Select(x => x.Clone() as Lesson);
        }

        public IEnumerable<Lesson> GetLessons()
        {
            return _lessons.Select(x => x.Clone() as Lesson);
        }

        public IEnumerable<LessonRoom> GetLinkedPairsOfLessonAndRoom()
        {
            return _lessonRooms.Select(x => x.Clone() as LessonRoom);
        }

        public Guid GeRoomId(Guid lessonId)
        {
            if (_lessonRooms.Any(x => x.LessonId == lessonId))
            {
                return _lessonRooms.First(x => x.LessonId == lessonId).RoomId;
            }

            return Guid.Empty;
        }

        public Lesson GetLesson(Guid lessonId)
        {
            if (_lessons.Any(x => x.Id == lessonId))
            {
                return _lessons.First(x => x.Id == lessonId).Clone() as Lesson; ;
            }
            throw new Exception("Not found!");
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
            if (_salaryList.Any(x => x.Category == teacher.Category && x.Class == lesson.TargetClass))
            {
                return _salaryList.First(x => x.Category == teacher.Category && x.Class == lesson.TargetClass).Clone() as Price;
            }

            throw new Exception("Price doen't exist!");
        }
    }
}
