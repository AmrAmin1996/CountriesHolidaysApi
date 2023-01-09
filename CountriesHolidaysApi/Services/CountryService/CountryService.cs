/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CountriesHolidaysApi.Services.CountryService.CountryService;
using Newtonsoft.Json;

namespace CountriesHolidaysApi.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _context;

        public CountryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> AddCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return await _context.Countries.ToListAsync();
        }

        public async Task<List<Country>?> DeleteCountry(int id)
        {
            var hero = await _context.Countries.FindAsync(id);
            if (hero is null)
                return null;

            _context.Countries.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.Countries.ToListAsync();
        }

        public async Task<IActionResult> GetAllCountries()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://restcountries.com/v2/all?fields=name";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var CountriesName = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(CountriesName);
                    //dynamic CountriesNameJsonObj = JsonConvert.DeserializeObject(CountriesName);
                    //return CountriesNameJsonObj;
                }

            }
            *//* var heroes = await _context.SuperHeroes.ToListAsync();
             return heroes;*//*
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<List<Country>?> UpdateHero(int id, Country request)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
                return null;

            country.name = request.name;

            await _context.SaveChangesAsync();

            return await _context.Countries.ToListAsync();
        }
    }

        *//*[HttpGet]
        public async Task<IActionResult> SyncHolidays()
        {


            using (HttpClient client = new HttpClient())
            {
                var countries = _context.Countries.ToList();
                Console.Write(countries);

                foreach (var country in countries)
                {
                    string apiUrlHolyday = "https://www.googleapis.com/calendar/v3/calendars/en" + country.tId + "%23holiday%40group.v.calendar.google.com/events?key=AIzaSyBpSZoCr4xUGsNzmAuxVw_WT0Q4hVW9Bos";
                    HttpClient clientHolyday = new HttpClient();
                    clientHolyday.BaseAddress = new Uri(apiUrlHolyday);
                    clientHolyday.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseHolyday = await clientHolyday.GetAsync(apiUrlHolyday);
                    if (responseHolyday.IsSuccessStatusCode)
                    {
                        var Holydaydata = await responseHolyday.Content.ReadAsStringAsync();
                        Console.WriteLine(Holydaydata);
                        dynamic HolydayJsonObj = JsonConvert.DeserializeObject(Holydaydata);
                        if (HolydayJsonObj.items.Count != 0)
                        {
                            foreach (var hobj in HolydayJsonObj.items)
                            {


                                _context.Holidays.Add(new Holiday()
                                {
                                    Co untryId = country.CountryId,
                                    Day = hobj.summary,
                                    StartDay = hobj.start.date,
                                    EndDay = hobj.end.date

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
*/
