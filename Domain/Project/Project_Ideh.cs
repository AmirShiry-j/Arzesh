using Domain.ProjectEnums;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Project
{
    public class Project_Ideh
    {
        public int Id { get; set; }
        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        public int PercentParticipation { get; set; }
        //آیا ایده شما مورد مشابه داخلی دارد؟
        public bool HaveSimilarDomesticCase { get; set; }
        //آیا ایده شما ثبت شده است؟
        public bool IsRegistered { get; set; }
        //آیا مجوزی برای ایده اخذ شده است؟
        public bool HasLicense { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        //کل سرمایه مورد نیاز طرح
        public int RequiredCapitalPlan { get; set; }
        //میزان سرمایه مورد تقاضا
        public int AmountCapitalDemand { get; set; }
        //در چه سرفصل‌هایی نیاز به مشارکت دارید؟
        public string WhatTopicsNeedParticipate { get; set; }
        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //خالص ارزش فعلی پروژه
        public int NetPresentValue { get; set; }

        //naves
        public User User { get; set; }
        public string UserId { get; set; }
    }

}
