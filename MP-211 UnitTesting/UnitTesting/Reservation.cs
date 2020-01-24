using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTesting
{
    public class Reservation
    {
        public User MadeBy { get; set; }
        public bool Cancelled_By(User user)
        {
            if (user.IsAdmin)
                return true;
            if (MadeBy == user)
                return true;
            return false;
        }

    }
    public class User
    {
        public bool IsAdmin { get; set; }
    }
}