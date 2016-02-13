using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Match = BoxingParadiseBackend.Models.Match;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class MatchServiceTests
    {
        private Mock<IMatchRepository> m_MatchRepositoryMock;
        private IMatchService m_MatchService;

        [Test]
        public void GetByIdShouldCallRepository()
        {
            const int userId = 42;
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchRepositoryMock.Setup(x => x.GetById(userId)).Returns(new Match());
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.GetMatchById(userId);

            m_MatchRepositoryMock.Verify(x => x.GetById(userId), Times.Once);
        }

        [Test]
        public void SaveUserShouldCallRepository()
        {
            MatchDto userDto = new MatchDto();
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.SaveMatch(userDto);

            m_MatchRepositoryMock.Verify(x => x.Persist(It.IsAny<Match>()), Times.Once);
        }

        [Test]
        public void DeleteUserShouldCallRepository()
        {
            const int userId = 42;
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.DeleteMatchById(userId);

            m_MatchRepositoryMock.Verify(x => x.DeleteById(userId), Times.Once);
        }
    }
}