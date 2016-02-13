using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class BoxerServiceTests
    {
        private Mock<IBoxerRepository> m_BoxerRepositoryMock;
        private IBoxerService m_BoxerService;

        [Test]
        public void GetBoxersShouldCallRepository()
        {
            m_BoxerRepositoryMock = new Mock<IBoxerRepository>();
            m_BoxerRepositoryMock.Setup(x => x.GetBoxers()).Returns(new List<Boxer>());
            m_BoxerService = new BoxerService(m_BoxerRepositoryMock.Object);

            m_BoxerService.GetBoxers();

            m_BoxerRepositoryMock.Verify(x => x.GetBoxers(), Times.Once);
        }

        [Test]
        public void CreateBoxerShouldCallRepository()
        {
            BoxerDto boxer = new BoxerDto();
            m_BoxerRepositoryMock = new Mock<IBoxerRepository>();
            m_BoxerService = new BoxerService(m_BoxerRepositoryMock.Object);

            m_BoxerService.CreateBoxer(boxer);

            m_BoxerRepositoryMock.Verify(x => x.Persist(It.IsAny<Boxer>()), Times.Once);
        }

        [Test]
        public void DeleteShouldCallRepository()
        {
            const int boxerId = 1;
            m_BoxerRepositoryMock = new Mock<IBoxerRepository>();
            m_BoxerService = new BoxerService(m_BoxerRepositoryMock.Object);

            m_BoxerService.DeleteBoxer(boxerId);

            m_BoxerRepositoryMock.Verify(x => x.Delete(boxerId), Times.Once);
        }
    }
}