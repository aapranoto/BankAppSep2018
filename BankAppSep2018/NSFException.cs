using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppSep2018
{
    class NSFException : Exception
    {
        public NSFException() : base ("Not sufficient fund!")
        {

        }
        public NSFException(string message) : base(message)
        {
        }
    }

}
