using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mundo.backend.Startup))]
namespace mundo.backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
