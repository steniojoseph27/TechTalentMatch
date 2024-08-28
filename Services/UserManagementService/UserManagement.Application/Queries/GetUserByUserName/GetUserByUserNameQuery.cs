using MediatR;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Queries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        public string Username { get; set; } = string.Empty;
    }
}
