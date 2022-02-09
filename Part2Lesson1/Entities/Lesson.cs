using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class Lesson : Entity
    {
        public string Title { get; set; }
        public Category MinimumRequiredCategory { get; set; }
        public int TargetClass { get; set; }

        public Lesson()
        {
            Title = "Empty";
            MinimumRequiredCategory = Category.First;
            TargetClass = 1;
        }

        public Lesson(Lesson lesson)
        {
            Title = lesson.Title;
            MinimumRequiredCategory = lesson.MinimumRequiredCategory;
            TargetClass = lesson.TargetClass;
        }
    }
}
