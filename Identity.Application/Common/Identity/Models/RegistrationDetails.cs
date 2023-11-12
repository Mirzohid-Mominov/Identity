using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Identity.Models
{
    public class RegistrationDetails
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string EmailAddress { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
