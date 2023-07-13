using Application.Common;
using Application.CommonServices.Query;
using Application.Interfaces.Contexts;
using Application.TokenService;
using AutoMapper;
using Domain.Project;
using Domain.ProjectEnums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IdehService.Command
{
    public interface IAddProject_IdehService
    {
        Task<ResultDto<int>> Execute(CreateProject_IdehDto IdehDto, string UserId);
    }
    public class AddProject_IdehService : IAddProject_IdehService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidateService _validateService;
        public AddProject_IdehService
(IDataBaseContext dbContext,
            IMapper mapper,
            IValidateService validateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validateService = validateService;
        }
        public async Task<ResultDto<int>> Execute(CreateProject_IdehDto IdehDto, string UserId)
        {
            //Map
            var newProject = _mapper.Map<Project_Ideh>(IdehDto);
            newProject.UserId = UserId;

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            //save in db
            _dbContext.P_Idehs.Add(newProject);
            _dbContext.SaveChanges();

            return new ResultDto<int>
            {
                IsSuccess = true,
                Data = newProject.Id
            };
        }
    }
    public class CreateProject_IdehDto
    {
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

    }
}
