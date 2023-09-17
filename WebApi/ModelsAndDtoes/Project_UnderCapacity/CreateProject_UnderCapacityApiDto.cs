using Application.Common.CreateDtoes;
using Domain.ProjectEnums;
using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project_UnderCapacity
{
    public class CreateProject_UnderCapacityApiDto
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

        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        public int PercentParticipation { get; set; }
        //مشارکت
        //آیا در حوزه فعالیت طرح سابقه و یا تجربه دارید؟ 
        public string AmountOfExperience { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }
        //محل اجرای طرح
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //آیا صورت مالی دارید؟
        public bool HaveFinancialStatement { get; set; }
        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public long AmountOfParticipationRequired { get; set; }
        //مشارکت
        //کل سرمایه مورد نیاز طرح
        public long RequiredCapitalPlan { get; set; }
        //مشارکت
        //در چه سرفصل‌هایی نیاز به مشارکت دارید؟
        public string WhatTopicsNeedParticipate { get; set; }
        //آیا پروژه شما در حال حاضر سودده می‌باشد
        public bool IsCurrentlyProfitable { get; set; }
        //بله
        //میزان سود سال گذشته
        public long LastYearProfit { get; set; }
        //خیر
        //میزان زیان سال گذشته
        public long LastYearLoss { get; set; }
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        //دارایی ها
        public List<CreateAssetRelProjectDto> Assets { get; set; }
        //مجوز ها
        public List<CreateLicenceRelProjectApiDto> Licences { get; set; }
        //ظرفیت ها
        public List<CreateCapacityRelProjectDto> Capacities { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectApiDto> Facilitis { get; set; }
    }
}
