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
    public class UserServiceTests
    {
        private Mock<IUserRepository> m_UserRepositoryMock;
        private Mock<IBetRepository> m_BetRepositoryMock;
        private Mock<IMatchRepository> m_MatchRepositoryMock;
        private IUserService m_UserService;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }

        [Test]
        public void GetByIdShouldCallRepository()
        {
            const int userId = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_UserRepositoryMock.Setup(x => x.GetById(userId)).Returns(new Task<User>(() => new User()));
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object, m_BetRepositoryMock.Object, m_MatchRepositoryMock.Object);

            m_UserService.GetUser(userId);

            m_UserRepositoryMock.Verify(x => x.GetById(userId), Times.Once);
        }

        [Test]
        public void SaveUserShouldCallRepository()
        {
            UserDto userDto = new UserDto();
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object, m_BetRepositoryMock.Object, m_MatchRepositoryMock.Object);

            m_UserService.CreateUser(userDto);

            m_UserRepositoryMock.Verify(x => x.PersistUser(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void DeleteUserShouldCallRepository()
        {
            const int userId = 42;
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object, m_BetRepositoryMock.Object, m_MatchRepositoryMock.Object);

            m_UserService.DeleteUser(userId);

            m_UserRepositoryMock.Verify(x => x.DeleteUser(userId), Times.Once);
        }

        [Test]
        public void GetUsersShouldCallRepository()
        {
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserRepositoryMock.Setup(x => x.GetUsers(It.IsAny<int>(), It.IsAny<int>())).Returns(new Task<IList<User>>(() => new List<User>()));
            m_BetRepositoryMock = new Mock<IBetRepository>();
            m_MatchRepositoryMock = new Mock<IMatchRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object, m_BetRepositoryMock.Object, m_MatchRepositoryMock.Object);

            m_UserService.GetUser(10, 10);

            m_UserRepositoryMock.Verify(x => x.GetUsers(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}