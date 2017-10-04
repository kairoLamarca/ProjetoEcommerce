using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoEcommerce.Web.Startup))]
namespace ProjetoEcommerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
