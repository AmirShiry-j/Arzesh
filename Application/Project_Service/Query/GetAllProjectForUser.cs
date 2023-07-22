using Application.Common.SearchDtoes;
using Application.Common;
using Application.Interfaces.Contexts;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ProjectEnums;
using Microsoft.EntityFrameworkCore;

namespace Application.Project_Service.Query
{
    public interface IGetAllProjectForUser
    {
        Task<ResultDto<List<ProjectDto>>> Execute(string UserId);

    }
    public class GetAllProjectForUser : IGetAllProjectForUser
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllProjectForUser(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<ProjectDto>>> Execute(string UserId)
        {
            //get projects from db
            var dtoProjects = _dbContext.Projects
                .Include(p => p.Industry)
                .Where(p => p.UserId.Equals(UserId))
                                .OrderByDescending(p => p.TimeCreate)
                .Select(p => new ProjectDto { Id = p.Id, Name = p.Name, ProjectTypeId = p.ProjectTypeId, ProjectTypeName = p.Industry.Name, TimeCreate = p.TimeCreate })
                .ToList();

            return new ResultDto<List<ProjectDto>>
            {
                IsSuccess = true,
                Data = dtoProjects
            };
        }
    }
}
