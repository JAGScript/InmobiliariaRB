using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InmobiliariaRB.Startup))]
namespace InmobiliariaRB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
