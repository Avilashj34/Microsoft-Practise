using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_AcessModifier
{
    public class AcessModifier
    {
        int data;
        public void SetData(int data)
        {
            this.data = data;
        }

        public int GetData()
        {
            return this.data;
        }
        public void Show()
        {
            Console.WriteLine("In public access modifier " + GetData());
        }

    }

    class ProtectedModifier
    {
        protected int X;
        public void SetX(int X)
        {
            this.X = X;
        }

        public int GetX()
        {
            return this.X;
        }
    }
    class ExtendProtectedModifier : ProtectedModifier
    {
        public void Show()
        {
            Console.WriteLine("In protected Class " + GetX());
        }
    }

    class PrivateModifier{
        private int Value;
        private void SetValue(int Value)
        {
            this.Value = Value;
        }
        private int GetValue()
        {
            return this.Value;
        }
    }
    class ExtendPrivateModifier : PrivateModifier
    {
        
        void Show()
        {
            //GetValue(); //Cannot Acess value here
        }
    }

    class PrivateProtected
    {
        private protected int value;
        public void setValue(int v)
        {
            value = v;
        }
        public int getValue()
        {
            return value;
        }
    }

    class ExtendPrivateProtected : PrivateProtected
    {
        public void showValue()
        {           
            Console.WriteLine("In private protected Value = " + value); // value is accesible 
        }
    }



}
