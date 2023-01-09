namespace CountriesHolidaysApi.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }
    }
}
