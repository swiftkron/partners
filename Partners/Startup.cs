using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Partners.Startup))]
namespace Partners
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
