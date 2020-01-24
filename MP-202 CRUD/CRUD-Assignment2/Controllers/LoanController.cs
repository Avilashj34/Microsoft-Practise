using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CRUD_Assignment2.DbModel;
using CRUD_Assignment2.Models;

namespace CRUD_Assignment2.Controllers
{
    public class LoanController : ApiController
    {
        [ResponseType(typeof(Loan_Account))]
        public async Task<IHttpActionResult> PostLoanData(Loan_Account loan)
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var task = Task.Run(() => Db.Saving_Account.Where(s => s.CustomerId == loan.CustomerId).FirstOrDefault());
                var id = await task;
                if (id != null)
                {
                    Db.Loan_Account.Add(loan);
                    Db.SaveChanges();
                    return Ok("Data Added");
                }
                else
                {
                    return BadRequest("CustomerId Not Exist Loan cannot be initiated");
                }
            }
        }


        [ResponseType(typeof(Loan_Account))]
        public IHttpActionResult Get()
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Bad Request");
                }
                var loan = Db.Loan_Account.Select(l => new Loan()
                {
                    CustomerId =(int) l.CustomerId,
                    Loan_AccountNo = l.Loan_AccountNo,
                    LoanAmount=(int)l.LoanAmount,
                    Loan_Int_Type = l.Loan_Int_Type,
                    Loan_Term = (int)l.Loan_Term
                }).ToList();
                return Ok(loan);
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Loan_Account))]
        public async Task<IHttpActionResult> Delete(int CustomerId)
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var loan = Db.Loan_Account.FirstOrDefault(l => l.CustomerId == CustomerId);
                    if (loan == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Db.Loan_Account.Remove(loan);
                        await Db.SaveChangesAsync();
                        return Ok("Deleted Loan Account ");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Exception occured " + ex);
                }
            }
        }

        [HttpPut]
        [Route("api/loanput/{customerId}")]
        [ResponseType(typeof(Loan_Account))]
        public async Task<IHttpActionResult> Put([FromUri]int customerId,[FromBody]Loan_Account loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }
            using (BankDbEntities Db = new BankDbEntities())
            {
                var existingloan = Db.Loan_Account.FirstOrDefault<Loan_Account>(l => l.CustomerId == customerId);
                if(existingloan != null)
                {
                    existingloan.LoanAmount = loan.LoanAmount;
                    existingloan.Loan_AccountNo = loan.Loan_AccountNo;
                    await Db.SaveChangesAsync();
                }
                else
                {
                    NotFound();
                }
            }
            return Ok();
        }
    }
}
