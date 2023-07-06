using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IncompletedService.Command
{
    public interface IDeleteProject_IncompletedService
    {
        Task<ResultDto> Execute(int ProjectId, string UserId);
    }
    public class DeleteProject_IncompletedService : IDeleteProject_IncompletedService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteProject_IncompletedService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResultDto> Execute(int ProjectId, string UserId)
        {
            //find project
            var project = _dbContext.P_Incompleteds.Find(ProjectId);

            //check is exist
            if (project == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "پروژه ای با آیدی ارسالی موجود نیست"
                };
            }

            //check is for user
            if (!project.UserId.Equals(UserId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "این آیدی پروژه متعلق به شما نیست"
                };
            }

            //delete in db
            _dbContext.P_Incompleteds.Remove(project);
            _dbContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
