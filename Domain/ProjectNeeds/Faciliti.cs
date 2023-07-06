using Domain.Project;
using Domain.ProjectEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProjectNeeds
{
    public class FacilitiRelProject
    {
        public int Id { get; set; }
        //نوع تسهیلات
        public FacilitiType FacilitiType { get; set; }
        //وضعیت
        public FacilitiStatus FacilitiStatus { get; set; }
        public int FacilitiStatusId { get; set; }
        //ماهیت
        public FacilitiNature FacilitiNature { get; set; }
        public int FacilitiNatureId { get; set; }
        //تاریخ اخذ تسهیلات
        public DateTime ReceivingDate { get; set; }
        //تاریخ شروع اقساط
        public DateTime InstallmentStartDate { get; set; }
        //مدت بازپرداخت
        public int RepaymentPeriod { get; set; }
        //محل تامین - بانک
        public string placeSupply_Bank { get; set; }
        //درصد سود
        public int InterestRate { get; set; }
        //نوع وثیقه
        public string CollateralName { get; set; }
        //
        public ProjectType ProjectType { get; set; }
        public int ProjectId { get; set; }
        public Project_Incompleted Project_Incompleted { get; set; }
    }
    public class FacilitiStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FacilitiNature
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum FacilitiType
    {
        Arzi = 1,
        Riali = 2
    }
}
