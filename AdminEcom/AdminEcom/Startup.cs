using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminEcom.Startup))]
namespace AdminEcom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
