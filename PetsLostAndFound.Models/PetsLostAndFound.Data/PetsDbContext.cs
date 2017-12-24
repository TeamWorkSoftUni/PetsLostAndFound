namespace PetsLostAndFound.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetsLostAndFound.Data.Configurations;
    using Data.Models;

    public class PetsDbContext:DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new PetConfiguration());
            builder.ApplyConfiguration(new ReportConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
