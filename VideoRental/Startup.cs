using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoRental.Startup))]
namespace VideoRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
