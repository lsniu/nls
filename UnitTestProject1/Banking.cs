using System;
using System.Runtime.CompilerServices;

namespace UnitTestProject1
{
    /// <summary>
    /// 获取卡号接口
    /// </summary>
    public interface IAssessmentService
    {
        long GetCredit(String socialSecurityNumber);
    }

    public class SesameCreditAssessmentService : IAssessmentService
    {

        public long GetCredit(String socialSecurityNumber)
        {
            int value = (new Random().Next(100,3333) * 10000);          
            System.Threading.Thread.Sleep(value);

            if (new Random().Next() > 0.66)
            {
                throw new TimeoutException();
            }
            return value;
        }
    }

    public class Account
    {
        private static IAssessmentService service = new SesameCreditAssessmentService();

        public static IAssessmentService AssessmentService
        {
            get { return service; }
        }
        //是否是借记卡
        private readonly bool isDebit;

        /// <summary>
        /// 余额
        /// </summary>
        public long Balance
        {
            get;
            private set;
        }

        /// <summary>
        /// 银行卡账号
        /// </summary>
        /// <param name="isDebit"></param>
        protected Account(bool isDebit)
        {
            this.isDebit = isDebit;
        }


        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount">金额</param>
        public void Deposit(long amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Withdraw(long amount)
        {
            Deposit(-amount);
        }
    }

    /// <summary>
    /// 借记卡
    /// </summary>
    public class DebitAccount:Account
    {
        public DebitAccount():base(true)
        {
            
        }

        public static Account OpenAccount()
        {
            return new DebitAccount();
        }

        public override void Withdraw(long amount)
        {
            bool insufficientFunds = this.Balance < amount;
            if (insufficientFunds)
            {
                throw new InsufficientFundsException();
            }
            base.Withdraw(amount);
        }
    }
    /// <summary>
    /// 信用卡
    /// </summary>
    public class CreitAccount:Account
    {
        public CreitAccount():base(false)
        {
            
        }
        public static Account OpenAccount()
        {
            return new CreitAccount();
        }

        public override void Withdraw(long amount)
        {
            bool insufficientFunds =AssessmentService.GetCredit("455")+this.Balance < amount;
            if (insufficientFunds)
            {
                throw new InsufficientFundsException();
            }
            base.Withdraw(amount);
        }
    }

    /// <summary>
    /// 余额不足 引发的异常
    /// </summary>
    public class InsufficientFundsException : Exception
    {
    }
}