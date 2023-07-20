
using Application.Common;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Domain.Projects;
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

            CreateMap<Project, CreateProject_IdehDto>()
                .ReverseMap();
            CreateMap<Project_Ideh, CreateProject_IdehDto>()
                .ReverseMap();
            CreateMap<Address, CreateAddressDto>()
                .ReverseMap();

            //Detail Project_Ideh
            CreateMap<Project, Project_IdehDetailDto>()
            .ForMember(dto => dto.IndustryName, entity => entity.MapFrom(p => p.Industry.Name))
       .ReverseMap();

            CreateMap<Project_Ideh, Project_IdehDetailDto>()
.ReverseMap();

            CreateMap<Address, AddressDetailDto>()
            .ForMember(dto => dto.UnitedName, entity => entity.MapFrom(p => p.City.United.Name))
            .ForMember(dto => dto.UnitedId, entity => entity.MapFrom(p => p.City.United.Id))
            .ForMember(dto => dto.CityName, entity => entity.MapFrom(p => p.City.Name))
.ReverseMap();

            CreateMap<Project, ProjectDto>()
.ReverseMap();
            //            //




            //            CreateMap<LicenceRelProject, CreateLicenceRelProjectDto>()
            //.ReverseMap();

            //            CreateMap<FacilitiRelProject, CreateFacilitiRelProjectDto>()
            //.ReverseMap();

            //            CreateMap<FundRelProject, CreateFundRelProjectDto>()
            //.ReverseMap();

            //            CreateMap<Project_Incompleted, CreateProject_IncompletedDto>()
            //.ReverseMap();


            //            CreateMap<Project_Incompleted, Project_IncompletedDto>()
            //.ReverseMap();

            //Detail Project_Incompleted
            //            CreateMap<Project_Incompleted, Project_IncompletedDetailDto>()
            //            .ForMember(dto => dto.IndustryName, entity => entity.MapFrom(p => p.Industry.Name))
            //.ReverseMap();



            //            CreateMap<LicenceRelProject, LicenceRelProjectDetailDto>()
            //            .ForMember(dto => dto.LicenceName, entity => entity.MapFrom(p => p.Licence.Name))
            //.ReverseMap();

            //            CreateMap<FacilitiRelProject, FacilitiRelProjectDetailDto>()
            //            .ForMember(dto => dto.FacilitiNatureName, entity => entity.MapFrom(p => p.FacilitiNature.Name))
            //            .ForMember(dto => dto.FacilitiStatusName, entity => entity.MapFrom(p => p.FacilitiStatus.Name))
            //.ReverseMap();

            //            CreateMap<FundRelProject, FundRelProjectDetailDto>()
            //            .ForMember(dto => dto.FundName, entity => entity.MapFrom(p => p.Fund.Name))
            //.ReverseMap();
            //
        }
    }
}
