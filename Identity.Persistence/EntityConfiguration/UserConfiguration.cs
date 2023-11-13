using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

            builder.HasData(new User
            {
                Id = Guid.Parse("{7AF84DC0-A713-40F8-8F6B-8B67CB545215}"),
                FirstName = "Admin",
                LastName = "Admin",
                Age = 0,
                EmailAddress = "dfsgh",
                PasswordHash = "fdsg",
                IsEmailAddressverified = true,
                RoleId = Guid.Parse("{9496766E-0D40-42E3-8A28-E43680854CE1}") 
            });
        }
    }
}
