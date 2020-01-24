using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Generics
{
    class Generic<T>
    {
        T data;
        public Generic(string msg,T value)
        {
            this.data = value;
            Console.WriteLine(msg+" "+value);
        }

        
    }
}
