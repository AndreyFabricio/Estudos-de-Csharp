using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unit_ProjetoIntegrador_1.Startup))]
namespace Unit_ProjetoIntegrador_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
