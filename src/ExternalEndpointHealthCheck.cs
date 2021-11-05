

using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace WeatherService
{
    public class ExternalEndpointHealthCheck : IHealthCheck
    {
        private readonly ServiceSettings settings;
        public ExternalEndpointHealthCheck(IOptions<ServiceSettings> settings)
        {
            this.settings = settings.Value;      
        
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            Ping ping = new();
            var reply = await ping.SendPingAsync(settings.ServiceHost);
            if (reply.Status != IPStatus.Success)
            {
                return HealthCheckResult.Unhealthy();
            }
            
            return HealthCheckResult.Healthy();           
            
        }
    }
}