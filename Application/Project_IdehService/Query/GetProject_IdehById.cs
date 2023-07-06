using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Project;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IdehService.Query
{
    public interface IGetProject_IdehById
    {
        Task<ResultDto<Project_IdehDetailDto>> Execute(int Id, string UserId);

    }

    public class GetProject_IdehById : IGetProject_IdehById
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProject_IdehById(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<Project_IdehDetailDto>> Execute(int Id, string UserId)
        {
            //get ideh from db
            var project = _dbContext.P_Idehs.Find(Id);

            //check is exist
            if (project == null)
            {
                return new ResultDto<Project_IdehDetailDto>
                {
                    IsSuccess = false,
                    Message = "پروژه ای با آیدی ارسالی موجود نیست"
                };
            }

            //check is for user
            if (!project.UserId.Equals(UserId))
            {
                return new ResultDto<Project_IdehDetailDto>
                {
                    IsSuccess = false,
                    Message = "این آیدی پروژه متعلق به شما نیست"
                };
            }

            var dto = _mapper.Map<Project_IdehDetailDto>(project);

            return new ResultDto<Project_IdehDetailDto>
            {
                IsSuccess = true,
                Data = dto
            };

        }
    }
    public class Project_IdehDetailDto
    {
        public int Id { get; set; }
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        public int PercentParticipation { get; set; }
        public bool HaveSimilarDomesticCase { get; set; }
        public bool IsRegistered { get; set; }
        public bool HasLicense { get; set; }
        public bool JustificationPlan { get; set; }
        public int IndustryId { get; set; }
        public int RequiredCapitalPlan { get; set; }
        public int AmountCapitalDemand { get; set; }
        public string WhatTopicsNeedParticipate { get; set; }
        public int ReturnInvestmentRate { get; set; }
        public int NetPresentValue { get; set; }
        public List<Link> Links { get; set; }

    }
}

