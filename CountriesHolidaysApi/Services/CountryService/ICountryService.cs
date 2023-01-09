using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CountriesHolidaysApi.Services.CountryService
{
    public interface ICountryService
    {
        Task<IActionResult> GetAllCountries();

        
    }
}
