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
    public class UserServiceTests
    {
        private Mock<IUserRepository> m_UserRepositoryMock;
        private IUserService m_UserService;

        [Test]
        public void GetByIdShouldCallRepository()
        {
            const int userId = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserRepositoryMock.Setup(x => x.GetById(userId)).Returns(new User());
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.GetById(userId);

            m_UserRepositoryMock.Verify(x => x.GetById(userId), Times.Once);
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
            const int userId = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.DeleteUser(userId);

            m_UserRepositoryMock.Verify(x => x.DeleteUser(userId), Times.Once);
        }

        [Test]
        public void GetUsersShouldCallRepository()
        {
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserRepositoryMock.Setup(x => x.GetUsers()).Returns(new List<User>());
            m_UserService = new UserService(m_UserRepositoryMock.Object);

            m_UserService.GetUsers();

            m_UserRepositoryMock.Verify(x => x.GetUsers(), Times.Once);
        }
    }
}