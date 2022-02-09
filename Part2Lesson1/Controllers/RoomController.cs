using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part2Lesson1.Entitys;

namespace Part2Lesson1.Controllers
{
    public class RoomController
    {
        private List<Room> _rooms;

        public RoomController()
        {
            _rooms = new List<Room>();
        }

        public bool AddRoom(Room room)
        {
            bool result = false;

            if (room != null && room.Number > 0 && room.Floor >= 0 && room.Floor < 5)
            {
                result = true;
                _rooms.Add(room);
            }
            else
            {
                throw new ArgumentException("Invalid room data!");
            }

            return result;
        }

        public IEnumerable<Room> GetRooms()
        {
            return _rooms;
        }
    }
}
