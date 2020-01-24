using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Assignment2.DbModel;

namespace CRUD_Assignment2.Bll
{
    public class LoanAccountBll
    {


        public void SaveData(Loan_Account loan)
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                var s=Db.Saving_Account.Where(l => l.CustomerId == loan.CustomerId).FirstOrDefault();
                if (s != null)
                {
                    loan.CustomerId = s.CustomerId;
                    Db.Loan_Account.Add(loan);
                    Db.SaveChanges();   
                }
            }
        }


        public List<Loan_Account> GetData()
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                var loan = Db.Loan_Account.ToList();
                if(loan.Count == 0)
                {
                    return null;
                }
                else
                {
                    return loan;
                }
                /*
                 Select(l => new
                {
                    l.CustomerId,
                    l.Loan_AccountNo,
                    l.LoanAmount,
                    l.Loan_Term
                }).*/
            }
        }
    }
}
