using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionManagement.MVC.Startup))]
namespace TransactionManagement.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
