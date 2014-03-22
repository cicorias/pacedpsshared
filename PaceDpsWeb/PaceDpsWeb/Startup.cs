using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaceDpsWeb.Startup))]
namespace PaceDpsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
