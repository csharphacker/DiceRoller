using DiceRoller.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiceRoller.Services.Rolling
{
    public class RollDieService : IRequestHandler<RollDieRequest, ResultOfRoll>
    {
        private readonly ILogger<RollDieService> logger;
        private readonly Random random;

        public RollDieService(ILogger<RollDieService> logger, Random random)
        {
            this.logger = logger;
            this.random = random;
        }

        public Task<ResultOfRoll> Handle(RollDieRequest request, CancellationToken cancellationToken)
        {
            logger.LogDebug($"Attempting to roll a {request.Die.NumberOfSides} sided die");

            ResultOfRoll result;

            try
            {
                result = new ResultOfRoll(request.Die, random.Next(1, request.Die.NumberOfSides));

                logger.LogDebug($"Completed rolling a {result.Die.NumberOfSides} sided die, resulting in a value of {result.Value}");
            }
            catch (Exception ex)
            {
                var message = $"There was an error rolling a {request.Die.NumberOfSides} side die.\n{ex.ToString()}";
                logger.LogError(ex, message);

                result = null;
            }

            return Task.FromResult(result);
        }
    }
}
