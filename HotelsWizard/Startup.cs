using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HotelsWizard.Startup))]

namespace HotelsWizard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}