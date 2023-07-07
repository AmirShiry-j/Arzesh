using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Domain.Project;
using WebApi.ModelsAndDtoes.Project_Ideh;
using WebApi.ModelsAndDtoes.Project_Incompleted;

namespace WebApi.Tools.AutoMapper
{
    public class Projects_Mpping_EndPointProfile : Profile
    {
        public Projects_Mpping_EndPointProfile()
        {
            //Ideh
            CreateMap<CreateProject_IdehDto, CreateProject_IdehApiDto>()
                .ReverseMap();

            CreateMap<SearchProject_IdehDto, SearchProject_IdehApiDto>()
    .ReverseMap();


            //Incompleted
            CreateMap<CreateProject_IncompletedDto, CreateProject_IncompletedApiDto>()
    .ReverseMap();

            CreateMap<SearchProject_IncompletedDto, SearchProject_IncompletedApiDto>()
    .ReverseMap();

            CreateMap<CreateAddressDto, CreateAddressApiDto>()
    .ReverseMap();
            CreateMap<CreateLicenceRelProjectDto, CreateLicenceRelProjectApiDto>()
.ReverseMap();
            CreateMap<CreateFacilitiRelProjectDto, CreateFacilitiRelProjectApiDto>()
.ReverseMap();
            CreateMap<CreateFundRelProjectDto, CreateFundRelProjectApiDto>()
.ReverseMap();
        }
    }
}
