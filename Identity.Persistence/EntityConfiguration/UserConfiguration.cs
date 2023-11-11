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
                RoleId = Guid.Parse("{80670DD4-FA68-4EE7-87A8-B425809B1D57}") 
            });
        }
    }
}
