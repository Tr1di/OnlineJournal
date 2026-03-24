using AutoMapper;
using MakeTopGreatAgain.Data;
using MakeTopGreatAgain.Models.Users;

namespace MakeTopGreatAgain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Group, GroupData>()
                .ForMember(
                    data => data.Sensei,
                    expression =>
                    {
                        expression.Condition(x => x.UserRoles != null);
                        expression.MapFrom(group => group.UserRoles
                            .Where(user => user.IsSensei)
                            .Select(x => x.User)
                            .FirstOrDefault());
                    })
                .ForMember(
                    data => data.Students,
                    expression =>
                    {
                        expression.Condition(x => x.UserRoles != null);
                        expression.MapFrom(group => group.UserRoles
                            .Where(user => !user.IsSensei)
                            .Select(x => x.User));
                    });
            CreateMap<User, UserData>();
        }
    }
}
