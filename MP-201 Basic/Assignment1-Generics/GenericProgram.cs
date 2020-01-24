using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Generics
{
    class GenericProgram
    {
        public void GenericMethod<Type>(Type value, string msg)
        {
            Console.WriteLine(msg + " " + value);
        }

        public List<T> GetList<T>(T value, int count,string msg)
        {
            Console.WriteLine(msg);
            List<T> list = new List<T>();
            while (count!=0)
            {
                list.Add(value);
                count--;
            }
            return list;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Class Example");
            Generic<string> gs = new Generic<string>("Data type is String","My Name is Avilash");
            Generic<int> gi = new Generic<int>("Data type is Integer" ,121);
            Generic<float> gf = new Generic<float>("Data type is Float", 2.3f);
            Generic<decimal> gd = new Generic<decimal>("Data type is Decimal", 255);
            Generic<double> gD = new Generic<double>("Data type is Double", 265.36);
            Generic<bool> gb = new Generic<bool>("Data type is Bool",false);


            Console.WriteLine("\n\n Generic Method Example");
            GenericProgram g = new GenericProgram();
            g.GenericMethod<string>("Data type is String", "My Name is Avilash");
            g.GenericMethod<int>(12, "Data type is Integer");
            g.GenericMethod<float>(12.5f, "Data type is Float");
            g.GenericMethod<decimal>(125, "Data type is Decimal");
            g.GenericMethod<double>(127.6589, "Data type is Double");
            g.GenericMethod<bool>(true, "Data type is Double");


            Console.WriteLine("\n\n Generic List Example");
            List<string> stringlist = g.GetList<string>("I am Avilash", 5, "Data type is string");
            foreach (string value in stringlist)
            {
                Console.WriteLine(value);
            }

            List<int> intlist = g.GetList<int>(12, 5, "Data type is Integer");
            foreach (int value in intlist)
            {
                Console.WriteLine(value);
            }
            List<bool> boollist = g.GetList<bool>(true, 3, "Data type is Boolean");
            foreach (bool value in boollist)
            {
                Console.WriteLine(value);
            }
            List<double> doublelist = g.GetList<double>(21.56, 3, "Data type is Double");
            foreach (double value in doublelist)
            {
                Console.WriteLine(value);
            }
            
            Console.ReadKey();
        }
    }
}
