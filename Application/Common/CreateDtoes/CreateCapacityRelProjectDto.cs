namespace Application.Common.CreateDtoes
{
    public class CreateCapacityRelProjectDto
    {
        //نوع محصول
        public string ProductTypeName { get; set; }
        //ظرفیت اسمی
        public int NominalCapacity { get; set; }
        //ظرفیت واقعی عملیاتی
        public int ActualOperatingCapacity { get; set; }
        //شیفت کاری
        public string ShiftWork { get; set; }
        //ظرفیت مورد نظر عملیاتی
        public string DesiredOperationalCapacity { get; set; }
        //میزان فروش سال گذشته
        public long LastYearSale { get; set; }
    }
}
