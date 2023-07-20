using Application.Common;
using Application.Common.SearchDtoes;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectEnums;
using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IncompletedService.Query
{
    public interface IGetAllProject_IncompletedForUser
    {
        Task<ResultDto<ResultSearchDto>> Execute(SearchProject_IncompletedDto SearchDto, string UserId);

    }
    public class GetAllProject_IncompletedForUser : IGetAllProject_IncompletedForUser
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllProject_IncompletedForUser(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultSearchDto>> Execute(SearchProject_IncompletedDto SearchDto, string UserId)
        {
            //Build Predicate
            var prProject = PredicateBuilder.True<Project>();

            prProject = prProject.And(x => x.UserId.Equals(UserId));
            prProject = prProject.And(x => x.ProjectTypeId.Equals((int)ProjectTypeEnum.Incompleted));

            //get projects from db
            var projects = _dbContext.Projects
                .Where(prProject)
                                .OrderByDescending(p => p.TimeCreate)
                //For Pagination
                .Skip((SearchDto.Page.Value - 1) * SearchDto.CountInPage.Value)
                .Take(SearchDto.CountInPage.Value)
                .ToList();

            //For Pagination
            int CountAllItems = _dbContext.Projects.Where(prProject).Count();

            //map
            var dtoProjects = _mapper.Map<List<ProjectDto>>(projects);

            return new ResultDto<ResultSearchDto>
            {
                IsSuccess = true,
                Data = new ResultSearchDto
                {
                    Page = SearchDto.Page.Value,
                    CountInPage = SearchDto.CountInPage.Value,
                    CountAllItems = CountAllItems,
                    Projects = dtoProjects
                }
            };
        }
    }
    public class SearchProject_IncompletedDto
    {
        public int? Page { get; set; } = 1;
        public int? CountInPage { get; set; } = 10;
    }
}
