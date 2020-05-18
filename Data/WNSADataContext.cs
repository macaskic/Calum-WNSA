using WNSA.Models;
using Microsoft.EntityFrameworkCore;

namespace WNSA.Data
{
    public  class WNSADataContext : DbContext
    {
        public WNSADataContext(DbContextOptions<WNSADataContext> opt ) : base (opt)
        {
            
        }

        public DbSet<WNSAModel>  Commands { get; set; }

    }
}
