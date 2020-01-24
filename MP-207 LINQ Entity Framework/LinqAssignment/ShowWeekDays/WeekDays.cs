using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowWeekDays
{
    class WeekDays
    {
        static void Main(string[] args)
        {
            List<string> weekdays = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday" };
            var methodresult = weekdays.Select(w=> w); //Method Syntax
            /*var queryresult = from w in weekdays
                              select w; */            //Qwery Syntax
            Console.WriteLine("The WeekDays are ");
            foreach (var i in methodresult)
            {
                Console.WriteLine(i);
            }
        }
    }
}
