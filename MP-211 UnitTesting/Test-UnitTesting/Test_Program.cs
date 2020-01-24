using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UnitTesting;

namespace Test_UnitTesting
{
    [TestClass]
    public class Test_Program
    {
        public const string Excepted ="Sample Testcase";
        [TestMethod]
        public void TestSampleMethod()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main();
                var result = sw.ToString().Trim();
                Assert.AreEqual(result,Excepted);
            }
        }
    }
}
