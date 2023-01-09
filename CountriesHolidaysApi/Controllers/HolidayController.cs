//using CountriesHolidaysApi.Services.CountryService;
//using CountriesHolidaysApi.Services.HolidayService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CountriesHolidaysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        //private readonly IHolidayService _holidayService;

        /*public HolidayController(IHolidayService holidayService)
         {
             _holidayService = holidayService;
         }*/
        private readonly DataContext _context;

        public HolidayController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SyncHolidays()
        {
            var countries = _context.Countries.ToList();
            Console.Write(countries);

            using (HttpClient client = new HttpClient())
            {

                foreach (var country in countries)
                {
                    string url = "https://www.googleapis.com/calendar/v3/calendars/en." + country.Code + "%23holiday%40group.v.calendar.google.com/events?key=AIzaSyBpSZoCr4xUGsNzmAuxVw_WT0Q4hVW9Bos";
                    HttpClient client1 = new HttpClient();
                    client1.BaseAddress = new Uri(url);
                    client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await client1.GetAsync(url);
                    if (res.IsSuccessStatusCode)
                    {
                        var HolidaysData = await res.Content.ReadAsStringAsync();
                        dynamic HolidayObj = JsonConvert.DeserializeObject(HolidaysData)!;


                          if (HolidayObj.items.Count != 0)
                          {
                              foreach (var holiday in HolidayObj.items)
                              {
                                  _context.Holidays.Add(new Holiday()
                                  {
                                      HolidayName = holiday.summary,
                                      StartDay = holiday.start.date,
                                      EndDay = holiday.end.date,
                                      CountryId = country.CountryId

                                  });
                                  await _context.SaveChangesAsync();

                              }
                          }
                    }
                }
            }
            return Ok("Data imported");


        }
    }
}


