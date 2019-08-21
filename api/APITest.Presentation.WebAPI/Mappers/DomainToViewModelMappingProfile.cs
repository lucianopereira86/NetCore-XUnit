using AutoMapper;
using APITest.Presentation.WebAPI.Models.Domain;
using APITest.Presentation.WebAPI.Models.Result;

namespace APITest.Presentation.WebAPI.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserReturnVM>();
        }
    }
}
