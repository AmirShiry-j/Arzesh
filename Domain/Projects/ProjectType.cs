using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Naves
        public Project Project { get; set; }
    }
}
