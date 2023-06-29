using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using AutoMapper;
using Domain.Project;
using WebApi.ModelsAndDtoes.Project_Ideh;

namespace WebApi.Tools.AutoMapper
{
    public class Projects_Mpping_EndPointProfile : Profile
    {
        public Projects_Mpping_EndPointProfile()
        {
            CreateMap<CreateProject_IdehDto, CreateProject_IdehApiDto>()
                .ReverseMap();

            CreateMap<CreateProject_IdehDto, CreateProject_IdehApiDto>()
    .ReverseMap();

            CreateMap<SearchProject_IdehDto, SearchProject_IdehApiDto>()
    .ReverseMap();
        }
    }
}
