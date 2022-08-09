using System;

using ASM_App_Dev.Data;
using ASM_App_Dev.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASM_App_Dev.Areas.Identity.IdentityHostingStartup))]

namespace ASM_App_Dev.Areas.Identity
{
    public class IdentityHostingStartup: IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
