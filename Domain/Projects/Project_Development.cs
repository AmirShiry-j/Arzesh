using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects
{
    public class Project_Development
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

        //طرح توسعه شما منجر به افزایش
        public DevPlanLeadsToIncrease DevPlanLeadsToIncrease { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }

        //محل اجرای طرح
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int? RentTypeId { get; set; }
        public RentType RentType { get; set; }

        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //در کدام قسمت قصد مشارکت دارید
        public WhichPartIntendParticipate WhichPartIntendParticipate { get; set; }
        //آیا صورت‌ مالی دارید؟
        public bool HaveFinancialStatement { get; set; }

        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public long AmountOfParticipationRequired { get; set; }
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


        ////nave
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
    //طرح توسعه شما منجر به افزایش
    public enum DevPlanLeadsToIncrease
    {
        //افزایش ظرفیت اسمی
        IncreaseInNominalCapacity = 1,
        //افزایش نوع محصول
        IncreaseProductType = 2,
        //هردو
        Both = 3
    }
    //در کدام قسمت قصد مشارکت دارید
    public enum WhichPartIntendParticipate
    {
        //فاز توسعه
        DevelopmentPhase=1,
        //کل پروژه
        WholeProject=2,
        //هردو
        Both = 3
    }
}
