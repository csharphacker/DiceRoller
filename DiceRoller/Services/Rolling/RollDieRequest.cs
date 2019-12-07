using DiceRoller.Models;
using MediatR;

namespace DiceRoller.Services.Rolling
{
    public class RollDieRequest : IRequest<ResultOfRoll>
    {
        public IDie Die { get; set; }
    }
}
