using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BankingTest
    {
        //[TestMethod]
        public void TestDebitAccount_with_Deposit100_and_draw100()
        {
            Account debitAccount = DebitAccount.OpenAccount();
            debitAccount.Deposit(100);
            debitAccount.Withdraw(100);
            Assert.AreEqual(0,debitAccount.Balance);
        }

        //[TestMethod]
        public void TestDebitAccount_with_Deposit100_and_draw_200()
        {
            Account debitAccount = DebitAccount.OpenAccount();
            debitAccount.Deposit(100);
            try
            {
                debitAccount.Withdraw(200);
            }
            catch (InsufficientFundsException)
            {
                Assert.Fail();
                //Assert.AreEqual(ex, ex);
            }
        }
    }
}
