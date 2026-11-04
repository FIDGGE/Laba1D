using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Mage illidan = new Mage("Иллидан Ярость Бури");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{illidan.GetInfo()}\n");

      Console.WriteLine($"{lancelot.Name} атакует {illidan.Name}!");

      beforeHP = illidan.HP;
      lancelot.Hit(illidan);
      damage = beforeHP - illidan.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(illidan.GetInfo());

      Console.WriteLine();

      // =================================//
      // ЭТАП 2: Использование расходников//
      // =================================//
      Console.WriteLine("=== ПРИМЕНЕНИЕ РАСХОДНИКОВ ===");

      // 1. Используем зелье маны
      ManaPotion manaPotion = new ManaPotion(30);
      Console.WriteLine($"{illidan.Name} выпивает зелье маны (+{manaPotion.Value} MP)...");
      illidan += manaPotion;
      Console.WriteLine(illidan.GetInfo());
      Console.WriteLine();

      // 2. Использование свитка хаоса (безумный расходник)
      ScrollOfChaos chaosScroll = new ScrollOfChaos(25);
      Console.WriteLine($"{illidan.Name} читает запретный Свиток Хаоса!");
      illidan += chaosScroll;
      Console.WriteLine(illidan.GetInfo());

      Console.ReadKey();
    }
  }
}
