using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaterialC.Startup))]
namespace MaterialC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
