using Microsoft.AspNetCore.Mvc;

namespace CountriesHolidaysApi.Services.HolidayService
{
    public class HolidayService : IHolidayService
    {
        private readonly DataContext _context;

        public HolidayService(DataContext context)
        {
            _context = context;
        }

        public Task<IActionResult> AddHoliday(Holiday holiday)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<Holiday>>?> DeleteHoliday(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetHolidaysOfCountry(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SyncHolidays()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateHoliday(Holiday request)
        {
            throw new NotImplementedException();
        }
    }
}
