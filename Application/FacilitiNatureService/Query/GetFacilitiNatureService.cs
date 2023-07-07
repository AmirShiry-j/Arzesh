using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FacilitiNatureService.Query
{
    public interface IGetFacilitiNatureService
    {
        Task<ResultDto<List<FacilitiNatureDto>>> Execute();

    }
    public class GetFacilitiNatureService : IGetFacilitiNatureService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetFacilitiNatureService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<FacilitiNatureDto>>> Execute()
        {
            //Get FacilitiNatures
            var facilitiNatures = _dbContext.FacilitiNatures.Select(p => new FacilitiNatureDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<FacilitiNatureDto>>
            {
                IsSuccess = true,
                Data = facilitiNatures
            };
        }
    }
    public class FacilitiNatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
