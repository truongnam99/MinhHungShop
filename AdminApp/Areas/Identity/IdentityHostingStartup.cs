using System;
using AdminApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AdminApp.Areas.Identity.IdentityHostingStartup))]
namespace AdminApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AdminAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdminAppContextConnection")));

                //    services.AddDefaultIdentity<IdentityUser>()
                //        .AddEntityFrameworkStores<AdminAppContext>();
            });
        }
    }
}