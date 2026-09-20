using System;
using System.Collections.Generic;

class Bank
{
    public int Bal { get; set; }
    public List<string> history = new List<string>();
    public Bank (int bal)
    {
        Bal = bal;
    }

    public void Menu()
    {
        Console.WriteLine("1. Показать баланс\n2. Пополнить счёт\n3. Снять деньги\n" +
            "4. Показать историю операций\n5. Выйти");
    }

    public void PrintBalance(int balance)
    {
        Console.WriteLine($"На вашем балансе {balance}₽");
    }
    public void PrintBalance(int balance, string currnecy)
    {
        Console.WriteLine($"На вашем балансе {balance} {currnecy}");
    }

    public void AddMoney(int amount)
    {
        if (amount < 0) Console.WriteLine("Ошибка ввода: неверный ввод");
        else
        {
            Bal += amount;
            Console.WriteLine("Операция успешно совершена");
        }
        history.Add($"Пополнение счета на {amount}");
    }
    public void OutMoney(int amount)
    {
        if (amount < 0 || amount > Bal) Console.WriteLine("Ошибка ввода: неверный ввод");
        else
        {
            Bal -= amount;
            Console.WriteLine("Операция успешно совершена");
        }
        history.Add($"Снятие с счета {amount} денег");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Здравствуйте! Введите свой начальный баланс: ");
        int balance = Convert.ToInt32(Console.ReadLine());

        Bank user = new Bank(balance);
        
        int choice;
        do
        {
            user.Menu();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    user.PrintBalance(balance);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write("Введите нужную сумму денег: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    user.AddMoney(amount);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Write("Введите нужную сумму денег: ");
                    int money = Convert.ToInt32(Console.ReadLine());
                    user.OutMoney(money);
                    Console.WriteLine();
                    break;
                case 4:
                    for (int i = 0; i < user.history.Count; i++) {
                        Console.WriteLine(user.history[i]);
                    }
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Вы уверены, что хотите выйти? Введите 0, если уверены");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    Console.WriteLine();
                    break;
            }
        }
        while (choice != 0);
    }
}