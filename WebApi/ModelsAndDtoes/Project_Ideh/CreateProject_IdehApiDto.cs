using Domain.Projects;
using Domain.ProjectEnums;
using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Project_Incompleted;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project_Ideh
{
    public class CreateProject_IdehApiDto
    {
        //نام پروژه
        public string Name { get; set; }
        [Range(1, 2)]
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        [Range(0,100)]
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
        [Required]
        public CreateAddressApiDto Address { get; set; }

    }

}
