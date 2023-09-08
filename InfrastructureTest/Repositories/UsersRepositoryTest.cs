using Domain.Entities;
using Infrastructure.Repositories.Interface;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
namespace InfrastructureTest.Repositories
{
    //private readonly Mock<IConfiguration> mockConfiguration;
    public class UsersRepositoryTest
    {
        private readonly UsersRepository _usersRepository;
        private readonly Mock<IConfiguration> _configuration;
        public UsersRepositoryTest()
        {
            _configuration = new Mock<IConfiguration>();
            _usersRepository = new UsersRepository(_configuration.Object);
        }

        [Fact]
        public void CreateUser_Success()
        {
            Users users = new Users()
            {
                Name = "Test",
                MobileNo = "90000000000",
            };
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "default")]).Returns("mock value");
            _configuration.Setup(a => a.GetSection(It.Is<string>(s => s == "ApplicationConnection"))).
                Returns(mockConfSection.Object);
            var result = _usersRepository.CreateUser(users);
        }

    }
}
