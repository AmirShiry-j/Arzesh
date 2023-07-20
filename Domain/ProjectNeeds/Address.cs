using Domain.Projects;
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
        public City City { get; set; }

        //
        public ProjectType ProjectType { get; set; }
        public int ProjectId { get; set; }
        public Project_Incompleted Project_Incompleted { get; set; }
    }

    public class United
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //
        public ICollection<City> Cities { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //
        public United United { get; set; }
        public int UnitedId { get; set; }

    }
}
