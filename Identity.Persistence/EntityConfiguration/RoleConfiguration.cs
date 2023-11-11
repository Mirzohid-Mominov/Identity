using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(role => role.Type).IsUnique();

            builder.HasData(new Role
            {
                Id = Guid.Parse("{9496766E-0D40-42E3-8A28-E43680854CE1}"),
                Type = RoleType.Admin,
                CreatedTime = DateTime.UtcNow,
            }, 
            new Role
            {
                Id = Guid.Parse("{7AD89A3C-B151-4E82-9F9D-C33C35CE9C75}"),
                Type = RoleType.Host,
                CreatedTime = DateTime.UtcNow,
            },
            new Role
            {
                Id = Guid.Parse("{9CC6C7BD-60AC-462A-918A-3A7B5E48DE4E}"),
                Type = RoleType.Guest,
                CreatedTime = DateTime.UtcNow,
            });
        }
    }
}
