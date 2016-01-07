using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bdl.BoletoBdl.Presentation.UI.Admin.Startup))]
namespace Bdl.BoletoBdl.Presentation.UI.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
