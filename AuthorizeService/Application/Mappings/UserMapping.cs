using AuthorizeService.Infrastructure.Context;
using AutoMapper;

namespace AuthorizeService;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserDomain, User>();
    }

}
