using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2Lesson1.Entitys
{
    public class Price : Entity
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

        public Price(int _class, int category, double currentPrice)
        {
            Class = _class;
            Category = (Category)category;
            CurrentPrice = currentPrice;
        }
    }
}
