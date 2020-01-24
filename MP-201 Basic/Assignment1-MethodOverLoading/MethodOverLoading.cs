using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MethodOverLoading
{
    class MethodOverLoading
    {
        public void CalculateSalary(double dailysalary)
        {
            Console.WriteLine("Daily Salary is :- " + dailysalary);
        }
        public void CalculateSalary(double dailysalary,int presentday)
        {
            double salary = dailysalary * presentday;
            Console.WriteLine("Monthly Salary :- "+salary);
        }
        public void CalculateSalary(double dailysalary, int presentday,int bonus)
        {
            double salary = dailysalary * presentday + bonus;
            Console.WriteLine("Monthly Salary With Bonus :- "+salary);
        }
        /*public void CalculateSalary(double dailysalary, int presentday, int month)
        {
            double salary = month * (dailysalary * presentday) ;
            Console.WriteLine("Annual Salary  :- " + salary);
        }*/
        public void CalculateSalary(double dailysalary, int presentday, int bonus,int month)
        {
            double salary = month*(dailysalary * presentday) + bonus;
            Console.WriteLine("Annual Salary With Bonus :- " + salary);
        }
        static void Main(string[] args)
        {
            MethodOverLoading m = new MethodOverLoading();
            m.CalculateSalary(200.25);
            m.CalculateSalary(200.25,28);
            m.CalculateSalary(200.25,28,1000);
            m.CalculateSalary(200.25, 28, 1000,12);
            Console.ReadKey();
        }
    }
}
