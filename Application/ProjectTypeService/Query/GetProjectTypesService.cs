using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProjectTypeService.Query
{
    public interface IGetProjectTypesService
    {
        Task<ResultDto<List<ProjectTypeDto>>> Execute();

    }
    public class GetProjectTypesService : IGetProjectTypesService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProjectTypesService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<ProjectTypeDto>>> Execute()
        {
            //Get projectTypes
            var projectTypes = _dbContext.ProjectTypes.Select(p => new ProjectTypeDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<ProjectTypeDto>>
            {
                IsSuccess = true,
                Data = projectTypes
            };
        }
    }
    public class ProjectTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
