using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleSocialBlog.Startup))]

namespace SimpleSocialBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}