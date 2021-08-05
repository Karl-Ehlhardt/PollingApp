using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PollingApp.WebMVC.Startup))]
namespace PollingApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
