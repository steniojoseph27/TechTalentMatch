using AutoMapper;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Dtos.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
