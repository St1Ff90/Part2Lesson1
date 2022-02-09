using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entitys
{
    public class Room : Entity
    {
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Address
        {
            get
            {
                return Floor * 100 + Number;
            }
        }
    }
}
