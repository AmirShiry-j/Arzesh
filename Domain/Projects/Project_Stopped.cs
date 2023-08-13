using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects
{
    public class Project_Stopped
    {
        public int Id { get; set; }
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
        public int? RentTypeId { get; set; }
        public RentType RentType { get; set; }

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
        public InactivityReason InactivityReason { get; set; }
        public int InactivityReasonId { get; set; }
        //توضیح 
        public string ExplanationReason { get; set; }
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        ////nave
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
    public class InactivityReason
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
