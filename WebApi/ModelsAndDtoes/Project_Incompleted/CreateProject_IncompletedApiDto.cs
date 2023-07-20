using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelsAndDtoes.Project_Incompleted
{
    public class CreateProject_IncompletedApiDto
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
        public int AmountOfExperience { get; set; }
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
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }
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
    public class CreateAddressApiDto
    {
        //شهرستان
        public int CityId { get; set; }
        //شهر
        public string TownName { get; set; }
        //روستا/ شهرک صنعتی/ ناحیه صنعتی
        public string Part_Village { get; set; }
        //خیابان / پلاک
        public string Street { get; set; }
        //کد پستی
        public string PostalCode { get; set; }
        //
    }
    public class CreateLicenceRelProjectApiDto
    {
        public DateTime ValidityDate { get; set; }
        //Licence
        public int LicenceId { get; set; }
    }
    public class CreateFacilitiRelProjectApiDto
    {
        //نوع تسهیلات
        [Range(1, 2)]
        public FacilitiType FacilitiType { get; set; }
        //وضعیت
        public int FacilitiStatusId { get; set; }
        //ماهیت
        public int FacilitiNatureId { get; set; }
        //تاریخ اخذ تسهیلات
        public DateTime ReceivingDate { get; set; }
        //تاریخ شروع اقساط
        public DateTime InstallmentStartDate { get; set; }
        //مدت بازپرداخت
        public int RepaymentPeriod { get; set; }
        //محل تامین - بانک
        public string placeSupply_Bank { get; set; }
        //درصد سود
        [Range(0, 100)]
        public int InterestRate { get; set; }
        //نوع وثیقه
        public string CollateralName { get; set; }
    }
    public class CreateFundRelProjectApiDto
    {
        public int FundId { get; set; }
        //درصد پیشرفت فیزیکی
        [Range(0, 100)]
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public int AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public int TotalAmountNeeded { get; set; }
    }
}
