using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurHospital.Startup))]
namespace OurHospital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
