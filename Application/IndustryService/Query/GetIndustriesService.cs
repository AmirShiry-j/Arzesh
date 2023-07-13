using Application.Common;
using Application.FundService.Query;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IndustryService.Query
{
    public interface IGetIndustriesService
    {
        Task<ResultDto<List<IndustryDto>>> Execute();

    }
    public class GetIndustriesService : IGetIndustriesService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetIndustriesService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<IndustryDto>>> Execute()
        {
            //Get industries
            var industries = _dbContext.Industries.Select(p => new IndustryDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<IndustryDto>>
            {
                IsSuccess = true,
                Data = industries
            };
        }
    }
    public class IndustryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
