using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Collection
{
    class Program
    {
        public static void CollectionMethod()
        {
            Console.WriteLine("Select a number \n 1.List \n 2.SortedList \n 3.SortedSet \n 4.LinkedList \n 5. Dictionary\n 6. HashSet\n 7.Stack \n 8.Queue");
            Collection c = Collection.GetInstance();
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("List Selected");
                    c.List();
                    c.ShowList();
                    break;
                case 2:
                    Console.WriteLine("SortedList Selected");
                    c.SortedList();
                    c.ShowSortedList();
                    break;
                case 3:
                    Console.WriteLine("SortedSet Selected");
                    c.SortedSet();
                    c.ShowSortedSet();
                    break;
                case 4:
                    Console.WriteLine("LinkedList Selected");
                    c.LinkedList();
                    c.ShowLinkedList();
                    break;
                case 5:
                    Console.WriteLine("Dictionary Selected");
                    c.Dictionary();
                    c.ShowDictionary();
                    break;
                case 6:
                    Console.WriteLine("HashSet Selected");
                    c.HashSet();
                    c.ShowHashSet();
                    break;
                case 7:
                    Console.WriteLine("Stack Selected");
                    c.Stack();
                    c.ShowStack();
                    break;
                case 8:
                    Console.WriteLine("Queue Selected");
                    c.Queue();
                    c.ShowQueue();
                    break;
            }
        }
        static void Main(string[] args)
        {
            int option;
            do
            {
                CollectionMethod();
                again:
                Console.WriteLine("Do you want to continue ? \npress 0 to exit \n1 to continue");
                option = int.Parse(Console.ReadLine());
                if(option != 0 || option != 1)
                {
                    Console.WriteLine("Please select 0 or 1");
                    goto again;
                }
            } while (option != 0 );
            Console.WriteLine("Exited from program");
            Console.ReadKey();
        }
    }
}
