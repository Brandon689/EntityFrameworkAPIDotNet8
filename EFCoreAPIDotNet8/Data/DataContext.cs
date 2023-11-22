using EntityFrameworkAPIDotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAPIDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
