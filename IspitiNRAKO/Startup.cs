using Microsoft.Owin;
using Owin;
using Metrics;

[assembly: OwinStartupAttribute(typeof(IspitiNRAKO.Startup))]
namespace IspitiNRAKO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Metric.Config
    .WithHttpEndpoint("http://localhost:1234/")
    .WithAllCounters();
            ConfigureAuth(app);
        }
    }
}
