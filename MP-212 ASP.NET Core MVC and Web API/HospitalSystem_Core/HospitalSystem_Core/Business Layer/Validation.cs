using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem_Core.Business_Layer
{
    public static class Validation
    {
        public static bool CheckFullName(string Name) 
        {
            if(Name.Trim().Contains(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ModifyName(string name)
        {
            string[] s = name.Split(" ");
            string modifiedname = s[0].Substring(0, 1).ToUpper() + s[0].Substring(1)+ " " + s[1].Substring(0, 1).ToUpper() + s[1].Substring(1);
            return modifiedname;                
        }
    }
}
