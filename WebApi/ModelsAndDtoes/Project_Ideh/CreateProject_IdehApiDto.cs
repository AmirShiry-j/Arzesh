using Domain.Projects;
using Domain.ProjectEnums;
using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Project_Incompleted;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project_Ideh
{
    public class CreateProject_IdehApiDto
    {
        /// <summary>
        /// /Commons For Always
        /// </summary>
        //نام پروژه
        public string Name { get; set; }
        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //میزان سرمایه مورد تقاضا
        public long AmountCapitalDemand { get; set; }
        //آدرس
        [Required]
        public CreateAddressApiDto Address { get; set; }
        /// <summary>
        /// End Commons
        /// </summary>
        /// 

        [Range(1, 2)]
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        [Range(0,100)]
        public int PercentParticipation { get; set; }
        public bool HaveSimilarDomesticCase { get; set; }
        public bool IsRegistered { get; set; }
        public bool HasLicense { get; set; }
        public bool JustificationPlan { get; set; }
        public long RequiredCapitalPlan { get; set; }
        public string WhatTopicsNeedParticipate { get; set; }
        public long NetPresentValue { get; set; }


    }

}
