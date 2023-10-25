using System;
using System.IO;

namespace dz2110
{

    public enum AccountType
    {
        Checking,
        Savings
    }

    public class BankAccount
    {
        private static int accountCounter = 0;

        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public AccountType Type { get; private set; }

        public BankAccount(AccountType type)
        {
            accountCounter++;
            AccountNumber = accountCounter;
            Type = type;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Положено {amount} на счет {AccountNumber}");
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Снято {amount} со счета {AccountNumber}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств на счете {AccountNumber}. Невозможно снять {amount}");
            }
        }

        public void DepositFromUser()
        {
            Console.Write($"Введите сумму для внесения на счет {AccountNumber}: ");
            decimal depositAmount;
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                Console.Write($"Введите сумму для внесения на счет {AccountNumber}: ");
            }
            Deposit(depositAmount);
        }

        public void Transfer(BankAccount destinationAccount, decimal amount)
        {
            if (Balance >= amount)
            {
                Withdraw(amount);
                destinationAccount.Deposit(amount);
                Console.WriteLine($"Переведено {amount} со счета {AccountNumber} на счет {destinationAccount.AccountNumber}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств на счете {AccountNumber}. Невозможно перевести {amount}");
            }
        }
    }
    public static class Extensions
    {
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    public static class Extensions1
    {
        public static bool ImplementsIFormattable(this object obj)
        {
            return obj is IFormattable;
        }
    }


    public class Example
    {
        //Упражнение 8.1
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(AccountType.Checking);
            BankAccount account2 = new BankAccount(AccountType.Savings);
            account1.Deposit(1000);
            Console.Write("Введите сумму для снятия со счета 1: ");
            decimal withdrawalAmount1;
            while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount1))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                Console.Write("Введите сумму для снятия со счета 1: ");
            }
            account1.Withdraw(withdrawalAmount1);

            account2.Deposit(2000);
            Console.Write("Введите сумму для снятия со счета 2: ");
            decimal withdrawalAmount2;
            while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount2))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                Console.Write("Введите сумму для снятия со счета 2: ");
            }
            account2.Withdraw(withdrawalAmount2);

            account1.DepositFromUser();
            account2.DepositFromUser();

            Console.Write("Введите сумму для перевода со счета 1 на счет 2: ");
            decimal transferAmount;
            while (!decimal.TryParse(Console.ReadLine(), out transferAmount))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                Console.Write("Введите сумму для перевода со счета 1 на счет 2: ");
            }
            account1.Transfer(account2, transferAmount);

            Console.ReadKey();



            // Упражнение 8.2
            Console.WriteLine("Введите строку:");
            string inputStr = Console.ReadLine();
            string reversedStr = inputStr.Reverse();
            Console.WriteLine("Перевернутая строка: " + reversedStr);

            // Упражнение 8.3
            Console.WriteLine("Введите имя файла:");
            string fileName = $"../../{Console.ReadLine()}";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файла не существует.");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
                Environment.Exit(0);


            }
            else
            {

                string fileContent = File.ReadAllText(fileName);
                string upperCaseContent = fileContent.ToUpper();
                File.WriteAllText("../../output.txt", upperCaseContent);
                Console.WriteLine("Содержимое файла записано в выходной файл.");
            }
            //Упражнение 8.4
            int number = 10;
            string str = "Hello";

            Console.WriteLine("number implements IFormattable: " + number.ImplementsIFormattable());
            Console.WriteLine("str implements IFormattable: " + str.ImplementsIFormattable());
            Console.ReadKey();
        }
    }

}





