using Application.Common.CreateDtoes;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using Application.Project_Service.Query;
using AutoMapper;
using Domain.Projects;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;
using WebApi.ModelsAndDtoes.Project;
using WebApi.ModelsAndDtoes.Project_Ideh;
using WebApi.ModelsAndDtoes.Project_Incompleted;

namespace WebApi.Tools.AutoMapper
{
    public class Projects_Mpping_EndPointProfile : Profile
    {
        public Projects_Mpping_EndPointProfile()
        {
            //Common
            #region Common
            CreateMap<CreateAddressDto, CreateAddressApiDto>()
.ReverseMap();

            CreateMap<CreateLicenceRelProjectDto, CreateLicenceRelProjectApiDto>()
.ReverseMap();

            CreateMap<CreateFacilitiRelProjectDto, CreateFacilitiRelProjectApiDto>()
.ReverseMap();

            CreateMap<CreateFundRelProjectDto, CreateFundRelProjectApiDto>()
.ReverseMap();
            #endregion
            //

            //Add Project_Ideh
            #region Add Project_Ideh
            CreateMap<CreateProject_IdehDto, CreateProject_IdehApiDto>()
                .ReverseMap();
            #endregion
            //

            //Add Project_Incompleted
            #region Add Project_Incompleted
            CreateMap<CreateProject_IncompletedDto, CreateProject_IncompletedApiDto>()
    .ReverseMap();
            #endregion
            //

            //Project
            #region Add Project
            CreateMap<SearchProjectDto, SearchProjectApiDto>()
.ReverseMap();
            #endregion
            //
        }
    }
}
