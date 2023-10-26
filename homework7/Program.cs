using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework7
{
    internal class Program
    {
        static void Exces()
        {
            BankType type = BankType.Сберегательный;
            Bank account1 = new Bank(type);
            Bank account2 = new Bank(type);


            account1.Print();
            Console.WriteLine("Команды:\nВнести - если хотите пополнить счёт\nСнять - если хотите снять деньги со счёта\n" +
                    "Баланс - если хотите посмотреть баланс\nПеревести - если вы хотите перевести деньги с одного счёта на другой\nВыход - если хотите выйти\n");
            string command;
            do
            {
                Console.WriteLine("Введите команду");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "внести":
                        Console.WriteLine("Введите сумму,которую хотите внести\n");
                        bool deposit_money = double.TryParse(Console.ReadLine(), out double dep_money);
                        if (!deposit_money)
                        {
                            do
                            {
                                Console.WriteLine("Вы ввели не число, повторите");
                                deposit_money = double.TryParse(Console.ReadLine(), out dep_money);
                            } while (!deposit_money);
                        }
                        account1.DepositMoney(dep_money);
                        break;
                    case "снять":
                        Console.WriteLine("Введите сумму,которую вы хотите снять : \n");
                        bool take_money_flag = double.TryParse(Console.ReadLine(), out double take_money);
                        if (!take_money_flag)
                        {
                            Console.WriteLine("Вы ввели не число");
                            do
                            {
                                take_money_flag = double.TryParse(Console.ReadLine(), out take_money);
                            } while (!take_money_flag);
                        }
                        account1.WithdrawMoney(take_money);
                        break;
                    case "баланс":
                        account1.Balance();
                        break;
                    case "перевести":
                        Console.WriteLine("Введите номер счёта пользователя:");
                        bool id_nums = uint.TryParse(Console.ReadLine(), out uint id);
                        if (!id_nums)
                        {
                            do
                            {
                                Console.WriteLine("Вы ввели не число");
                                id_nums = uint.TryParse(Console.ReadLine(), out id);
                            } while (!id_nums);
                        }
                        Console.WriteLine("Введите сумму, которую хотите перевести : \n");
                        bool money_nums = double.TryParse(Console.ReadLine(), out double money);
                        if (!money_nums)
                        {
                            do
                            {
                                Console.WriteLine("Вы не ввели число");
                                money_nums = double.TryParse(Console.ReadLine(), out money);
                            } while (!money_nums);
                        }
                        account1.Transfer(account1, money, account2);
                        break;

                    case "выход":
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверную комнаду\n");
                        break;
                }

            } while (!command.Equals("выход"));
        }
        static void Exces2()
        {
            Console.WriteLine("Задание 2\nВведите текст : ");
            string text = Console.ReadLine();
            Console.WriteLine($"Ваша строка: {ReverseString(text)}");
        }
        static string ReverseString(string text)
        {
            char[] teXt = text.ToCharArray();
            Array.Reverse(teXt);
            return new string(teXt);
        }



        static void Main(string[] args)
        {
            Exces();
            Exces2();
            Exces3();
            Exces4();
            Exces5();
            Console.ReadKey(true);
        }

        static void Exces3()
        {
            string output_file = "weather.txt";

            Console.Write("Введите название входного файла: ");
            string input_file = Console.ReadLine() + ".txt";

            if (File.Exists(input_file))
            {
                string text = File.ReadAllText(input_file).ToUpper();
                File.WriteAllText(output_file, text);
                Console.WriteLine($"Текст записан заглавными буквами в файл\n{output_file}\n");
            }
            else
            {
                Console.WriteLine($"Файл {input_file} не найден!");
            }

        }

        static void CheckIFormatable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattable_object = obj as IFormattable;
                if (formattable_object != null)
                {
                    Console.WriteLine("Обьект совмещается с данным типом\n");
                }
            }
            else
            {
                Console.WriteLine("Обьект не совмещается с данным типом\n");
            }
        }
            static void Exces4()
        {
            Console.WriteLine("Упражнение 4\n");

            object obj = "RowEpp";
            CheckIFormatable(obj);
        }

        static void ExceSSS()
        {
            Console.WriteLine("Домашнее задание 1\n");

            string input_file = "excesicone.txt";
            string output_file = "excesicto.txt";
            List<string> obj_Values = File.ReadAllLines(input_file).ToList();
            if (File.Exists(input_file))
            {
                foreach (var file_line in obj_Values)
                {
                    var splitFileLine = file_line.Split(new[] { "%" }, StringSplitOptions.None);

                    string giw = splitFileLine[0];
                    string woc = splitFileLine[1];
                    using (var str1 = new StreamWriter(output_file, true))
                    {
                        str1.WriteLine(giw);
                    }
                }
                Console.WriteLine("Ура, все работает!\n");
            }
            else
            {
                Console.WriteLine("Не работает(\n");
            }
            Console.ReadKey();
        }
    }
}

