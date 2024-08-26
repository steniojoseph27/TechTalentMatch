using MediatR;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException<int>(request.Id);
            }

            user.Username = request.Username;
            user.Email = request.Email;

            await _userRepository.UpdateUserAsync(user);
            return Unit.Value;
        }
    }
}
