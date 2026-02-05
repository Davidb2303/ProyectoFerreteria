using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacturaDouglas.Startup))]
namespace FacturaDouglas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
