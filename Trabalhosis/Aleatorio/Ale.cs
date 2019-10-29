using System;

namespace Trabalhosis
{
    class Ale
    {
        
        public static DateTime RandomDay(int bo,int al)
        {
            Random esse = new Random(bo+al);
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(esse.Next(range));
        }
    }
}
