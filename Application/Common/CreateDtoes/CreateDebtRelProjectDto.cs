using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CreateDtoes
{
    public class CreateDebtRelProjectDto
    {
        //سر فصل بدهی ها
        public int DebtId { get; set; }
        //مبلغ
        public long Amount { get; set; }
    }
}
