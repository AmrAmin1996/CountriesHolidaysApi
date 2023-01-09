using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CountriesHolidaysApi.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

    }
}
