using Microsoft.EntityFrameworkCore;
using deliverAPI.Models;

namespace deliverAPI.Data
{
    public class contasDbContext : DbContext
    {
        public contasDbContext(DbContextOptions<contasDbContext> options) : base(options)
        { }

        public DbSet<clContas> clContas { get; set; }

    }

}
