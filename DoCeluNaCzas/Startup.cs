using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoCeluNaCzas.Startup))]
namespace DoCeluNaCzas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
