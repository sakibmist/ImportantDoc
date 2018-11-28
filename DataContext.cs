using Microsoft.EntityFrameworkCore;

namespace Person.Api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<APerson> Persons { get; set; }

    }
}