using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infra.Data.Mappings;

public class LocalizationMap : IEntityTypeConfiguration<Domain.Entities.Localization> 
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Localization> builder) 
    {
        builder.HasKey(l => l.Id);

        builder
            .Property(l => l.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .OwnsOne(l => l.State)
                .Property(s => s.Acronym)
                .IsRequired()
                .HasColumnName("State")
                .HasMaxLength(2)
                .HasColumnType("VARCHAR");

        builder
            .OwnsOne(l => l.IBGECode)
                .Property(i => i.Code)
                .IsRequired()
                .HasColumnName("IbgeCode")
                .HasMaxLength(8)
                .HasColumnType("VARCHAR");

        builder
            .OwnsOne(l => l.ZipCode)
                .Property(z => z.Code)
                .IsRequired()
                .HasColumnName("ZipCode")
                .HasMaxLength(8)
                .HasColumnType("VARCHAR");

        builder
            .Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder
            .Property(l => l.AddedBy)
            .IsRequired()
            .HasMaxLength(60)
            .HasColumnType("VARCHAR");

        builder
            .Property(l => l.UpdatedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME");

        builder
            .OwnsOne(l => l.UpdatedBy)
                .Property(u => u.Value)
                .IsRequired(false)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(60)
                .HasColumnType("VARCHAR");
    }
}