using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class AssetRelProject
    {
        public int Id { get; set; }
        //نام دارایی
        public Asset Asset { get; set; }
        public int AssetId { get; set; }
        //میزان
        public int Level { get; set; }
        //ارزش
        public int Value { get; set; }
        //
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
