using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gadzet.Startup))]
namespace Gadzet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
