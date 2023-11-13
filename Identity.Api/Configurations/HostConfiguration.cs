using System.Runtime.CompilerServices;

namespace Identity.Api.Configurations
{
    public static partial class HostConfiguration
    {
        public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
        {
            builder.
                AddPersistence();

            return new(builder);
        }
    }
}
    