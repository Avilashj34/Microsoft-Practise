using System;

namespace Assignment1_Basic
{
    class Program
    {
        /*Swapping of Number Without using third variable*/
        public static void Swap(int a, int b)
        {
            a = a * b;
            b = a / b;
            a = a / b;
            Console.WriteLine("First Number "+a + " " + "Second Number "+b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Swapping of Number without using Third Variable" );
            Console.WriteLine("Enter First Number");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            int b = int.Parse(Console.ReadLine());
            Swap(a, b);
            Console.ReadKey();
        }
}
}
