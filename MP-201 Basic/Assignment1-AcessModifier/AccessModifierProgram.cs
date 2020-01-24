using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_AcessModifier
{
    internal class AccessModifierProgram
    {
        int data;
        public AccessModifierProgram()
        {
            data = 10;
        }
        public void GetData()
        {
            Console.WriteLine("In internal class "+data);
        }
        static void Main(string[] args)
        {
            AcessModifier accessModifier = new AcessModifier();
            accessModifier.SetData(25);
            accessModifier.Show();
            

            ExtendProtectedModifier protectedModifier = new ExtendProtectedModifier();
            protectedModifier.SetX(21);
            protectedModifier.GetX();
            protectedModifier.Show();

            AccessModifierProgram internalmodifier = new AccessModifierProgram();
            internalmodifier.GetData();

            ExtendPrivateProtected extendPrivateProtected = new ExtendPrivateProtected();
            extendPrivateProtected.setValue(25);
            extendPrivateProtected.showValue();

            Console.ReadKey();
        }
    }
}
