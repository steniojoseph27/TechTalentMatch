using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
