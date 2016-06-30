using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MUSIC_SHARING.Startup))]
namespace MUSIC_SHARING
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
