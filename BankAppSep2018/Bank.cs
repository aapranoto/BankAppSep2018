using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppSep2018
{
    static class Bank
    {
        /// <summary>
        /// Create an account with the bank
        /// </summary>
        /// <param name="emailAddress">Email Adress of the account</param>
        /// <param name="accountType">Type of Account</param>
        /// <param name="initialAmount">Initial deposit</param>
        /// <returns>Newly created account</returns>

        public static Account CreateAccount(string emailAddress, TypeOfAccount accountType= TypeOfAccount.Checking, decimal initialAmount=0)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            if (initialAmount > 0)
            {
                account.Deposit(initialAmount);
            }
            return account;
        }
    }
}
