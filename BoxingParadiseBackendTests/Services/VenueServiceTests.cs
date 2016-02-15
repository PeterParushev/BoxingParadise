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
    public class VenueServiceTests
    {
        private Mock<IVenueRepository> m_VenueRepositoryMock;
        private IVenueService m_VenueService;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Mapper.CreateMap<Venue, VenueDto>();
            Mapper.CreateMap<VenueDto, Venue>();
        }

        [Test]
        public void GetVenuesShouldCallRepository()
        {
            m_VenueRepositoryMock = new Mock<IVenueRepository>();
            m_VenueRepositoryMock.Setup(x => x.GetVenues()).Returns(new Task<IList<Venue>>(() => new List<Venue>()));
            m_VenueService = new VenueService(m_VenueRepositoryMock.Object);

            m_VenueService.GetVenues();

            m_VenueRepositoryMock.Verify(x => x.GetVenues(), Times.Once);
        }

        [Test]
        public void CreateVenueShouldCallRepository()
        {
            VenueDto venue = new VenueDto();
            m_VenueRepositoryMock = new Mock<IVenueRepository>();
            m_VenueService = new VenueService(m_VenueRepositoryMock.Object);

            m_VenueService.CreateVenue(venue);

            m_VenueRepositoryMock.Verify(x => x.Persist(It.IsAny<Venue>()), Times.Once);
        }

        [Test]
        public void DeleteVenueShouldCallRepository()
        {
            const int venueId = 1;
            m_VenueRepositoryMock = new Mock<IVenueRepository>();
            m_VenueService = new VenueService(m_VenueRepositoryMock.Object);

            m_VenueService.DeleteVenue(venueId);

            m_VenueRepositoryMock.Verify(x => x.Delete(venueId), Times.Once);
        }
    }
}