using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CreateDtoes
{
    public class CreateAssetRelProjectDto
    {
        //نام دارایی
        public int AssetId { get; set; }
        //میزان
        public int Level { get; set; }
        //ارزش
        public int Value { get; set; }
    }
}
