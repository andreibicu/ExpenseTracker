using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpenseTracker.Website.Startup))]
namespace ExpenseTracker.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
