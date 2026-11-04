using System;

namespace BoringRPG
{
  internal abstract class ConsumableItem
  {
    public int Value;

    protected ConsumableItem(int value)
    {
      Value = value;
    }
  }
}