using Moq;
using UserManagement.Application.Queries.GetAllUsers;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Queries
{
    public class GetAllUsersQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetAllUsersQueryHandler _handler;

        public GetAllUsersQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
        {
            new User { Id = 1, Username = "user1", Email = "user1@example.com" },
            new User { Id = 2, Username = "user2", Email = "user2@example.com" }
        };
            _userRepositoryMock.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(users);

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoUsersExist()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
