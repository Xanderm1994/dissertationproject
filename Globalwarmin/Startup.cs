using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Globalwarmin.Startup))]
namespace Globalwarmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
