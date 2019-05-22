using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Untitled.Startup))]
namespace Untitled
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
