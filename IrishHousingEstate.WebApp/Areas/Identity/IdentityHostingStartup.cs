using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IrishHousingEstate.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace IrishHousingEstate.WebApp.Areas.Identity
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