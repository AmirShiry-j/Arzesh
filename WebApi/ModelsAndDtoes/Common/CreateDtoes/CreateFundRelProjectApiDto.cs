using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelsAndDtoes.Common.CreateDtoes
{
    public class CreateFundRelProjectApiDto
    {
        public int FundId { get; set; }
        //درصد پیشرفت فیزیکی
        [Range(0, 100)]
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public int AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public int TotalAmountNeeded { get; set; }
    }
}
