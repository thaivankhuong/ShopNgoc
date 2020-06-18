using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToanThangSite.Startup))]
namespace ToanThangSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
