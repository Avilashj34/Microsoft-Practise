using System;
using NUnit.Framework;
using UnitTesting;

namespace Test_UnitTesting
{
    /*
     https://codereview.stackexchange.com/questions/46172/refactoring-method-to-make-it-unit-testing-friendly  
     Refactoring for testability
     */
    [TestFixture]
    public class Test_Calculator{
        [TestCase]
        public void TestMethod1()
        {
            //Arrange
            int a = 10, b = 21;
            int excepted = 31;
            //Act
            int actual = CalculatorOperation.Add(a, b);
            //Assert

            Assert.AreEqual(actual, excepted);
        }

        [Test]
        [Theory] //Provide more description of test
        public void TestMethod2()
        {
            int a = 10, b = 11;
            int excepted = 11;

            int actual = CalculatorOperation.Add(a, b);

            Assert.AreNotEqual(excepted, actual);
        }
    }
}
