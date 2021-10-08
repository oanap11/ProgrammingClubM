using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgrammingClub2.Startup))]
namespace ProgrammingClub2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
