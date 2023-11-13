using Identity.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string EmailAddress { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public bool IsEmailAddressverified { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
