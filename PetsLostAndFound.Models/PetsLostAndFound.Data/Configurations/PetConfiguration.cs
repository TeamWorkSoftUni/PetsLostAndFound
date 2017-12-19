namespace PetsLostAndFound.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetsLostAndFound.Models;
    public class PetConfiguration:IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(e => e.UserId);
        }
    }
}
