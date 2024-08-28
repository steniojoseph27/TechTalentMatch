using Moq;
using UserManagement.Application.Commands.UpdateUser;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Commands
{
    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UpdateUserCommandHandler _handler;

        public UpdateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new UpdateUserCommandHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateUser_WhenUserExists()
        {
            var command = new UpdateUserCommand { Id = 1, Username = "updateduser", Email = "updated@example.com" };
            var user = new User { Id = 1, Username = "testuser", Email = "test@example.com" };

            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(1)).ReturnsAsync(user);
            _userRepositoryMock.Setup(repo => repo.UpdateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            await _handler.Handle(command, CancellationToken.None);

            _userRepositoryMock.Verify(repo => repo.UpdateUserAsync(It.Is<User>(u => u.Username == "updateduser" && u.Email == "updated@example.com")), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
        {
            var command = new UpdateUserCommand { Id = 1, Username = "updateduser", Email = "updated@example.com" };

            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(1)).ReturnsAsync((User?)null);

            await Assert.ThrowsAsync<UserNotFoundException<int>>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
