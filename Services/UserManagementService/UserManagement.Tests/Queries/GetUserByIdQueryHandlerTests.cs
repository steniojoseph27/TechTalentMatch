using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Queries.GetUserById;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Username = "testuser", Email = "testuser@example.com" };
            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(userId))
                .ReturnsAsync(user);

            var query = new GetUserByIdQuery { Id = userId };

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
            var userId = 1;
            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(userId))
                .ReturnsAsync((User?)null);

            var query = new GetUserByIdQuery { Id = userId };

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException<int>>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
