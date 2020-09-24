using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorialMVC1.Startup))]
namespace TutorialMVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
