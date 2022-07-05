using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Domain.RoleaAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.OwnsMany(x => x.Permissions, NavigationBuilder =>
            {
                NavigationBuilder.HasKey(x => x.Id);
                NavigationBuilder.ToTable("Permissions");
                NavigationBuilder.Ignore(x => x.Name);
                NavigationBuilder.WithOwner(x => x.Role);
            });


        }
    }
}
