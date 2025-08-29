using Microsoft.EntityFrameworkCore;

namespace PacomArbetstest.Data
{
    public class PacomDbContext : DbContext
    {
        public PacomDbContext(DbContextOptions<PacomDbContext> options) : base(options) { }

        public DbSet<ToggleState> ToggleStates { get; set; }
    }
}