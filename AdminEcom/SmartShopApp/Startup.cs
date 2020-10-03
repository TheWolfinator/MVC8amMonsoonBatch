using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartShopApp.Startup))]
namespace SmartShopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
