using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppDemoBlog26.Startup))]
namespace WebAppDemoBlog26
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
