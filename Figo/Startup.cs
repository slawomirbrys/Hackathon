using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Figo.Startup))]
namespace Figo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
