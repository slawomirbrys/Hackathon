using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankWeb.Startup))]
namespace BankWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
