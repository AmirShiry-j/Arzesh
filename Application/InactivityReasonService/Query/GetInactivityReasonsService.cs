using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InactivityReasonService.Query
{
    public interface IGetInactivityReasonsService
    {
        Task<ResultDto<List<InactivityReasonDto>>> Execute();
    }
    public class GetInactivityReasonsService : IGetInactivityReasonsService
    {
        private readonly IDataBaseContext _dbContext;
        public GetInactivityReasonsService(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultDto<List<InactivityReasonDto>>> Execute()
        {
            //Get datas
            var datas = _dbContext.InactivityReasons.Select(p => new InactivityReasonDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<InactivityReasonDto>>
            {
                IsSuccess = true,
                Data = datas
            };
        }
    }
    public class InactivityReasonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
