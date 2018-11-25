using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAppSep2018
{
    public static class Bank
    {
        private static BankModel db = new BankModel();

        /// <summary>
        /// Create an account with the bank
        /// </summary>
        /// <param name="emailAddress">Email Adress of the account</param>
        /// <param name="accountType">Type of Account</param>
        /// <param name="initialAmount">Initial deposit</param>
        /// <returns>Newly created account</returns>
        /// <exception cref="ArgumentNullException" />

        public static Account CreateAccount(string emailAddress, TypeOfAccount accountType= TypeOfAccount.Checking, decimal initialAmount=0)
        {
            if(string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress), "Email address is required!");
            }
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            if (initialAmount > 0)
            {
                account.Deposit(initialAmount);
            }
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return;
            }
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeofTransaction = TransactionType.Credit,
                Description = "Bank Deposit",
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);

            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return;
            }
            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeofTransaction = TransactionType.Debit,
                Description = "Bank Withdrawal",
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetTransactions(int accountNumber)
        {
            return db.Transactions.
                Where(t => t.AccountNumber == accountNumber).
                OrderByDescending(t => t.TransactionDate);
        }

        public static Account GetAccountDetails(int accountNumber)
        {
            return db.Accounts.SingleOrDefault(m => m.AccountNumber == accountNumber);
        }

        public static void EditAccount(Account updatedAccount)
        {
            var oldAccount = Bank.GetAccountDetails(updatedAccount.AccountNumber);
            oldAccount.EmailAddress = updatedAccount.EmailAddress;
            oldAccount.AccountType = updatedAccount.AccountType;
            db.Update(oldAccount);
            db.SaveChanges();
        }

        public static void DeleteAccount(int accountNumber)
        {
            var account = Bank.GetAccountDetails(accountNumber);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

        public static bool AccountExists(int id)
        {
            return db.Accounts.Any(e => e.AccountNumber == id);
        }
    }
}
