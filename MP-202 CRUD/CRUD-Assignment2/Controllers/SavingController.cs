using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CRUD_Assignment2.Models;
using CRUD_Assignment2.DbModel;

namespace CRUD_Assignment2.Controllers
{
    public class SavingController : ApiController
    {
        public IHttpActionResult GetSavingData()
        {
            if (ModelState.IsValid)
            {
                using (BankDbEntities Db = new BankDbEntities())
                {
                    /*var saving = Db.Saving_Account.Select(s => new Saving()
                    {
                        AccountNo = s.AccountNo,
                        Name = s.FirstName +" "+ s.LastName,
                        EmailId = s.EmailId,
                        PhoneNo = s.PhoneNo,
                        CurrentBalance = s.CurrentBalance
                    }).ToList();*/
                    /*Using Anonymous*/
                    var saving = Db.Saving_Account.Select(s => new
                    {
                        s.CustomerId,
                        s.AccountNo,
                        Name = s.FirstName + " " + s.LastName,
                        s.EmailId,
                        s.PhoneNo,
                        s.BranchCode,
                        s.CurrentBalance
                    }).ToList();
                    if (saving.Count == 0)
                    {
                        return Ok("No Saving Account");
                    }
                    return Ok(saving);
                }
            }
            else
            {
                return BadRequest("Model is not valid");
            }
        }

        [HttpGet]
        [Route("api/getparticulardata/{customerId}")]
        public async Task<HttpResponseMessage> GetParticularCustomerDataAsync(int customerId)
        {
            using (BankDbEntities Db = new BankDbEntities())
            {
                try
                {
                    var task = Task.Run(() => Db.Saving_Account.Where(s => s.CustomerId == customerId).Select(s => new
                    {
                        s.AccountNo,
                        s.CustomerId,
                        Name = s.FirstName + " " + s.LastName,
                        s.BranchCode,
                        s.PhoneNo,
                        s.CurrentBalance
                    }).FirstOrDefault());
                    var x = await task;
                    //Saving_Account x = Db.Saving_Account.Where(s => s.CustomerId == customerId).FirstOrDefault();
                    if (x == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "CustomerId " + customerId + " not found");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, x);
                    }
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception Occured in executing GetParticularCustomerData " + e);
                }
            }
        }
        public async Task<IHttpActionResult> PostSavingData([FromBody]Saving_Account saving)
        {
            if (ModelState.IsValid)
            {
                using (BankDbEntities Db = new BankDbEntities())
                {

                    Db.Saving_Account.Add(saving);
                    var x = await Db.SaveChangesAsync();
                    return Ok("Added account " + x);
                }
            }
            else
            {
                return BadRequest("Model is not valid");
            }
        }

        [HttpPut]
        [Route("api/savingput/{customerId}")]
        public IHttpActionResult Put([FromUri]int customerId, [FromBody]Saving_Account saving)
        {
            if (ModelState.IsValid)
            {
                using (BankDbEntities db = new BankDbEntities())
                {
                    var id = db.Saving_Account.FirstOrDefault(s => s.CustomerId == customerId);
                    if(id == null)
                    {
                       return NotFound();
                    }
                    else
                    {
                        id.AccountNo = saving.AccountNo;
                        id.BranchCode = saving.BranchCode;
                        id.CurrentBalance = saving.CurrentBalance;
                        id.EmailId = saving.EmailId;
                        id.FirstName = saving.FirstName;
                        id.LastName = saving.LastName;
                        id.PhoneNo = saving.PhoneNo;
                        db.SaveChanges();
                        return Ok("Sucessfully Altered");
                    }
                }
            }
            else
            {
                return BadRequest("Not a valid Model");
            }
        }

        [HttpDelete]
        [Route("api/deletesaving/{customerId}")]
        [ResponseType(typeof(Saving_Account))]
        public IHttpActionResult Delete(int customerId)
        {
            if (ModelState.IsValid)
            {
                using (BankDbEntities Db = new BankDbEntities())
                {
                    var id = Db.Saving_Account.Where(s => s.CustomerId == customerId).FirstOrDefault();
                    if (id == null)
                    {
                        return BadRequest("CustomerId with " + customerId + " not present");
                    }
                    else
                    {

                        var loan = Db.Loan_Account.FirstOrDefault(l => l.CustomerId == customerId);
                        if (loan != null)
                        {
                            Db.Loan_Account.Remove(loan);
                            Db.Saving_Account.Remove(id);
                            Db.SaveChanges();
                            return Ok("Deleted Account Of " + id.FirstName + " " + id.LastName);
                        }
                        else
                        {
                            return BadRequest("No loan with this customerId " + customerId);
                        }

                    }
                }
            }
            else
            {
                return BadRequest("Model is not valid");
            }
        }
    }
}
