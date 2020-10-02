using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimesheetPrj.Startup))]
namespace TimesheetPrj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
