using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectEnums
{
    public enum ProjectType
    {
        //ایده
        Ideh = 1,
        //نیمه تمام
        Incompleted = 2,
        //آماده بهره برداری
        ReadyToUse = 3,
        //زیر ظرفیت
        UnderCapacity = 4,
        //متوقف شده
        Stopped = 5,
        //توسعه
        Development = 6
    }
}
