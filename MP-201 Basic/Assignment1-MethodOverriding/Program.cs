using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MethodOverriding
{
    class Program
    {
        static void Main(string[] args)
        {
            Saving_Account s = new Saving_Account();
            s.Detail();
            Current_Accout c = new Current_Accout();
            c.Detail();


            /* Acces using Base Class*/
            Console.WriteLine("Using Base Class");
            Bank b; 
            b= new Saving_Account();
            b.Detail();
            b = new Current_Accout();
            b.Detail();
            Console.ReadKey();
        }
    }
}
