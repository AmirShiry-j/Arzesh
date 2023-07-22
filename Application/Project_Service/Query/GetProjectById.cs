using Application.Common;
using Application.Interfaces.Contexts;
using Application.Project_IdehService.Query;
using AutoMapper;
using Domain.ProjectEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_Service.Query
{
    public interface IGetProjectById
    {
        Task<ResultDto<ProjectDetailDto>> Execute(int Id);
    }
    public class GetProjectById : IGetProjectById
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectById(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<ProjectDetailDto>> Execute(int Id)
        {
            //get ideh from db
            var projectDto = _dbContext.Projects.Where(p => p.Id.Equals(Id))
                .Include(p => p.Industry)
                .Include(p => p.ProjectType)
                .Include(p => p.Address)
                .ThenInclude(p => p.City)
                .ThenInclude(p => p.United)
                .Select(p => new ProjectDetailDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProjectTypeId = p.ProjectTypeId,
                    ProjectTypeName = p.ProjectType.Name,
                    IndustryId = (int)p.IndustryId,
                    IndustryName = p.Industry.Name,
                    ReturnInvestmentRate = p.ReturnInvestmentRate,
                    AmountCapitalDemand = p.AmountCapitalDemand,
                    CityId = p.Address.CityId,
                    CityName = p.Address.City.Name,
                    UnitedId = p.Address.City.UnitedId,
                    UnitedName = p.Address.City.United.Name,
                    TimeCreate = p.TimeCreate
                })
                .FirstOrDefault()

                ;

            //check is exist
            if (projectDto == null)
            {
                return new ResultDto<ProjectDetailDto>
                {
                    IsSuccess = false,
                    Message = "پروژه ای با آیدی ارسالی موجود نیست"
                };
            }

            return new ResultDto<ProjectDetailDto>
            {
                IsSuccess = true,
                Data = projectDto
            };

        }
    }
    public class ProjectDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IndustryName { get; set; }
        public int IndustryId { get; set; }
        public int ReturnInvestmentRate { get; set; }
        public int AmountCapitalDemand { get; set; }
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int UnitedId { get; set; }
        public string UnitedName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public DateTime TimeCreate { get; set; }
    }
}
