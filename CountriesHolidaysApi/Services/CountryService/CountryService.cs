using Microsoft.AspNetCore.Mvc;
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


    }
}

