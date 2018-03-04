using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Introduction.Startup))]
namespace Introduction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
