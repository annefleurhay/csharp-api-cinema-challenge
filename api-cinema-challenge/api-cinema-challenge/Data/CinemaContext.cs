using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_cinema_challenge.Data
{
    public class CinemaContext : DbContext //Dit is je DataContext 

        
    {
        private string connectionString;
        public CinemaContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets {  get; set; }

        //private static string GetConnectionString()
        //{
        //    string jsonSettings = File.ReadAllText("appsettings.json");
        //    JObject configuration = JObject.Parse(jsonSettings);
        //    return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(GetConnectionString());
        //}
    }
}
