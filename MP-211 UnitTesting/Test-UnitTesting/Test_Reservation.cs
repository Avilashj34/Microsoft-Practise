using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace Test_UnitTesting
{
    [TestClass]
    public class Test_Reservation
    {
        [TestMethod]
        public void CanceledBy_Admin_ReturnsTrue()
        {
            var reservation = new Reservation();
            var result = reservation.Cancelled_By(new User { IsAdmin = true });
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanceledBy_User_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy=user};
            var result = reservation.Cancelled_By(user);
            Assert.IsTrue(result, "User is invalid");
        }

        [TestMethod]
        public void CanceledBy_AnotherUser_ReturnsTrue()
        {
            var reservation = new Reservation();
            var result = reservation.Cancelled_By(new User());
            Assert.IsFalse(result);
        }

    }
}
