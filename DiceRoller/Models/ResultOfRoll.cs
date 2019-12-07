using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    public class ResultOfRoll
    {
        public ResultOfRoll(IDie die, int value)
        {
            Die = die;
            Value = value;
        }

        public IDie Die { get; private set; }
        public int Value { get; private set; }
    }
}
