using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UniQode.Web.Startup))]
namespace UniQode.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}