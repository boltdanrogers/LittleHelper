using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LittleHelper.Startup))]
namespace LittleHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
