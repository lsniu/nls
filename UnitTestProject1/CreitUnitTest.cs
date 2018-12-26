using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CreitUnitTest
    {
        //[TestMethod]
        public void TestCreitAccount_with_Deposit100_and_draw100()
        {
            Account creitAccount = CreitAccount.OpenAccount();
            creitAccount.Deposit(100);
            creitAccount.Withdraw(100);
            Assert.AreEqual(0, creitAccount.Balance);
        }
    }
}
