using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace UniQode.Web
{
	public partial class Startup
    {
	    public void ConfigureAuth(IAppBuilder app)
        {
            // Enable Application Sign In Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Application",
                LoginPath = new PathString("/auth/login"),
                LogoutPath = new PathString("/auth/logout"),
            });
        }
    }
}