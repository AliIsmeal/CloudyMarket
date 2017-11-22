using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cloudy.Startup))]
namespace Cloudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
