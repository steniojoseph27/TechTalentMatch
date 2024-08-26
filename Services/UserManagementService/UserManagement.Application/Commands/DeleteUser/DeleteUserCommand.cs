using MediatR;

namespace UserManagement.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
