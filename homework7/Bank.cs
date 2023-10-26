using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7

{
    enum BankType
    {
        Сберегательный,
        Зарплатный
    }
    internal class Bank
    {
        private static uint id_account = 1;
        private uint id;
        private double balance;
        private BankType type;

        public Bank(BankType type)
        {
            id_account++;
            id = id_account;
            balance = 0.0;
            this.type = type;
        }
        public Bank(BankType type, double balance)
        {
            id_account++;
            id = id_account;
            this.type = type;
            this.balance = balance;

        }
        public void DepositMoney(double money)
        {
            if (money > 0)
            {
                balance += money;
                Console.WriteLine($"Счёт пополнен на {money} рублей, текущий баланс {balance}\n");
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной\n");
            }
        }
        public void WithdrawMoney(double money)
        {
            if (money <= balance)
            {
                balance -= money;
                Console.WriteLine($"Со счёта снято {money} рублей, текущий баланс {balance}");
            }
            else
            {
                Console.WriteLine("На счёте недостаточно средств\n");
            }
            
        }
        public void Balance()
        {
            Console.WriteLine($"Текущий баланс {balance}\n");
        }
        public void Print()
        {
            Console.WriteLine($"Номер вашего счёта {id}, Тип {type}, Ваш баланс{balance}");
        }
        public void Transfer(Bank account1, double money, Bank account2)
        {
            {
                account1.balance -= money;
                account2.balance += money;
                Console.WriteLine($"Вы перевели {money} рублей на счет {account2.id}, ваш баланс {account1.balance}");
            }
        }

    }

}
