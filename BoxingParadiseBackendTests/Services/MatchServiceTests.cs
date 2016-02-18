//using AutoMapper;
//using BoxingParadiseBackend.DTOs;
//using BoxingParadiseBackend.Repositories;
//using BoxingParadiseBackend.Repositories.Interfaces;
//using BoxingParadiseBackend.Services;
//using BoxingParadiseBackend.Services.Interfaces;
//using BoxingParadiseBackend.Services.Mapping.Interface;
//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Match = BoxingParadiseBackend.Models.Match;

//namespace BoxingParadiseBackendTests.Services
//{
//    [TestFixture]
//    public class MatchServiceTests
//    {
//        private Mock<IMatchRepository> m_MatchRepositoryMock;
//        private Mock<IUserService> m_UserServiceMock;
//        private Mock<IMatchMapper> m_MatchMapperMock;
//        private IMatchService m_MatchService;

//        [OneTimeSetUp]
//        public void TestFixtureSetUp()
//        {
//            AutoMapperBootstrapper.Initialise();
//        }

//        [Test]
//        public void GetByIdShouldCallRepository()
//        {
//            const int userId = 42;
//            m_MatchRepositoryMock = new Mock<IMatchRepository>();
//            m_MatchRepositoryMock.Setup(x => x.GetById(userId)).Returns(new Task<Match>(() => new Match()));
//            m_UserServiceMock = new Mock<IUserService>();
//            m_MatchMapperMock = new Mock<IMatchMapper>();
//            m_MatchService = new MatchService(m_MatchRepositoryMock.Object, m_MatchMapperMock.Object, m_UserServiceMock.Object);

//            m_MatchService.GetMatchById(userId);

//            m_MatchRepositoryMock.Verify(x => x.GetById(userId), Times.Once);
//        }

//        [Test]
//        public async Task SaveUserShouldCallRepository()
//        {
//            MatchDto userDto = new MatchDto();
//            m_MatchRepositoryMock = new Mock<IMatchRepository>();
//            m_UserServiceMock = new Mock<IUserService>();
//            m_MatchMapperMock = new Mock<IMatchMapper>();
//            m_MatchService = new MatchService(m_MatchRepositoryMock.Object, m_MatchMapperMock.Object, m_UserServiceMock.Object);

//            await m_MatchService.SaveMatch(userDto).ConfigureAwait(false);

//            m_MatchRepositoryMock.Verify(x => x.Persist(It.IsAny<Match>()), Times.Once);
//        }

//        [Test]
//        public void DeleteUserShouldCallRepository()
//        {
//            const int userId = 42;
//            m_MatchRepositoryMock = new Mock<IMatchRepository>();
//            m_UserServiceMock = new Mock<IUserService>();
//            m_MatchMapperMock = new Mock<IMatchMapper>();
//            m_MatchService = new MatchService(m_MatchRepositoryMock.Object, m_MatchMapperMock.Object, m_UserServiceMock.Object);

//            m_MatchService.DeleteMatchById(userId);

//            m_MatchRepositoryMock.Verify(x => x.DeleteById(userId), Times.Once);
//        }

//        [Test]
//        public void GetMatchesShouldCallRepository()
//        {
//            const int count = 1;
//            const int skip = 42;
//            m_MatchRepositoryMock = new Mock<IMatchRepository>();
//            m_MatchRepositoryMock.Setup(x => x.GetMatches(count, skip)).Returns(new Task<IList<Match>>(() => new List<Match>()));
//            m_UserServiceMock = new Mock<IUserService>();
//            m_MatchMapperMock = new Mock<IMatchMapper>();
//            m_MatchService = new MatchService(m_MatchRepositoryMock.Object, m_MatchMapperMock.Object, m_UserServiceMock.Object);

//            m_MatchService.GetMatches(count, skip);

//            m_MatchRepositoryMock.Verify(x => x.GetMatches(count, skip), Times.Once);
//        }

//        [Test]
//        public void CancelAllBetsForAMatchShouldCallRepository()
//        {
//            const int matchId = 1;
//            m_MatchRepositoryMock = new Mock<IMatchRepository>();
//            m_UserServiceMock = new Mock<IUserService>();
//            m_MatchMapperMock = new Mock<IMatchMapper>();
//            m_MatchService = new MatchService(m_MatchRepositoryMock.Object, m_MatchMapperMock.Object, m_UserServiceMock.Object);

//            m_MatchService.Cancel(matchId);

//            m_MatchRepositoryMock.Verify(x => x.Cancel(matchId), Times.Once);
//        }
//    }
//}