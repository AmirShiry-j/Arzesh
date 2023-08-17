using Application.Common.CreateDtoes;
using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using Domain.Projects;
using System.ComponentModel.DataAnnotations;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project_Development
{
    public class CreateProject_DevelopmentApiDto
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
        public int AmountCapitalDemand { get; set; }
        //آدرس
        [Required]
        public CreateAddressApiDto Address { get; set; }
        /// <summary>
        /// End Commons
        /// </summary>
        /// 


        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        [Range(1, 2)]
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        public int PercentParticipation { get; set; }
        //مشارکت
        //آیا در حوزه فعالیت طرح سابقه و یا تجربه دارید؟ 
        public string AmountOfExperience { get; set; }

        //طرح توسعه شما منجر به افزایش
        [Range(1, 3)]
        public DevPlanLeadsToIncrease DevPlanLeadsToIncrease { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }

        //محل اجرای طرح
        [Range(1, 3)]
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }

        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //در کدام قسمت قصد مشارکت دارید
        
        [Range(1, 3)]
        public WhichPartIntendParticipate WhichPartIntendParticipate { get; set; }
        //آیا صورت‌ مالی دارید؟
        public bool HaveFinancialStatement { get; set; }

        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public int AmountOfParticipationRequired { get; set; }
        //خالص ارزش فعلی پروژه
        public long NetPresentValue { get; set; }

        //آیا پروژه شما در حال حاضر سودده می‌باشد
        public bool IsCurrentlyProfitable { get; set; }
        //بله
        //میزان سود سال گذشته
        public int LastYearProfit { get; set; }
        //خیر
        //میزان زیان سال گذشته
        public int LastYearLoss { get; set; }

        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }



        //دارایی ها
        [Required]
        public List<CreateAssetRelProjectApiDto> Assets { get; set; }
        //مجوز ها
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
