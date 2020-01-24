using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenAuthenticationAssinment1.Models
{
    public class UserMasterRepository : IDisposable
    {
        TokenDbEntities Context = new TokenDbEntities();

        public UserMaster Validate(string Un, string Up)
        {
            return Context.UserMasters.FirstOrDefault(user => user.UserName.Equals(Un, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword.Equals(Up));
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}