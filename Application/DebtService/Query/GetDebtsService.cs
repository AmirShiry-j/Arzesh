using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DebtService.Query
{
    public interface IGetDebtsService
    {
        Task<ResultDto<List<DebtDto>>> Execute();
    }
    public class GetDebtsService : IGetDebtsService
    {
        private readonly IDataBaseContext _dbContext;
        public GetDebtsService(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultDto<List<DebtDto>>> Execute()
        {
            //Get datas
            var datas = _dbContext.Debts.Select(p => new DebtDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<DebtDto>>
            {
                IsSuccess = true,
                Data = datas
            };
        }
    }
    public class DebtDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
