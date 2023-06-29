using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IdehService.Query
{
    public interface IGetAllProject_IdehForUser
    {
        Task<ResultDto<ResultSearchDto>> Execute(SearchProject_IdehDto SearchDto, string UserId);

    }

    public class GetAllProject_IdehForUser : IGetAllProject_IdehForUser
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllProject_IdehForUser(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultSearchDto>> Execute(SearchProject_IdehDto SearchDto, string UserId)
        {
            //Build Predicate
            var prProject = PredicateBuilder.True<Project_Ideh>();

            prProject = prProject.And(x => x.UserId.Equals(UserId));

            //get projects from db
            var projects = _dbContext.P_Idehs
                .Where(prProject)
                                .OrderByDescending(p => p.Id)
                //For Pagination
                .Skip((SearchDto.Page.Value - 1) * SearchDto.CountInPage.Value)
                .Take(SearchDto.CountInPage.Value)
                .ToList();

            //For Pagination
            int CountAllItems = _dbContext.P_Idehs.Where(prProject).Count();

            //map
            var dtoProjects = _mapper.Map<List<Project_IdehDto>>(projects);

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
    public class SearchProject_IdehDto
    {
        public int? Page { get; set; } = 1;
        public int? CountInPage { get; set; } = 10;
    }
    public class ResultSearchDto
    {
        public int Page { get; set; }
        public int CountInPage { get; set; }
        public int CountAllItems { get; set; }
        public List<Project_IdehDto> Projects { get; set; }
    }
    public class Project_IdehDto
    {
        public int Id { get; set; }
        public Link Link { get; set; }

    }
}
