using System;

namespace DiceRoller.Models
{
    public class TenSidedDie : IDie
    {
        public TenSidedDie()
        {
            NumberOfSides = 10;
        }

        public int NumberOfSides { get; private set; }
    }
}
