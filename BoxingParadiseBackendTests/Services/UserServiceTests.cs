using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services;
using BoxingParadiseBackend.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace BoxingParadiseBackendTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> m_UserRepositoryMock;
        private IUserService m_UserService;

        [Test]
        public void GetByIdShouldCallRepository()
        {
            const int USER_ID = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserRepositoryMock.Setup(x => x.GetById(USER_ID)).Returns(new User());
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.GetById(USER_ID);

            m_UserRepositoryMock.Verify(x => x.GetById(USER_ID), Times.Once);
        }

        [Test]
        public void SaveUserShouldCallRepository()
        {
            UserDto userDto = new UserDto();
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.SaveUser(userDto);

            m_UserRepositoryMock.Verify(x => x.PersistUser(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void DeleteUserShouldCallRepository()
        {
            const int USER_ID = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.DeleteUser(USER_ID);

            m_UserRepositoryMock.Verify(x => x.DeleteUser(USER_ID), Times.Once);
        }
    }
}