using Application.Common.CreateDtoes;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using Application.Project_ReadyToUseService.Command;
using Application.Project_Service.Query;
using Application.Project_UnderCapacityService.Command;
using AutoMapper;
using Domain.Projects;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;
using WebApi.ModelsAndDtoes.Project;
using WebApi.ModelsAndDtoes.Project__ReadyToUse;
using WebApi.ModelsAndDtoes.Project_Ideh;
using WebApi.ModelsAndDtoes.Project_Incompleted;
using WebApi.ModelsAndDtoes.Project_UnderCapacity;

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

            CreateMap<CreateAssetRelProjectDto, CreateAssetRelProjectApiDto>()
.ReverseMap();

            CreateMap<CreateCapacityRelProjectDto, CreateCapacityRelProjectApiDto>()
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

            //Add Project_ReadyToUse
            #region Add Project_ReadyToUse
            CreateMap<CreateProject_ReadyToUseDto, CreateProject_ReadyToUseApiDto>()
    .ReverseMap();
            #endregion
            //

            //Add Project_UnderCapacity
            #region Add Project_UnderCapacity
            CreateMap<CreateProject_UnderCapacityDto, CreateProject_UnderCapacityApiDto>()
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
