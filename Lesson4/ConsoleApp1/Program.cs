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

        List<Character> chars = new List<Character>();

        public Character(string name, int hp, int power)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            count++;
        }

        public virtual int Attack(Character target)
        {
            Console.WriteLine($"{target.name} атаковали!");
            return TakeDamage(power);
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
            if (IsAlive(hp - damage)) return hp;
            else {
                Console.WriteLine($"{name} умер :(");
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

        public override int Attack(Character target)
        {
            Console.WriteLine($"{Name} атаковал противника!");
            return target.TakeDamage(Power);
        }
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power) : base(name, hp, power) { }
        public override int Attack(Character target)
        {
            Console.WriteLine($"{Name} атаковал Вас!");
            return target.TakeDamage(Power);
        }
    }
}
