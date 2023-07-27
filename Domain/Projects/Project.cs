using Domain.Common;
using Domain.ProjectNeeds;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects
{
    public class Project : BaseProps
    {
        public int Id { get; set; }
        //نام پروژه
        public string Name { get; set; }

        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }

        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //میزان سرمایه مورد تقاضا
        public int AmountCapitalDemand { get; set; }

        //Naves
        //کاربر
        public User User { get; set; }
        public string UserId { get; set; }
        //
        public ProjectType ProjectType { get; set; }
        public int ProjectTypeId { get; set; }
        //آدرس
        public Address Address { get; set; }

        public Project_Ideh P_Ideh { get; set; }
        public Project_Incompleted P_Incompleted { get; set; }
        //
        //مجوز ها
        public ICollection<LicenceRelProject> Licences { get; set; }
        //تسهیلات
        public ICollection<FacilitiRelProject> Facilitis { get; set; }
        //سرمایه گذاری ها
        public ICollection<FundRelProject> Funds { get; set; }
        public DateTime TimeCreate { get; set; }
    }

}
