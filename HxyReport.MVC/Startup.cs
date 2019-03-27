using HxyReport_MVC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace HxyReport_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
