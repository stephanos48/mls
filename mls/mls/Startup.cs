using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mls.Startup))]
namespace mls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
