namespace PetsLostAndFound.Db
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using PetsLostAndFound.Db.Configurations;

    public class PetsDbContext : IdentityDbContext<User>
    {
        public PetsDbContext(DbContextOptions<PetsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new PetConfiguration());
            builder.ApplyConfiguration(new ReportConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
