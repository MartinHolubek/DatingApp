using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatingApp.API.Models;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy2", "Hot2", "Sweltering2", "Scorching2"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,DataContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        //Vrati zoznam z databazy
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var values=  await _context.Values.ToListAsync();
            return Ok(values);
        }

        //Vrati jeden zaznam z databazy
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id){
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            
            return Ok(value);
        }
    }
}
