using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IspitiNRAKO.Startup))]
namespace IspitiNRAKO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
