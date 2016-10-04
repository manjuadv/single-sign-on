using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestApp_Login_System.Startup))]
namespace TestApp_Login_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
