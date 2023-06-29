using Application.Common;
using Application.Interfaces.Contexts;
using Application.TokenService;
using AutoMapper;
using Domain.Project;
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
        Task<ResultDto<int>> Execute(Project_IdehCreateDto IdehDto, string UserId);
    }
    public class AddProject_IdehService : IAddProject_IdehService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public AddProject_IdehService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResultDto<int>> Execute(Project_IdehCreateDto IdehDto, string UserId)
        {
            //Map
            var newIdeh = _mapper.Map<Project_Ideh>(IdehDto);
            newIdeh.UserId = UserId;

            //save in db
            _dbContext.P_Idehs.Add(newIdeh);
            _dbContext.SaveChanges();

            return new ResultDto<int>
            {
                IsSuccess = true,
                Data = newIdeh.Id
            };
        }
    }
    public class Project_IdehCreateDto
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
