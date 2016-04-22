using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnatoknightStudios.UI.Startup))]
namespace AnatoknightStudios.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
