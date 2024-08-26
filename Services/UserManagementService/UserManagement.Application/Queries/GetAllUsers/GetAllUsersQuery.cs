using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
