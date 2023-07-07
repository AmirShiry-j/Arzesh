using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FundService.Query
{
    public interface IGetFundsService
    {
        Task<ResultDto<List<FundDto>>> Execute();

    }
    public class GetFundsService : IGetFundsService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetFundsService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<FundDto>>> Execute()
        {
            //Get funds
            var funds = _dbContext.Funds.Select(p => new FundDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<FundDto>>
            {
                IsSuccess = true,
                Data = funds
            };
        }
    }
    public class FundDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
