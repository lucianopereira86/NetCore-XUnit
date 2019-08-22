using AutoMapper;
using APITest.Presentation.WebAPI.Models.VM;
using APITest.Presentation.WebAPI.Models.Domain;

namespace APITest.Presentation.WebAPI.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserPostVM, User>();
            CreateMap<UserPutVM, User>();
        }
    }
}
