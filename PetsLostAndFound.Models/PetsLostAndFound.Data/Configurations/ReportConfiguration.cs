namespace PetsLostAndFound.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetsLostAndFound.Models;
    public class ReportConfiguration:IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Status).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Pet)
                .WithMany(p => p.Reports)
                .HasForeignKey(e => e.PetId);

            builder.HasOne(e => e.Location)
                .WithMany(l => l.Reports)
                .HasForeignKey(e => e.LocationId);
        }
    }
}
