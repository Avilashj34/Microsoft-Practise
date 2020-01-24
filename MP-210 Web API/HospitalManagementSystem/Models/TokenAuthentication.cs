using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class TokenAuthentication : IDisposable
    {
        private readonly Entities Dbcontext = new Entities();

        public Account ValidateUser(string username, string password)
        {
            return Dbcontext.Accounts.FirstOrDefault(a => a.Email.Equals(username, StringComparison.OrdinalIgnoreCase) && a.Password == password);
        }
        public void Dispose()
        {
            Dbcontext.Dispose();
        }
    }
}