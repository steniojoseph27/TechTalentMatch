using Moq;
using UserManagement.Application.Commands.DeleteUser;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Commands
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DeleteUserCommandHandler _handler;

        public DeleteUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new DeleteUserCommandHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteUser_WhenUserExists()
        {
            var command = new DeleteUserCommand { Id = 1 };
            var user = new User { Id = 1, Username = "testuser", Email = "test@example.com" };

            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(1)).ReturnsAsync(user);
            _userRepositoryMock.Setup(repo => repo.DeleteUserAsync(1)).Returns(Task.CompletedTask);

            await _handler.Handle(command, CancellationToken.None);

            _userRepositoryMock.Verify(repo => repo.DeleteUserAsync(1), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
        {
            var command = new DeleteUserCommand { Id = 1 };

            _userRepositoryMock.Setup(repo => repo.GetByUserIdAsync(1)).ReturnsAsync((User)null);

            await Assert.ThrowsAsync<UserNotFoundException<int>>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
