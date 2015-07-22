using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
//add web references
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(comp2007_lab10.Startup))]

namespace comp2007_lab10
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/login.aspx")
                });
                
        }
    }
}
