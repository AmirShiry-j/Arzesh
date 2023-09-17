using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class CapacityRelProject
    {
        public int Id { get; set; }
        //نوع محصول
        public string ProductTypeName { get; set; }
        //ظرفیت اسمی
        public long NominalCapacity { get; set; }
        //ظرفیت واقعی عملیاتی
        public long ActualOperatingCapacity { get; set; }
        //شیفت کاری
        public string ShiftWork { get; set; }
        //ظرفیت مورد نظر عملیاتی
        public string DesiredOperationalCapacity { get; set; }
        //میزان فروش سال گذشته
        public long LastYearSale { get; set; }
        //
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
