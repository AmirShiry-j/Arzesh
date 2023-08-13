using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class DebtRelProject
    {
        public int Id { get; set; }
        //سر فصل بدهی ها
        public Debt Debt { get; set; }
        public int DebtId { get; set; }
        //مبلغ
        public long Amount { get; set; }
        //
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
    public class Debt
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
