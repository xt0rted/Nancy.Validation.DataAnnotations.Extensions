[assembly: Microsoft.Owin.OwinStartup(typeof(SampleWebsite.Startup))]

namespace SampleWebsite
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}