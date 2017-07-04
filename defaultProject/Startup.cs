using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(defaultProject.Startup))]
namespace defaultProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
