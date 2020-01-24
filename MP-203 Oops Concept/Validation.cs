using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OopsConcept
{
    class Validation
    {
        public string validateString(string checkstring)
        {
            Regex r = new Regex("[A-Z][a-zA-Z]");
            if (r.IsMatch(checkstring))
            {
                return checkstring;
            }
            else
            {
                Console.WriteLine("Enter String Again");
                return validateString(Console.ReadLine());
                
            }
        }

        public string ValidateInteger(string checknumber)
        {
            Regex r = new Regex(@"\(?\d{10}$");
            if (r.IsMatch(checknumber))
            {
                return checknumber;
            }
            else
            {
                Console.WriteLine("Enter Integer Again");
                return ValidateInteger(Console.ReadLine());
            }
        }
    }
}
