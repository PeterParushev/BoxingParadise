using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class AdministratorServiceTests
    {
        private Mock<IAdministratorRepository> m_AdminsitrationRepositoryMock;
        private IAdministratorService m_AdminsitrationService;

        [Test]
        public void IsProvidedAdministratorKeyValidShouldCallRepository()
        {
            const string key = "12345";
            m_AdminsitrationRepositoryMock = new Mock<IAdministratorRepository>();
            m_AdminsitrationRepositoryMock.Setup(x => x.IsProvidedAdministratorKeyValid(key)).Returns(Task.Run(() => true));
            m_AdminsitrationService = new AdministratorService(m_AdminsitrationRepositoryMock.Object);

            m_AdminsitrationService.IsProvidedAdministratorKeyValid(key);

            m_AdminsitrationRepositoryMock.Verify(x => x.IsProvidedAdministratorKeyValid(key), Times.Once);
        }
    }
}