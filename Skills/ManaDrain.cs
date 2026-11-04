using System;

namespace BoringRPG
{
  internal class ManaDrain : Skill
  {
    public ManaDrain()
    {
      Name = "Mana Drain";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      Random rnd = new Random();
      int stolenAmount = rnd.Next(0, 51);

      target.MP -= stolenAmount;
      caster.MP += stolenAmount;
    }
  }
}