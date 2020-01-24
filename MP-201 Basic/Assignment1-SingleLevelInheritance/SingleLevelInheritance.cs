using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_SingleLevelInheritance
{
    class Teacher
    {
        public void Teach()
        {
            Console.WriteLine("In Teacher Class");
        }
    }

    class Student : Teacher
    {
        public void Learn()
        {
            Console.WriteLine("In Student Class");
        }
    }
    class SingleLevelInheritance
    {
        static void Main(string[] args)
        {
            Teacher t = new Teacher();
            t.Teach();
            Teacher s = new Student();
            s.Teach();
            Student std = new Student();
            std.Teach();
            std.Learn();
            Console.ReadKey();
        }
    }
}
