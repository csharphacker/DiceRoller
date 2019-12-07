using AutoMoq;
using DiceRoller.Models;
using DiceRoller.Services.Rolling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiceRoller.Test
{
    [TestClass]
    public class DieRollService_Should
    {
        [TestMethod]
        public void ReturnResultFromRandom()
        {
            var mocker = new AutoMoqer();

            mocker.GetMock<Random>()
                .Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5);

            var service = mocker.Create<RollDieService>();

            var die = new SixSidedDie();
            var result = service.Handle(new RollDieRequest { Die = die }, CancellationToken.None).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(die, result.Die);
            Assert.AreEqual(5, result.Value);
        }
    }
}
