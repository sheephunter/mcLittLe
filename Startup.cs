using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mcLittLe.Startup))]
namespace mcLittLe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
