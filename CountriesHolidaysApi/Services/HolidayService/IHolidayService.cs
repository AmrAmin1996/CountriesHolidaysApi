using Microsoft.AspNetCore.Mvc;
using CountriesHolidaysApi.Models;

namespace CountriesHolidaysApi.Services.HolidayService
{
    public interface IHolidayService
    {
        IActionResult GetHolidaysOfCountry(int id);

        Task<IActionResult> SyncHolidays();


        Task<IActionResult> AddHoliday(Holiday holiday);

        Task<ActionResult<List<Holiday>>?> DeleteHoliday(int id);

        Task<IActionResult> UpdateHoliday(Holiday request);


    }
}
