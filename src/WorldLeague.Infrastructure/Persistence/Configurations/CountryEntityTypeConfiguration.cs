using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence.Configurations;

internal class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(e => e.Teams)
            .WithOne(x => x.Country)
            .HasForeignKey("CountryId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
