using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DoCeluNaCzas.Startup))]
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
