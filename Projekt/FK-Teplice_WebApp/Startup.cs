using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FK_Teplice_WebApp.Startup))]
namespace FK_Teplice_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
