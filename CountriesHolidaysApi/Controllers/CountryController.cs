using CountriesHolidaysApi.Models;
//using CountriesHolidaysApi.Services.CountryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace CountriesHolidaysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _context;

        public CountryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SyncCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            Console.WriteLine(countries.Count);
            if (countries.Count > 0)
            {
                return Ok("Data Already Added");
            }
            using (HttpClient client = new HttpClient())
            {
           
                string url = "https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var CountryData = await res.Content.ReadAsStringAsync();
                    dynamic CountriesObj = JsonConvert.DeserializeObject(CountryData)!;
                     foreach (var countryObj in CountriesObj)
                     {


                         _context.Countries.Add(new Country()
                         {
                                     Name = countryObj.Name,
                                     Code = countryObj.Code,

                                 });
                         await _context.SaveChangesAsync();

                     }

                }

            }
            return Ok("Data imported");


        }
        /* private readonly ICountryService _countryService;

         public CountryController(ICountryService countryService)
         {
             _countryService = countryService;
         }

         [HttpGet]
         public async Task<IActionResult> GetAllCountries()
         {
             return await _countryService.GetAllCountries();
         }*/

    }
}
