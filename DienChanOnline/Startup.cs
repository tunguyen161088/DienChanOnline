using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DienChanOnline.Startup))]
namespace DienChanOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
