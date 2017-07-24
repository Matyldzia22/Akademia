using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(architektura.Startup))]
namespace architektura
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
