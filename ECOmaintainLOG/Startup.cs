using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECOmaintainLOG.Startup))]
namespace ECOmaintainLOG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
