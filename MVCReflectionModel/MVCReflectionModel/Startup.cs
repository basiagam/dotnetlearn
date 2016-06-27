using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCReflectionModel.Startup))]
namespace MVCReflectionModel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
