using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Repositories;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Match = BoxingParadiseBackend.Models.Match;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class MatchServiceTests
    {
        private Mock<IMatchRepository> m_MatchRepositoryMock;
        private IMatchService m_MatchService;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            DatabaseContext context = new DatabaseContext();
            Mapper.CreateMap<Match, MatchDto>()
                .ForMember(x => x.FirstBoxerDto, x => x.MapFrom(y => y.BoxerOne))
                .ForMember(x => x.SecondBoxerDto, x => x.MapFrom(y => y.BoxerTwo))
                .ForMember(x => x.VenueDto, x => x.MapFrom(y => y.Venue));
            Mapper.CreateMap<MatchDto, Match>()
                .ForMember(x => x.BoxerOne, x => x.MapFrom(y => context.Boxers.FirstOrDefault(z => z.Id == y.FirstBoxerDto.Id)))
                .ForMember(x => x.BoxerTwo, x => x.MapFrom(y => context.Boxers.FirstOrDefault(z => z.Id == y.SecondBoxerDto.Id)))
                .ForMember(x => x.Venue, x => x.MapFrom(y => context.Venues.FirstOrDefault(z => z.Id == y.VenueDto.Id)));
        }

        [Test]
        public void GetByIdShouldCallRepository()
        {
            const int userId = 42;
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchRepositoryMock.Setup(x => x.GetById(userId)).Returns(new Task<Match>(() => new Match()));
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.GetMatchById(userId);

            m_MatchRepositoryMock.Verify(x => x.GetById(userId), Times.Once);
        }

        [Test]
        public async Task SaveUserShouldCallRepository()
        {
            MatchDto userDto = new MatchDto();
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            await m_MatchService.SaveMatch(userDto);

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

        [Test]
        public void GetMatchesShouldCallRepository()
        {
            const int count = 1;
            const int skip = 42;
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchRepositoryMock.Setup(x => x.GetMatches(count, skip)).Returns(new Task<IList<Match>>(() => new List<Match>()));
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.GetMatches(count, skip);

            m_MatchRepositoryMock.Verify(x => x.GetMatches(count, skip), Times.Once);
        }

        [Test]
        public void CancelAllBetsForAMatchShouldCallRepository()
        {
            const int matchId = 1;
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_MatchService = new MatchService(m_MatchRepositoryMock.Object);

            m_MatchService.Cancel(matchId);

            m_MatchRepositoryMock.Verify(x => x.Cancel(matchId), Times.Once);
        }
    }
}