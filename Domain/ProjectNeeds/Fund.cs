using Domain.Projects;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class FundRelProject
    {
        public int Id { get; set; }
        //نام سرمایه گذاری
        public Fund Fund { get; set; }
        public int FundId { get; set; }
        //درصد پیشرفت فیزیکی
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public int AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public int TotalAmountNeeded { get; set; }
        //
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
    public class Fund
    {
        public int Id { get; set; }
        //نام سرمایه  گذاری
        public string Name { get; set; }
    }

}
