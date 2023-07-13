
using Application.Common;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Domain.Project;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfile
{
    public class Projects_MppingProfile : Profile
    {
        public Projects_MppingProfile()
        {
            CreateMap<ResultDto, ResultDto<int>>().ReverseMap();

            CreateMap<Project_Ideh, CreateProject_IdehDto>()
                .ReverseMap();
            CreateMap<Project_Ideh, Project_IdehDetailDto>()
       .ReverseMap();
            CreateMap<Project_Ideh, Project_IdehDto>()
.ReverseMap();

            CreateMap<Address, CreateAddressDto>()
.ReverseMap();

            CreateMap<LicenceRelProject, CreateLicenceRelProjectDto>()
.ReverseMap();

            CreateMap<FacilitiRelProject, CreateFacilitiRelProjectDto>()
.ReverseMap();

            CreateMap<FundRelProject, CreateFundRelProjectDto>()
.ReverseMap();

            CreateMap<Project_Incompleted, CreateProject_IncompletedDto>()
.ReverseMap();

            CreateMap<Project_Incompleted, Project_IncompletedDetailDto>()
.ReverseMap();
            CreateMap<Project_Incompleted, Project_IncompletedDto>()
.ReverseMap();

        }
    }
}
