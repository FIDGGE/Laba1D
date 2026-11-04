using System;

namespace BoringRPG
{
  internal abstract class Skill
  {
    public string Name;
    public abstract void Use(Archetype caster, Archetype target);
  }
}