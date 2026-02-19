using AutoMapper;
using MakeTopGreatAgain.Data;
using MakeTopGreatAgain.Models.Users;

namespace MakeTopGreatAgain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Group, GroupData>();
            CreateMap<User, UserData>();
        }
    }
}
