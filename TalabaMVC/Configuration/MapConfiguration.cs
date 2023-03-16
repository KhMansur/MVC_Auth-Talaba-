using AutoMapper;
using TalabaMVC.Models;

namespace TalabaMVC.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
