using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppSep2018
{
    public enum TypeOfAccount
    {
        Savings,
        Checking,
        CD,
        Loan
    }
    public class Account
    {
        
        
        #region Properties
        /// <summary>
        /// Account number for account
        /// </summary>
        public int AccountNumber { get; set; }
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion

        #region Constructor

        public Account()
        {
           CreatedDate = DateTime.Now;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new NSFException("Not sufficient fund!");
            }
            Balance -= amount;
        }
        #endregion

    }
}
