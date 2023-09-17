namespace Application.Common.CreateDtoes
{
    public class CreateFundRelProjectDto
    {
        public int FundId { get; set; }
        //درصد پیشرفت فیزیکی
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public long AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public long TotalAmountNeeded { get; set; }
    }
}
