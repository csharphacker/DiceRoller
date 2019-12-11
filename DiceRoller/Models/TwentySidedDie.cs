using System;

namespace DiceRoller.Models
{
    public class TwentySidedDie : IDie
    {
        public TwentySidedDie()
        {
            NumberOfSides = 20;
        }

        public int NumberOfSides { get; private set; }
    }
}
