namespace WebApi.ModelsAndDtoes.Common.CreateDtoes
{
    public class CreateAddressApiDto
    {
        //شهرستان
        public int CityId { get; set; }
        //شهر
        public string TownName { get; set; }
        //روستا/ شهرک صنعتی/ ناحیه صنعتی
        public string Part_Village { get; set; }
        //خیابان / پلاک
        public string Street { get; set; }
        //کد پستی
        public string PostalCode { get; set; }
        //
    }
}
