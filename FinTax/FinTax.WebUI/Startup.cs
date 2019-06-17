using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinTax.WebUI.Startup))]
namespace FinTax.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
