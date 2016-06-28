using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcReflectionView.Startup))]
namespace MvcReflectionView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
