using Domain.ProjectNeeds;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelsAndDtoes.Common.CreateDtoes
{
    public class CreateFacilitiRelProjectApiDto
    {
        //نوع تسهیلات
        [Range(1, 2)]
        public FacilitiType FacilitiType { get; set; }
        //وضعیت
        public int FacilitiStatusId { get; set; }
        //ماهیت
        public int FacilitiNatureId { get; set; }
        //تاریخ اخذ تسهیلات
        public string ReceivingDate { get; set; }
        //تاریخ شروع اقساط
        public string InstallmentStartDate { get; set; }
        //مدت بازپرداخت
        public int RepaymentPeriod { get; set; }
        //محل تامین - بانک
        public string placeSupply_Bank { get; set; }
        //درصد سود
        [Range(0, 100)]
        public int InterestRate { get; set; }
        //نوع وثیقه
        public string CollateralName { get; set; }
    }
}
