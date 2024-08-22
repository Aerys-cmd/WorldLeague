using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence.Configurations;

internal class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(1);

        builder.HasMany(e => e.Teams)
            .WithOne(x => x.Group)
            .HasForeignKey("GroupId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}
