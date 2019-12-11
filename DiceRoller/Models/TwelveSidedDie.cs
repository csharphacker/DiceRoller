using System;

namespace DiceRoller.Models
{
    public class TwelveSidedDie : IDie
    {
        public TwelveSidedDie()
        {
            NumberOfSides = 12;
        }

        public int NumberOfSides { get; private set; }
    }
}
