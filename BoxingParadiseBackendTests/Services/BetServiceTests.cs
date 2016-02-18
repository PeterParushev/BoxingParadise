using AutoMapper;
using BoxingParadiseBackend;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using BoxingParadiseBackend.Services.Mapping.Interface;
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
        private Mock<IBetMapper> m_BetMapperMock;
        private IBetService m_BetService;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            AutoMapperBootstrapper.Initialise();
        }

        [Test]
        public void GetBetsByUserIdShouldCallRepository()
        {
            const int userId = 1;
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetRepositoryMock.Setup(x => x.GetBetsByUserId(userId)).Returns(new Task<IList<Bet>>(() => new List<Bet>()));
            m_BetMapperMock = new Mock<IBetMapper>();
            m_BetService = new BetService(m_BetRepositoryMock.Object, m_BetMapperMock.Object);

            m_BetService.GetBetsByUserId(userId);

            m_BetRepositoryMock.Verify(x => x.GetBetsByUserId(userId), Times.Once);
        }

        [Test]
        public async Task PlaceBetShouldCallRepository()
        {
            BetDto bet = new BetDto();
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetMapperMock = new Mock<IBetMapper>();
            m_BetService = new BetService(m_BetRepositoryMock.Object, m_BetMapperMock.Object);

            await m_BetService.CreateBet(bet).ConfigureAwait(false);

            m_BetRepositoryMock.Verify(x => x.Persist(It.IsAny<Bet>()), Times.Once);
        }

        [Test]
        public void CancelBetShouldCallRepository()
        {
            const int betId = 1;
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_BetMapperMock = new Mock<IBetMapper>();
            m_BetService = new BetService(m_BetRepositoryMock.Object, m_BetMapperMock.Object);

            m_BetService.DeleteBet(betId);

            m_BetRepositoryMock.Verify(x => x.CancelBet(betId), Times.Once);
        }
    }
}