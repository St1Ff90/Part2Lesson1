using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1
{
    abstract public class Entity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
