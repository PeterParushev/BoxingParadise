using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class BetServiceTests
    {
        private Mock<IBetRepository> m_BetRepositoryMock;
        private IBetService m_BetService;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Mapper.CreateMap<Bet, BetDto>();
            Mapper.CreateMap<BetDto, Bet>();
        }

        [Test]
        public void GetBetsByUserIdShouldCallRepository()
        {
            const int userId = 1;
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetRepositoryMock.Setup(x => x.GetBetsByUserId(userId)).Returns(new Task<IList<Bet>>(() => new List<Bet>()));
            m_BetService = new BetService(m_BetRepositoryMock.Object);

            m_BetService.GetBetsByUserId(userId);

            m_BetRepositoryMock.Verify(x => x.GetBetsByUserId(userId), Times.Once);
        }

        [Test]
        public async Task PlaceBetShouldCallRepository()
        {
            BetDto bet = new BetDto();
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetService = new BetService(m_BetRepositoryMock.Object);

            await m_BetService.CreateBet(bet);

            m_BetRepositoryMock.Verify(x => x.Persist(It.IsAny<Bet>()), Times.Once);
        }

        [Test]
        public void CancelBetShouldCallRepository()
        {
            const int betId = 1;
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetService = new BetService(m_BetRepositoryMock.Object);

            m_BetService.DeleteBet(betId);

            m_BetRepositoryMock.Verify(x => x.CancelBet(betId), Times.Once);
        }
    }
}