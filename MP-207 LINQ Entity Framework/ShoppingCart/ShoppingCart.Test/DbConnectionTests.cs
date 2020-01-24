using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.DataAcess;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingCart.Test
{
    [TestClass()]
    public class DbConnectionTests
    {
        IDbConnection db = new DbConnection();
        [TestMethod()]
        public void VerifyCredentialTest()
        {
            
            //Arrange
            Customer c = new Customer
            {
                UserName = "Priyal",
                Password = "pr"
            };
            //Act
            var d = db.DummySaveCredential(c);
            //Assert
            Assert.AreEqual(1,d);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var d = db.GetProduct();
            Assert.IsTrue(d.Count>0,"List of product from database");
        }
    }
}