using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IncompletedService.Query
{
    public interface IGetProject_IncompletedById
    {
        Task<ResultDto<Project_IncompletedDetailDto>> Execute(int Id, string UserId);

    }

    public class GetProject_IncompletedById : IGetProject_IncompletedById
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProject_IncompletedById(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<Project_IncompletedDetailDto>> Execute(int Id, string UserId)
        {
            //get Incompleted from db
            var project = _dbContext.P_Incompleteds.Find(Id);

            //check is exist
            if (project == null)
            {
                return new ResultDto<Project_IncompletedDetailDto>
                {
                    IsSuccess = false,
                    Message = "پروژه ای با آیدی ارسالی موجود نیست"
                };
            }

            //check is for user
            if (!project.UserId.Equals(UserId))
            {
                return new ResultDto<Project_IncompletedDetailDto>
                {
                    IsSuccess = false,
                    Message = "این آیدی پروژه متعلق به شما نیست"
                };
            }

            var dto = _mapper.Map<Project_IncompletedDetailDto>(project);

            return new ResultDto<Project_IncompletedDetailDto>
            {
                IsSuccess = true,
                Data = dto
            };

        }
    }
    public class Project_IncompletedDetailDto
    {

        public int Id { get; set; }
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        public int PercentParticipation { get; set; }
        public int AmountOfExperience { get; set; }
        public bool HaveAllLicences { get; set; }
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        public int RentTypeId { get; set; }
        public int IndustryId { get; set; }
        public bool JustificationPlan { get; set; }
        public int ProposedPrice { get; set; }
        public int RequiredCapitalPlan { get; set; }
        public int AmountCapitalDemand { get; set; }
        public string WhatTopicsNeedParticipate { get; set; }
        public int ReturnInvestmentRate { get; set; }
        public int NetPresentValue { get; set; }
        public bool HaveReceivedFaciliti { get; set; }

        public List<Link> Links { get; set; }

    }
}

