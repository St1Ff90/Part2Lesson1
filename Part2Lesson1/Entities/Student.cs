﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class Student : Person, ICloneable
    {
        public int Class { get; set; }

        public Student()
        {
            Class = 1;
        }

        public Student(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            Class = student.Class;
        }

        public object Clone()
        {
            return new Student(this);
        }
    }
}
