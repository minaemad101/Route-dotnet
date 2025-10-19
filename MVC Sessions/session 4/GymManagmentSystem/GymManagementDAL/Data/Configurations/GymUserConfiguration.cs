using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.Configurations
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(X => X.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(X => X.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.Property(X => X.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            // email check constraint for the table
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("GymUserValidEmailCheck", "Email Like '_%@_%._%'");
                tb.HasCheckConstraint("GymUserValidPhobeCheck", "Phone Like '01%' and Phone Not Like'%[^0-9]%'");
            });

            // unique non clustered index
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.OwnsOne(x => x.Address, AddressBuilder =>
            {
                AddressBuilder.Property(X => X.street)
                .HasColumnName("Street")
                .HasColumnType("varchar")
                .HasMaxLength(50);
                AddressBuilder.Property(X => X.city)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            });

        }
    }
}
