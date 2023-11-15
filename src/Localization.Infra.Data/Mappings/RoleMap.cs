using Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infra.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role> 
{
    public void Configure(EntityTypeBuilder<Role> builder) 
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder 
            .OwnsOne(r => r.Name)
                .Property(n => n.Value)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(60)
                .HasColumnType("VARCHAR");
    }
}