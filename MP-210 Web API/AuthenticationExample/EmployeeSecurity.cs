using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationExample
{
    public class EmployeeSecurity
    {
        public static bool Login(String username, String password)
        {
            using (masterEntities db=new masterEntities())
            {
                return db.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                        user.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}