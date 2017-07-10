using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orchard.Net.Dev.Test.Startup))]
namespace Orchard.Net.Dev.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
