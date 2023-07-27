using Application.Common;
using Application.FacilitiStatusService.Query;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RentTypeService.Query
{
    public interface IGetRentTypeService
    {
        Task<ResultDto<List<RentTypeDto>>> Execute();

    }
    public class GetRentTypeService : IGetRentTypeService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetRentTypeService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<RentTypeDto>>> Execute()
        {
            //Get FacilitiStatuses
            var rentTypes = _dbContext.RentTypes.Select(p => new RentTypeDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RentTypeDto>>
            {
                IsSuccess = true,
                Data = rentTypes
            };
        }
    }
    public class RentTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
