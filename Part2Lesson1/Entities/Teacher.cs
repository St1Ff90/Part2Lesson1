using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class Teacher : Person, ICloneable
    {
        public Category Category { get; set; }

        public Teacher()
        {
            Category = Category.First;
        }
        
        public Teacher(Teacher teacher)
        {
            Category = teacher.Category;
            base.FirstName = teacher.FirstName;
            base.LastName = teacher.LastName;
        }

        public object Clone()
        {
            return new Teacher(this);
        }
    }
}
