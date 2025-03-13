using Microsoft.EntityFrameworkCore;

namespace Mission10.Data
{
    public class BowlDbContext : DbContext
    {
        public BowlDbContext(DbContextOptions<BowlDbContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure TeamID is a Foreign Key in the Bowlers table
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
