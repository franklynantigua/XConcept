using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XConcept.Startup))]
namespace XConcept
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
