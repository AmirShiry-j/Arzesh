namespace WebApi.ModelsAndDtoes.Common.CreateDtoes
{
    public class CreateCapacityRelProjectApiDto
    {
        //نوع محصول
        public string ProductTypeName { get; set; }
        //ظرفیت اسمی
        public long NominalCapacity { get; set; }
        //ظرفیت واقعی عملیاتی
        public long ActualOperatingCapacity { get; set; }
        //شیفت کاری
        public string ShiftWork { get; set; }
        //ظرفیت مورد نظر عملیاتی
        public string DesiredOperationalCapacity { get; set; }
        //میزان فروش سال گذشته
        public long LastYearSale { get; set; }
    }
}
