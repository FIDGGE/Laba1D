using System;

namespace BoringRPG
{
  internal interface ICanUseSkill
  {
    void UseSkill(Skill skill, Archetype target);
  }
}