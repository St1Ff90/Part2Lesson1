using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entities
{
    public class Price : Entity, ICloneable
    {
        public int Class { get; set; }
        public Category Category { get; set; }
        public double CurrentPrice { get; set; }

        public Price()
        {
            Class = 1;
            Category = Category.First;
            CurrentPrice = 0.00;
        }

        public Price(int _class, Category category, double currentPrice)
        {
            Class = _class;
            Category = category;
            CurrentPrice = currentPrice;
        }

        public object Clone()
        {
            return new Price(Class, Category, CurrentPrice);
        }
    }
}
