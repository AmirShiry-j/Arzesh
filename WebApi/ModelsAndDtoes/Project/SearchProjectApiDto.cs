namespace WebApi.ModelsAndDtoes.Project
{
    public class SearchProjectApiDto
    {
        public int? Page { get; set; } = 1;
        public int? CountInPage { get; set; } = 10;

        public int? ProjectTypeId { get; set; }
        public string? Name { get; set; }
        public int? IndustryId { get; set; }
        public int? ReturnInvestmentRateFrom { get; set; }
        public int? ReturnInvestmentRateTo { get; set; }
        public long? AmountCapitalDemandFrom { get; set; }
        public long? AmountCapitalDemandTo { get; set; }
        public int? UnitedId { get; set; }
        public int? CityId { get; set; }
    }
}
