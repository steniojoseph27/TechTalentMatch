using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Commands.CreateUser;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Tests.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new CreateUserCommandHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCreatedUser()
        {
            var command = new CreateUserCommand { Username = "testuser", Email = "test@example.com" };
            var user = new User { Id = 1, Username = "testuser", Email = "test@example.com" };

            _userRepositoryMock.Setup(repo => repo.AddUserAsync(It.IsAny<User>())).ReturnsAsync(user);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeEquivalentTo(user);
        }
    }
}
