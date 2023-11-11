using Identity.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Configurations
{
    public static partial class HostConfiguration
    {
        private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder; 
        }
    }
}
