using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Looping
{
    class Program
    {
        /*Fibonacci Series
              Ex :- 0,1,1,2,3,5  */
        void FibonacciSeries(int limit)
        {
            int a = 0, b = 1,c,count=0;
            Console.Write(a+" "+b);
            for (int i=0;i<limit-2;i++)
            {
                c = a + b;
                Console.Write(" "+c);
                a = b;
                b = c;
                count++;
            }
            Console.WriteLine("\nEnter in loop " + count + " times");
        }
        /* 1 3 5 7 11 13 17*/
        void PrimeNumber(int limit)
        {
            int i = 1,count=0;
            while (i<=limit)
            {
                if (IsPrime(i))
                {
                    Console.Write(i+" ");
                }
                i++;
                count++;
            }
            Console.WriteLine("\nEnter in loop " + count + " times");
        }

        bool IsPrime(int n)
        {
            if (n<=1)
            {
                return false;
            }
            int i = 2;
            while (i<=n)
            {
                if (n % i == 0)
                    return true;
                i++;
            }
            return false;
        }


        void EvenOdd(int limit)
        {
            int i = 1,count=0;
            do
            {
                if (i % 2 == 0)
                    Console.Write("EvenNumber : "+i+"\t");
                Console.Write("OddNumber : " + i + "\t");
                i++;
                count++;
            } while (i <= limit);
            Console.WriteLine("\nEnter in loop " + count+" times");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number");
            
            new Program().FibonacciSeries(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Number");
            new Program().PrimeNumber(int.Parse(Console.ReadLine()));
            
            Console.WriteLine("Enter Number");
            new Program().EvenOdd(int.Parse(Console.ReadLine()));
            Console.ReadKey();

        }
    }
}
