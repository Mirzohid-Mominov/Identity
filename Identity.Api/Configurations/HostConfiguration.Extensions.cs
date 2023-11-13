using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
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

        private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
            builder.Services.Configure<VerificationTokenSettings>(
                builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

            builder.Services.AddTransient<ITokenGeneratorService, >()
        }
    }
}
