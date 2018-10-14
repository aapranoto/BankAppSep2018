using System;

namespace BankAppSep2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("***************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4. Print all accounts");
            Console.Write("Please select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    return;
                case "1":
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                    for(var i = 0; i < accountTypes.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{accountTypes[i]}");
                    }
                    Console.Write("Select an account type: ");
                    var accountTypeOption = Console.ReadLine();
                    break;
                    

                default:
                    break;
            }
        }
    }
}