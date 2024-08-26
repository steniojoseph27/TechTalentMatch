using MediatR;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email
            };

            return await _userRepository.AddUserAsync(user);
        }
    }
}
