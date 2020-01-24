using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterThan100
{
    class GreaterThan100
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>{ 55, 200, 740, 76, 230, 482, 95 };
            List<int> result = (from l in list
                         where l > 100
                         select l).ToList();
            Console.WriteLine("Number Greater than 100");
            foreach(var i in result)
            {
                Console.WriteLine(i);   
            }
        }
    }
}
