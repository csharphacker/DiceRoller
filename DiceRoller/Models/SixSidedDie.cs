using System;

namespace DiceRoller.Models
{
    public class SixSidedDie : IDie
    {
        public SixSidedDie()
        {
            NumberOfSides = 6;
        }

        public int NumberOfSides { get; private set; }
    }
}
