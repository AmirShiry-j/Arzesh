using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LicenceService.Query
{
    public interface IGetLicencesService
    {
        Task<ResultDto<List<LicenceDto>>> Execute();

    }
    public class GetLicencesService : IGetLicencesService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetLicencesService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<LicenceDto>>> Execute()
        {
            //Get Licences
            var licences = _dbContext.Licences.Select(p => new LicenceDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
            
            return new ResultDto<List<LicenceDto>>
            {
                IsSuccess = true,
                Data = licences
            };
        }
    }
    public class LicenceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
