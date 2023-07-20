using Domain.Projects;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class LicenceRelProject
    {
        public int Id { get; set; }

        public DateTime ValidityDate { get; set; }
        //Licence
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        //
        public int ProjectId { get; set; }
        public ProjectType ProjectType { get; set; }
        public Project_Incompleted Project_Incompleted { get; set; }
    }
    public class Licence
    {
        public int Id { get; set; }
        //نام
        public string Name { get; set; }
    }
}
