using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppSep2018
{
    enum TypeOfAccount
    {
        Savings,
        Checking,
        CD,
        Loan
    }
    class Account
    {
        
        private static int lastAccountNumber = 0;

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int AccountNumber { get; }
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; }
        #endregion
        
        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
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

        public void Withdrawal(decimal amount)
        {
            Balance -= amount;
        }
        #endregion

    }
}
