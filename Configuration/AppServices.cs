using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuicBlog.Data.Models;
using QuiqBlog.Data;

namespace QuiqBlog.Configuration
{
    public static class AppServices
    {
        public static void AddDefaultServices(this IServiceCollection
            servicesCollection,IConfiguration configuration)
        {
            servicesCollection.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")));
            servicesCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            servicesCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            servicesCollection.AddRazorPages();
        }
    }
}
