using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Collection
{
    class CollectionDeclaration
    {
        internal List<int> list = new List<int>();
        internal SortedList<int, string> sortedlist = new SortedList<int, string>();
        internal SortedSet<string> sortedset = new SortedSet<string>();
        internal HashSet<string> hashset = new HashSet<string>();
        internal LinkedList<int> linklist = new LinkedList<int>();
        internal Dictionary<int, string> dictionary = new Dictionary<int, string>();
        internal Stack<int> stack = new Stack<int>();
        internal Queue<string> queue = new Queue<string>();
    }
    class Collection : CollectionDeclaration
    {       
        public static Collection collection= null;
        private Collection(){ }
        /*Singleton Class*/
        public static Collection GetInstance()
        {
            if(collection == null)
            {
                collection = new Collection();
                return collection;
            }
            else
            {
                return collection;
            }
        }
        public void List()
        {           
            Console.WriteLine("How many item want to add");
            int i=int.Parse( Console.ReadLine());
            Console.WriteLine("Enter Integer to be added");
            while (i != 0)
            {               
                list.Add(int.Parse(Console.ReadLine()));
                i--;
            }
        }
        public void ShowList()
        {
            int j = 0;
            foreach(int i in list)
            {
                Console.WriteLine("Element at index position {0} is : {1}",j++,i);
            }
        }

        public void SortedList()
        {
            Console.WriteLine("How many item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer and string to be added");
            while (i != 0)
            {
                sortedlist.Add(int.Parse(Console.ReadLine()), Console.ReadLine());
                i--;
            }
        }
        public void ShowSortedList()
        {           
            foreach(var i in sortedlist)
            {
                Console.WriteLine("Element at index position {0} is : {1}", i.Key,i.Value );
            }
        }

        public void SortedSet()
        {
            Console.WriteLine("How many item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter String to be added");
            while (i != 0)
            {
                sortedset.Add(Console.ReadLine());
                i--;
            }
        }
        public void ShowSortedSet()
        {
            int j = 0;
            foreach (string i in sortedset)
            {
                Console.WriteLine("Element at index position {0} is : {1}", j++, i);
            }
        }

        public void HashSet()
        {
            Console.WriteLine("How many item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer to be added");
            while (i != 0)
            {
                hashset.Add(Console.ReadLine());
                i--;
            }
        }
        public void ShowHashSet()
        {
            int j = 0;
            foreach (string i in hashset)
            {
                Console.WriteLine("Element at index position {0} is : {1}", j++, i);
            }
        }

        public void LinkedList()
        {
            Console.WriteLine("How many item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer to be added");
            linklist.AddFirst(int.Parse(Console.ReadLine()));
            while ((i-1)!= 0)
            {
                linklist.AddLast(int.Parse(Console.ReadLine()));
                i--;
            }
        }
        public void ShowLinkedList()
        {
            //int j = 0;
            foreach (int i in linklist)
            {
                /*Console.WriteLine("Element at index position {0} is : {1}", j++, i);*/
                Console.Write(i +"->");
            }
        }

        public void Dictionary()
        {
            Console.WriteLine("How manyt item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer and String to be added");
            while (i!= 0)
            {
                dictionary.Add(int.Parse(Console.ReadLine()),Console.ReadLine());
                i--;
            }
        }
        public void ShowDictionary()
        {
            int j = 0;
            foreach (var i in dictionary)
            {
                Console.WriteLine("Element at index position {0} is : {1}",i.Key, i.Value);
            }
        }

        public void Stack()
        {
            Console.WriteLine("How manyt item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer to be added");
            while (i != 0)
            {
                stack.Push(int.Parse(Console.ReadLine()));
                i--;
            }
        }
        public void ShowStack()
        {
            int j = 0;
            Console.WriteLine("Element at top is : "+stack.Peek()  +" and count of stack is "+stack.Count);
            foreach (int i in stack)
            {
                Console.WriteLine("Element at index position {0} is : {1}", j++, i);
            }
        }

        public void Queue()
        {
            Console.WriteLine("How manyt item want to add");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Integer to be added");
            while (i != 0)
            {
                queue.Enqueue(Console.ReadLine());
                i--;
            }
        }
        public void ShowQueue()
        {
            int j = 0;
            Console.WriteLine("Element at top is : " + queue.Peek() + " and count of stack is " + queue.Count);
            foreach (string i in queue)
            {
                Console.WriteLine("Element at index position {0} is : {1}", j++, i);
            }
        }
    }
}
