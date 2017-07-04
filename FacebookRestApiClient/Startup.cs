using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacebookRestApiClient.Startup))]
namespace FacebookRestApiClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
