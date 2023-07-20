using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects
{
    public class Project_Incompleted
    {
        public int Id { get; set; }
        //نام پروژه
        public string Name { get; set; }
        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        public int PercentParticipation { get; set; }
        //مشارکت
        //آیا در حوزه فعالیت طرح سابقه و یا تجربه دارید؟ 
        public int AmountOfExperience { get; set; }
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

        ////naves
        //آدرس
        public Address Address { get; set; }

        //ایده شما در چه صنعت و بخشی است؟
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }

        //مجوز ها
        public ICollection<LicenceRelProject> Licences { get; set; }
        //تسهیلات
        public ICollection<FacilitiRelProject> Facilitis { get; set; }
        //سرمایه گذاری ها
        public ICollection<FundRelProject> Funds { get; set; }
        //کاربر
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
