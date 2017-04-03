using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartCardReader.WebUI.Startup))]
namespace SmartCardReader.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
