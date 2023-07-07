using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FacilitiStatusService.Query
{
    public interface IGetFacilitiStatusService
    {
        Task<ResultDto<List<FacilitiStatusDto>>> Execute();

    }
    public class GetFacilitiStatusService : IGetFacilitiStatusService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetFacilitiStatusService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<FacilitiStatusDto>>> Execute()
        {
            //Get FacilitiStatuses
            var facilitiStatuses = _dbContext.FacilitiStatuses.Select(p => new FacilitiStatusDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<FacilitiStatusDto>>
            {
                IsSuccess = true,
                Data = facilitiStatuses
            };
        }
    }
    public class FacilitiStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
