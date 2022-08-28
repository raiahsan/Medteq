#region Imports
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.ExternalDependencies;
#endregion

namespace PVerify
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEligiblityAPIDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEligibilityAPIHandler, PVerifyEligibilityAPIHandler>();
            return services;
        }
    }
}