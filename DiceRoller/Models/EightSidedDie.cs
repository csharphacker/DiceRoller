using System;

namespace DiceRoller.Models
{
    public class EightSidedDie : IDie
    {
        public EightSidedDie()
        {
            NumberOfSides = 8;
        }

        public int NumberOfSides { get; private set; }
    }
}
