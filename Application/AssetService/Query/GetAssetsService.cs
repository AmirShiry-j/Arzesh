using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssetService.Query
{
    public interface IGetAssetsService
    {
        Task<ResultDto<List<AssetDto>>> Execute();

    }
    public class GetAssetsService : IGetAssetsService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetAssetsService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<AssetDto>>> Execute()
        {
            //Get datas
            var assets = _dbContext.Assets.Select(p => new AssetDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<AssetDto>>
            {
                IsSuccess = true,
                Data = assets
            };
        }
    }
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
