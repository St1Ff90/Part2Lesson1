using Part2Lesson1.Controllers;
using Part2Lesson1.Entities;
using Part2Lesson1.Helpers;

LessonController lessonController = new LessonController();
RoomController roomController = new RoomController();
TeacherController teacherController = new TeacherController();
StudentController studentController = new StudentController();
List<Price> priceList = new List<Price>();
Random rand = new Random();

for (int i = 0; i < 10; i++)
{
    Lesson lesson = new Lesson();
    lesson.TargetClass = rand.Next(1, 11);
    lesson.MinimumRequiredCategory = (Category)rand.Next(1, 5);
    lesson.Title = "Math" + rand.Next(1, 11);
    lessonController.AddLesson(lesson);

    Room room = new Room(rand.Next(1, 5));
    roomController.AddRoom(room);

    for (int j = 0; j < 2; j++)
    {
        Teacher teacher = new Teacher();
        teacher.Category = (Category)rand.Next(1, 5);
        teacher.LastName = "LastNameTeacher" + rand.Next(20, 100);
        teacher.FirstName = "FirstNameTeacher" + rand.Next(20, 100);
        teacherController.AddTeacher(teacher);
    }

    Student student = new Student();
    student.Class = rand.Next(1, 11);
    student.LastName = "LastNameStudent" + rand.Next(20, 100);
    student.FirstName = "FirstNameStudent" + rand.Next(20, 100);
    studentController.AddStudent(student);
}

for (int i = 0; i < 11; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Price price = new Price();
        price.Class = i + 1;
        price.Category = (Category)j + 1;
        price.CurrentPrice = 1000 + (1000 * price.Class / 10) + (1000 * (int)price.Category / 2);
        priceList.Add(price);
    }
}

LessonScheduller lessonScheduller = new LessonScheduller();
//List<LessonRoom> lessonRooms = lessonScheduller.SchedulleLessons(lessonController, roomController);
//List<LessonTeacher> lessonTeachers = lessonScheduller.SchedulleTeachers(lessonController, teacherController);