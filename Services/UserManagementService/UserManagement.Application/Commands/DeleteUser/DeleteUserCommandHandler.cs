using MediatR;
using UserManagement.Domain.Exceptions;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException<int>(request.Id);
            }

            await _userRepository.DeleteUserAsync(request.Id);
            return Unit.Value;
        }
    }
}
