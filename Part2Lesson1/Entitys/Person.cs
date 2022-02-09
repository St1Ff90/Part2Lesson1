using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1
{
    abstract public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
            FirstName = "Empty";
            LastName = "Empty";
        }
    }
}
