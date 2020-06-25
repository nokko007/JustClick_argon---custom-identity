using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JustClick.Areas.Identity.IdentityHostingStartup))]
namespace JustClick.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}