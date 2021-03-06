﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAppSep2018
{
    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionType TypeofTransaction { get; set; }
        public String Description { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
