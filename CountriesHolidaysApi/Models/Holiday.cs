using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CountriesHolidaysApi.Models
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }
        public string HolidayName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime StartDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDay { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]

        public Country? Country { get; set; }

    }

}
