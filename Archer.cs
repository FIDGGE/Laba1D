using System;

namespace BoringRPG
{
  internal class Archer : Archetype, ICanUseSkill
  {
    private static Random random = new Random();
    public bool LastHitWasCrit;
    public bool IsAlive => HP > 0;

    // Конструкторы класса
    public Archer(string name, int hp, int mp, int ammo, int dmg, double crit)
      : base(name, 80, 30, 20, 20, 0.25)
    {
    }

    public Archer(string name)
      : base(name, 80, 30, 20, 20, 0.25)
    {
    }

    // Реализация интерфейса
    public void UseSkill(Skill skill, Archetype target)
    {
      Console.WriteLine($"{Name} применяет навык: {skill.Name} на цель {target.Name}!");
      skill.Use(this, target);
    }

    // Проверка операторов true / false
    public static bool operator true(Archer archer)
    {
      return archer.HP > 0;
    }

    public static bool operator false(Archer archer)
    {
      return archer.HP <= 0;
    }

    // Перегрузка операторов для урона и хила
    public static Archer operator +(Archer archer, int healing)
    {
      archer.HP += healing;
      return archer;
    }

    public static Archer operator -(Archer archer, int damage)
    {
      archer.HP = Math.Max(archer.HP - damage, 0);
      return archer;
    }

    // Зелье здоровья
    public static Archer operator +(Archer archer, HealthPotion potion)
    {
      archer.HP += potion.Value;
      return archer;
    }

    // Зелье маны
    public static Archer operator +(Archer archer, ManaPotion potion)
    {
      archer.MP += potion.Value;
      return archer;
    }

    // Зелье урона
    public static Archer operator +(Archer archer, DamagePotion potion)
    {
      archer.Damage += potion.Value;
      return archer;
    }

    // Свиток Хаоса
    public static Archer operator +(Archer archer, ScrollOfChaos scroll)
    {
      Random rnd = new Random();
      archer.Damage += rnd.Next(1, scroll.Value);
      archer.MP += rnd.Next(10, 40);
      return archer;
    }

    // Метод атаки Арчера
    public override void Hit(Archetype target)
    {
      if (Ammo > 0)
      {
        Ammo--;
        int damage = Damage;

        LastHitWasCrit = random.NextDouble() < CritChance;

        if (LastHitWasCrit)
        {
          damage *= 2;
        }

        target.HP -= damage;
      }
      else
      {
        Console.WriteLine($"{Name}: нет стрел (Ammo = 0)!");
      }
    }

    public override string GetInfo()
    {
      return $"{Name} (Archer): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Шанс крита {CritChance * 100}%";
    }
  }
}