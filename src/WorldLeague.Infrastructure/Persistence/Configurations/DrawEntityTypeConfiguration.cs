using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence.Configurations;

internal class DrawEntityTypeConfiguration : IEntityTypeConfiguration<Draw>
{
    public void Configure(EntityTypeBuilder<Draw> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.DrawerName)
            .IsRequired()
            .HasMaxLength(150);


        builder.Property(x => x.DrawerLastName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.DrawedAt)
            .IsRequired();

        builder.HasMany(e => e.Groups)
            .WithOne(x => x.Draw)
            .HasForeignKey("DrawId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}
