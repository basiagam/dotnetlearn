using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gadzety.Startup))]
namespace Gadzety
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
