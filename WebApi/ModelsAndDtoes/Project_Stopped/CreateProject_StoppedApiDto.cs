using Application.Common.CreateDtoes;
using Domain.ProjectEnums;
using WebApi.ModelsAndDtoes.Common.CreateDtoes;

namespace WebApi.ModelsAndDtoes.Project_Stopped
{
    public class CreateProject_StoppedApiDto
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
        public CreateAddressDto Address { get; set; }
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


        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public int AmountOfParticipationRequired { get; set; }
        //مشارکت
        //مدت زمان غیرفعال بودن طرح (سال)
        public int DurationInactivityYear { get; set; }
        //ارزش کل سرمایه گذاری جدید
        public long TotalValueNewInvestment { get; set; }
        //خالص ارزش فعلی پروژه
        public int NetPresentValue { get; set; }
        //دلایل غیر فعال بودن طرح
        public int InactivityReasonId { get; set; }
        //توضیح 
        public string ExplanationReason { get; set; }
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        //دارایی ها
        public List<CreateAssetRelProjectApiDto> Assets { get; set; }
        //مجوز ها
        public List<CreateLicenceRelProjectApiDto> Licences { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectApiDto> Facilitis { get; set; }
        //بدهی ها
        public List<CreateDebtRelProjectApiDto> Debts { get; set; }
    }
}
