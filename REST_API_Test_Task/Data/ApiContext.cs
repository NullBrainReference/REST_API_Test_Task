using Microsoft.EntityFrameworkCore;
using REST_API_Test_Task.Models;

namespace REST_API_Test_Task.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

    }
}
