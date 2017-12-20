namespace PetsLostAndFound.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetsLostAndFound.Models;

    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Username).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.TelephoneNumber).IsRequired();
            builder.Property(e => e.Password).IsRequired();
        }
    }
}
