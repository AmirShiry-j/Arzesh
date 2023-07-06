using Domain.Project;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class Address
    {
        public int Id { get; set; }
        //استان
        public int UnitedId { get; set; }
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
        public Project_Incompleted Project_Incompleted { get; set; }
    }

}
