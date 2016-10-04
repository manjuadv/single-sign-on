using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestApp_01_Accounting_System.Startup))]
namespace TestApp_01_Accounting_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
