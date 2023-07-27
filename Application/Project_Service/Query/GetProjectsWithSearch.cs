using Application.Common.SearchDtoes;
using Application.Common;
using Application.Interfaces.Contexts;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Projects;
using Microsoft.EntityFrameworkCore;

namespace Application.Project_Service.Query
{
    public interface IGetProjectsWithSearch
    {
        Task<ResultDto<ResultSearchProjectDto>> Execute(SearchProjectDto SearchDto);

    }
    public class GetProjectsWithSearch : IGetProjectsWithSearch
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectsWithSearch(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResultDto<ResultSearchProjectDto>> Execute(SearchProjectDto SearchDto)
        {
            var prProject = PredicateBuilder.True<Project>();

            //Build Predicate
            //Filter Name
            if (string.IsNullOrWhiteSpace(SearchDto.Name) == false)
            {
                prProject = prProject.And(x => x.Name.Contains(SearchDto.Name));
            }

            //Filter UnitedId
            if (SearchDto.UnitedId != null)
            {
                prProject = prProject.And(x => x.Address.City.UnitedId == SearchDto.UnitedId);
            }
            //Filter CityId
            if (SearchDto.CityId != null)
            {
                prProject = prProject.And(x => x.Address.CityId == SearchDto.CityId);
            }

            //Filter ProjectTypeId
            if (SearchDto.ProjectTypeId != null)
            {
                prProject = prProject.And(x => x.ProjectTypeId == SearchDto.ProjectTypeId);
            }

            //Filter IndustryId
            if (SearchDto.IndustryId != null)
            {
                prProject = prProject.And(x => x.IndustryId == SearchDto.IndustryId);
            }

            //Filter ReturnInvestmentRate
            if (SearchDto.ReturnInvestmentRateFrom != null)
            {
                prProject = prProject.And(x => x.ReturnInvestmentRate >= SearchDto.ReturnInvestmentRateFrom);
            }
            if (SearchDto.ReturnInvestmentRateTo != null)
            {
                prProject = prProject.And(x => x.ReturnInvestmentRate <= SearchDto.ReturnInvestmentRateTo);
            }

            //Filter AmountCapitalDemand
            if (SearchDto.AmountCapitalDemandFrom != null)
            {
                prProject = prProject.And(x => x.AmountCapitalDemand >= SearchDto.AmountCapitalDemandFrom);
            }
            if (SearchDto.AmountCapitalDemandTo != null)
            {
                prProject = prProject.And(x => x.AmountCapitalDemand <= SearchDto.AmountCapitalDemandTo);
            }


            var projects = _dbContext.Projects
                .Include(p => p.Industry)
                .Include(p => p.ProjectType)
                .Include(p => p.Address)
                .ThenInclude(p => p.City)
                .ThenInclude(p => p.United) 
                .Where(prProject)
                .OrderByDescending(p => p.TimeCreate)
                //For Pagination
                .Skip((SearchDto.Page.Value - 1) * SearchDto.CountInPage.Value)
                .Take(SearchDto.CountInPage.Value)
                .Select(p => new ProjectMainInfoDto
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
                    UnitedName = p.Address.City.United.Name
                })
                .ToList();

            //For Pagination
            int CountAllItems = _dbContext.Projects.Where(prProject).Count();
            int CountAllPages = (CountAllItems / SearchDto.CountInPage.Value) + ((CountAllItems % SearchDto.CountInPage) != 0 ? 1 : 0);

            return new ResultDto<ResultSearchProjectDto>
            {
                IsSuccess = true,
                Data = new ResultSearchProjectDto
                {
                    Page = SearchDto.Page.Value,
                    CountInPage = SearchDto.CountInPage.Value,
                    CountAllItems = CountAllItems,
                    CountAllPages= CountAllPages,
                    Projects = projects
                }
            };
        }
    }
    public class SearchProjectDto
    {
        public int? Page { get; set; } = 1;
        public int? CountInPage { get; set; } = 10;

        public int? ProjectTypeId { get; set; }
        public string? Name { get; set; }
        public int? IndustryId { get; set; }
        public int? ReturnInvestmentRateFrom { get; set; }
        public int? ReturnInvestmentRateTo { get; set; }
        public int? AmountCapitalDemandFrom { get; set; }
        public int? AmountCapitalDemandTo { get; set; }
        public int? UnitedId { get; set; }
        public int? CityId { get; set; }
    }
    public class ResultSearchProjectDto
    {
        public int Page { get; set; }
        public int CountInPage { get; set; }
        public int CountAllItems { get; set; }
        public int CountAllPages { get; set; }
        public List<ProjectMainInfoDto> Projects { get; set; }
    }
    public class ProjectMainInfoDto
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
        public Link Link { get; set; }
    }
}
