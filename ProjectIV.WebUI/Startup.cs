using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectIV.WebUI.Startup))]
namespace ProjectIV.WebUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
