using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
