using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using Discussme.BLL.ServiceClasses;
using Discussme.BLL.ServiceInterfaces;

[assembly: OwinStartup(typeof(Discussme.PL.App_Start.Startup))]

namespace Discussme.PL.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IForumService>(serviceCreator.CreateForumService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}