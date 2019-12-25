using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rubel_Rana_1249804.Startup))]
namespace Rubel_Rana_1249804
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
