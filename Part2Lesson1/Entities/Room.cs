using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class Room : Entity
    {
        public static Dictionary<int, int> FloorLastNum { get; private set; }
        public int Floor { get; set; }
        private int Number { get; set; }

        public int Address
        {
            get
            {
                return Floor * 100 + Number;
            }
        }

        static Room()
        {
            FloorLastNum = new Dictionary<int, int>();

            for (int i = 0; i < 4; i++)
            {
                FloorLastNum.Add(i + 1, 0);
            }
        }

        public Room(int flor)
        {
            FloorLastNum[flor] += 1;
            Number = FloorLastNum[flor];
            Floor = flor;
        }
    }
}
