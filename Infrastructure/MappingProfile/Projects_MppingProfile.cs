
using Application.Project_IdehService.Command;
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
            CreateMap<Project_Ideh, Project_IdehDto>()
                .ReverseMap();

        }
    }
}
