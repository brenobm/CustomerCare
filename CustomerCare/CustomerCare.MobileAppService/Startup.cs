using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CustomerCare.MobileAppService.Startup))]

namespace CustomerCare.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}