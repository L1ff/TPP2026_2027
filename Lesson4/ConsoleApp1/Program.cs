using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Character
    {
        private string name;
        private int hp;
        private int power;
        private static int count = 0;

        public string Name => name;
        public int Hp => hp;
        public int Power => power;

        public static List<Character> chars = new List<Character>();

        public Character(string name, int hp, int power)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            count++;
        }

        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{target.name} атаковали!");
            TakeDamage(power);
        }
        public void GetStatus() {
            Console.WriteLine($"Имя персонажа - {name}\nЗдоровье - {Hp}\nАтака - {Power}");
        }
        public static int HowMany() {
            return count;
        }
        public static bool IsValidStats(int hp, int power)
        {
            if (hp >= 0 && power >= 0) return true;
            else return false;
        }
        public int TakeDamage(int damage)
        {
            if (IsAlive(hp - damage))
            {
                hp -= damage;
                return hp;
            }
            else
            {
                hp = 0;
                return 0;
            }
        }
        public bool IsAlive(int hp)
        {
            if (hp > 0) return true;
            else return false;
        }
        public override string ToString()
        {
            return $"Игрок({name}, Hp - {Hp}, damage - {Power})";
        }
    }

    class Player : Character
    {
        public Player(string name, int hp, int power) : base(name, hp, power) { }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} атаковал противника!");
            target.TakeDamage(Power);
        }
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power) : base(name, hp, power) { }
        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} атаковал Вас!");
            target.TakeDamage(Power);
        }
    }
    class Program
    {
        static void Main()
        {
            Player player = new Player("Игрок", 10, 3);
            Console.WriteLine($"Создан персонаж: {player.Name} (HP: {player.Hp}, Урон: {player.Power})");
            Character.chars.Add(player);

            Enemy enemy = new Enemy("Враг", 8, 2);
            Console.WriteLine($"Создан персонаж: {enemy.Name} (HP: {enemy.Hp}, Урон: {enemy.Power})");
            Character.chars.Add(enemy);

            Console.WriteLine("Бой начинается!");

            do
            {
                player.Attack(enemy);
                enemy.ToString();

                enemy.Attack(player);
                player.ToString();

            } while (player.Hp > 0 && enemy.Hp > 0);

            if (!enemy.IsAlive(enemy.Hp))
                Console.Write($"{enemy.Name} побежден!\n{player.Name} одержал победу!");
            else
                Console.Write($"{player.Name} побежден!\n{enemy.Name} одержал победу!");

        }
    }
}
