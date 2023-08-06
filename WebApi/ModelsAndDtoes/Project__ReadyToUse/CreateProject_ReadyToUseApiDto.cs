using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project__ReadyToUse
{
    public class CreateProject_ReadyToUseApiDto
    {
        //نام پروژه
        public string Name { get; set; }
        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        [Range(1, 2)]
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        [Range(0, 100)]
        public int PercentParticipation { get; set; }
        //مشارکت
        //آیا در حوزه فعالیت طرح سابقه و یا تجربه دارید؟ 
        public string AmountOfExperience { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }
        //محل اجرای طرح
        [Range(1, 3)]
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }

        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //واگذاری
        //قیمت پیشنهادی
        public int ProposedPrice { get; set; }
        //مشارکت
        //کل سرمایه مورد نیاز طرح
        public int RequiredCapitalPlan { get; set; }
        //میزان سرمایه مورد تقاضا
        public int AmountCapitalDemand { get; set; }
        //مشارکت
        //در چه سرفصل‌هایی نیاز به مشارکت دارید؟
        public string WhatTopicsNeedParticipate { get; set; }
        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //خالص ارزش فعلی پروژه
        public int NetPresentValue { get; set; }
        //درصد پیشرفت کلی طرح تا کنون
        [Range(0, 100)]
        public int OverallProgressPercent { get; set; }


        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        //تاریخ عملیاتی شروع فعالیت
        public string DateStartOfOperationalActivities { get; set; }
        [Required]
        public CreateAddressApiDto Address { get; set; }

        [Required]
        public List<CreateLicenceRelProjectApiDto> Licences { get; set; }
        //تسهیلات
        [Required]
        public List<CreateFacilitiRelProjectApiDto> Facilitis { get; set; }
        //سرمایه گذاری ها
        [Required]
        public List<CreateFundRelProjectApiDto> Funds { get; set; }

    }
   
}
