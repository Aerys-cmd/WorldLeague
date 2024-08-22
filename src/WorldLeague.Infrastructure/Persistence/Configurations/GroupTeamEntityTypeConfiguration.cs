using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence.Configurations;

internal class GroupTeamEntityTypeConfiguration : IEntityTypeConfiguration<GroupTeam>
{
    public void Configure(EntityTypeBuilder<GroupTeam> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.HasOne(e => e.Team)
            .WithMany()
            .HasForeignKey("TeamId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
