using System;

namespace BoringRPG
{
  internal class DramaAction : Skill
  {
    public DramaAction()
    {
      Name = "Drama Action";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      Random random = new Random();
      int roll = random.Next(1, 101);

      if (roll <= 30)
      {
        string prefix = random.Next(0, 2) == 0 ? "Побеждённый" : "Легендарный";
        target.Name = $"{prefix} {target.Name}";
        Console.WriteLine($"[ДРАМА] {caster.Name} изменил имя цели! Теперь это '{target.Name}'.");
      }
      else if (roll <= 60)
      {
        string prefix = random.Next(0, 2) == 0 ? "Легендарный" : "Побеждённый";
        caster.Name = $"{prefix} {caster.Name}";
        Console.WriteLine($"[ДРАМА] {caster.Name} меняет свое имя на '{caster.Name}'!");
      }
      else
      {
        Console.WriteLine($"{caster.Name} дарит розу {target.Name}");
      }
    }
  }
}