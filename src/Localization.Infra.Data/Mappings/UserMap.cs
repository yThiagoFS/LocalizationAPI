using Localization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localization.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .OwnsOne(u => u.Name)
                .Property(n => n.Value)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(60)
                .HasColumnType("VARCHAR");

        builder
            .OwnsOne(u => u.Email)
                .Property(e => e.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR");

        builder 
            .OwnsOne(u => u.Password)
                .Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("NVARCHAR");

         builder
            .Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder
            .Property(l => l.UpdatedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME");

        builder 
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole", 
                usr => 
                    usr.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                role => 
                    role.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}