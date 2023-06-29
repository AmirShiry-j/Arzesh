using Domain.Project;

namespace WebApi.ModelsAndDtoes.Project_Ideh
{
    public class CreateProject_IdehApiDto
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
