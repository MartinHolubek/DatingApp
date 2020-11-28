using Microsoft.EntityFrameworkCore;
using DatingApp.API.Models;
namespace DatingApp.API.Data
{
    //použitie entityframework
    public class DataContext : DbContext
       {
           public DataContext(DbContextOptions<DataContext> options) : base(options)
           {
               
           }

           public DbSet<WeatherForecast> Values { get; set; }
        
    }
}