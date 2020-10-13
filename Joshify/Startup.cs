using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Joshify.Startup))]
namespace Joshify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
