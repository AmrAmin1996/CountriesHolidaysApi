using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CountriesHolidaysApi.Services.CountryService
{
    public interface ICountryService
    {
        Task<IActionResult> SyncCountries();

        Task<ActionResult<List<Country>>?> GetAllCountriesWithPagination(int pageNumber);



    }
}
