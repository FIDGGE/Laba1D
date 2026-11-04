using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class Mage : Archetype, ICanUseSkill
  {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    // Конструктор со статами мага
    public Mage(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 60, 100, 0, 35, 0.05)
    {
    }

    // Конструктор с именем
    public Mage(string name) : base(name, 60, 100, 0, 35, 0.05)
    {
    }

    // Перегрузка оператора '-' (уменьшает HP на указанное число и возвращает мага)
    public static Mage operator -(Mage mage, int dmg)
    {
      mage.HP -= dmg;
      return mage;
    }

    // Перегрузка оператора '+' (увеличивает HP на указанное число и возвращает мага)
    public static Mage operator +(Mage mage, int value)
    {
      mage.HP += value;
      return mage;
    }

    public static bool operator true(Mage mage)
    {
      return mage.HP > 0;
    }

    public static bool operator false(Mage mage)
    {
      return mage.HP <= 0;
    }

    //зелье маны
    public static Mage operator +(Mage mage, ManaPotion potion)
    {
      mage.MP += potion.Value;
      return mage;
    }

    //зелье здоровья
    public static Mage operator +(Mage mage, HealthPotion potion)
    {
      mage.HP += potion.Value;
      return mage;
    }

    //зелье урона
    public static Mage operator +(Mage mage, DamagePotion potion)
    {
      mage.Damage += potion.Value;
      return mage;
    }

    //свиток хаоса
    public static Mage operator +(Mage mage, ScrollOfChaos scroll)
    {
      Random rnd = new Random();
      mage.Damage += rnd.Next(1, scroll.Value);
      mage.MP += rnd.Next(10, 40);
      return mage;
    }

    // Метод Hit: наносит урон цели с особенностью мага
    public override void Hit(Archetype target)
    {
      int damage = Damage;

      // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit)
      {
        damage *= 2; // Крит выдает урон х2
      }

      // Если маны нет то урон не проходит
      if (MP >= 10)
      {
        target.HP -= damage; // Оператор "-" для снижения хп
        MP -= 10;
      }
      else
      {
        // Урон не наносится, так как не хватает маны
        target.HP -= 0;
      }
    }

    // Метод GetInfo для вывода информации о герое
    public override string GetInfo()
    {
      return $"{Name} (Mage): HP {HP}, MP {MP}, Damage {Damage}, Шанс крита {CritChance * 100}%";
    }

    // метод интерфейса
    public void UseSkill(Skill skill, Archetype target)
    {
      Console.WriteLine($"{Name} применяет навык: {skill.Name} на цель {target.Name}!");
      skill.Use(this, target);
    }
  }
}
