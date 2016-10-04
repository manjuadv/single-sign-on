using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestApp_02_Admin_System.Startup))]
namespace TestApp_02_Admin_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
