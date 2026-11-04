using System;

namespace BoringRPG
{
  internal class SoulLink : Skill
  {
    public SoulLink()
    {
      Name = "Soul Link";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int totalHP = caster.HP + target.HP;
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;
      Console.WriteLine($"[НАВЫК] {caster.Name} и {target.Name} разделили здоровье поровну!");
    }
  }
}