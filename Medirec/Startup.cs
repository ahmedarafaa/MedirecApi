using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medirec.Startup))]
namespace Medirec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
