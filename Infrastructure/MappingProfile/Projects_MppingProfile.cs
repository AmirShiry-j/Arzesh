
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using AutoMapper;
using Domain.Project;
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
            CreateMap<Project_Ideh, CreateProject_IdehDto>()
                .ReverseMap();
            CreateMap<Project_Ideh, Project_IdehDetailDto>()
       .ReverseMap();
            CreateMap<Project_Ideh, Project_IdehDto>()
.ReverseMap();
        }
    }
}
