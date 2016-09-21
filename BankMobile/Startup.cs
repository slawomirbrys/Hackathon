using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankMobile.Startup))]
namespace BankMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
