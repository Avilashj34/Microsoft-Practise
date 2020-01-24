using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MethodOverriding
{
    class Bank
    {
        public virtual void Detail()
        {
            Console.WriteLine("In Base Class :- Bank ");
        }
    }
    class Saving_Account : Bank
    {
        public override void Detail()
        {
            Console.WriteLine("In First Derived Class :- Saving Account");
        }
    }
    class Current_Accout : Bank
    {
        public override void Detail()
        {
            Console.WriteLine("In Second Derived Class :- Current Account");
        }
    }
    
}
