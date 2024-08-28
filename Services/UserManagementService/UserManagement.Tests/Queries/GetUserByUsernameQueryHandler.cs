using Moq;
using UserManagement.Application.Queries.GetUserByUserName;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Queries
{
    public class GetUserByUserNameQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserByUserNameQueryHandler _handler;

        public GetUserByUserNameQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserByUserNameQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var username = "testuser";
            var user = new User { Id = 1, Username = username, Email = "testuser@example.com" };
            _userRepositoryMock.Setup(repo => repo.GetByUserNameAsync(username))
                .ReturnsAsync(user);

            var query = new GetUserByUserNameQuery { Username = username };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Username, result.Username);
            Assert.Equal(user.Email, result.Email);
        }

        [Fact]
        public async Task Handle_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var username = "nonexistentuser";
            _ = _userRepositoryMock.Setup(repo => repo.GetByUserNameAsync(username))
                .ReturnsAsync((User?)null);

            var query = new GetUserByUserNameQuery { Username = username };

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException<string>>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
