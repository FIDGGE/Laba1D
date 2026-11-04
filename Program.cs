using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      // Создаем Лучника (Сильвана Ветрокрылая) и Мага
      Archer silvan = new Archer("Сильвана Ветрокрылая");
      Mage illidan = new Mage("Иллидан Ярость Бури");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{silvan.GetInfo()}\n" +
                        $"{illidan.GetInfo()}\n");

      Console.WriteLine($"{silvan.Name} атакует {illidan.Name}!");

      beforeHP = illidan.HP;
      silvan.Hit(illidan);
      damage = beforeHP - illidan.HP;

      critText = silvan.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(silvan.GetInfo());
      Console.WriteLine(illidan.GetInfo());

      Console.WriteLine();

      // ================================= //
      // ЭТАП 2: Использование расходников //
      // ================================= //
      Console.WriteLine("=== ПРИМЕНЕНИЕ РАСХОДНИКОВ ===");
      Console.WriteLine();

      // 1. Используем зелье маны
      ManaPotion manaPotion = new ManaPotion(30);
      Console.WriteLine($"{illidan.Name} выпивает зелье маны (+{manaPotion.Value} MP)...");
      illidan += manaPotion;
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine();

      // 2. Использование свитка хаоса (безумный расходник)
      ScrollOfChaos chaosScroll = new ScrollOfChaos(25);
      Console.WriteLine($"{illidan.Name} читает Свиток Хаоса!");
      illidan += chaosScroll;
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine();

      // ===================== //
      // ИСПОЛЬЗОВАНИЕ НАВЫКОВ //
      // ===================== //
      Console.WriteLine("=== ИСПОЛЬЗОВАНИЕ НАВЫКОВ ===");
      Console.WriteLine();

      Skill soulLink = new SoulLink();
      Skill manaDrain = new ManaDrain();
      Skill drama = new DramaAction();

      // каст соул линк
      Console.WriteLine("--- Применение способности: Soul Link ---");
      illidan.UseSkill(soulLink, silvan);
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine(silvan.GetInfo());
      Console.WriteLine();

      // каст мана дрейна
      Console.WriteLine("--- Применение способности: Mana Drain ---");
      illidan.UseSkill(manaDrain, silvan);
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine(silvan.GetInfo());
      Console.WriteLine();

      // каст драмы
      Console.WriteLine("--- Применение способности: Drama Action ---");
      silvan.UseSkill(drama, illidan);
      Console.WriteLine(silvan.GetInfo());
      Console.WriteLine(illidan.GetInfo());

      // ================================ //
      // ПРОВЕРКА СОСТОЯНИЯ ПОСЛЕ НАВЫКОВ //
      // ================================ //
      Console.WriteLine("\n=== СОСТОЯНИЕ ПОСЛЕ НАВЫКОВ ===\n");
      Console.WriteLine(silvan.GetInfo());
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine();

      // Проверка Сильваны
      if (silvan.IsAlive)
      {
        Console.WriteLine($"{silvan.Name} показывает свою решимость: Мёртвые заслуживают справедливости больше, чем живые");
      }
      else
      {
        Console.WriteLine($"{silvan.Name} падает на колено... сил больше нет.");
      }

      // Проверка Иллидана
      if (illidan.HP > 0)
      {
        Console.WriteLine($"{illidan.Name} смеется в лицо опасности: Иногда судьбу нужно поторопить!\n");
      }
      else
      {
        Console.WriteLine($"{illidan.Name} растворяется в пламени скверны...\n");

        Console.ReadKey();
      }
    }
  }
}

