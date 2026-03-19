using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Приватный конструктор класса
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Публичный конструктор банковского счета
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="balance"></param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получает имя пользователя
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получает текущий баланс пользователя
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списывает указанную сумму со счета
        /// </summary>
        /// <param name="amount">Сумма списания</param>
        /// <exception cref="ArgumentOutOfRangeException">Сумма снятия отрицательная или превышает баланс</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }


            m_balance -= amount;
        }

        /// <summary>
        /// Зачисляет указанную сумму на счет
        /// </summary>
        /// <param name="amount">Сумма зачисления</param>
        /// <exception cref="ArgumentOutOfRangeException">Сумма зачисления отрицательна</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            string insert = "";

            while (insert != "0")
            {
                Console.WriteLine("Select operation:\n" +
                    "1) Debit\n" +
                    "2) Credit");
                insert = Console.ReadLine();
                int sum;
                switch (insert)
                {
                    case "1":
                        Console.Write("Sum: ");
                        sum = int.Parse(Console.ReadLine());
                        ba.Debit(sum);
                        break;
                    case "2":
                        Console.Write("Sum: ");
                        sum = int.Parse(Console.ReadLine());
                        ba.Credit(sum);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                Console.WriteLine("Current balance is ${0}", ba.Balance);
            }
        }
    }
}
