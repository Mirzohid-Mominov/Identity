using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Settings
{
    public class JwtSettings
    {
        public bool ValidaIsUser { get; set; }

        public string ValidIsUser { get; set; } = default!;

        public bool ValidateAudience { get; set; }

        public string ValidAudience { get; set; } = default!;

        public bool ValidateLifeTime { get; set; }

        public int ExpirationTimeInMinutes { get; set; }

        public bool ValidateIssuerSigningKey { get; set; }

        public string SecretKey { get; set; } = default!;
    }
}
