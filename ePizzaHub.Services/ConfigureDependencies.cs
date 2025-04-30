using ePizzaHubCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHubCore.Entities;
using ePizzaHub.Repositories.Implimentations;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.Services.Implimentations;
using ePizzaHub.Models;

namespace ePizzaHub.Services
{
    public class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            service.AddScoped<IRepositories<Item>, Repositories<Item>>();
            service.AddScoped<IRepositories<User>, Repositories<User>>();
            service.AddScoped<IRepositories<Cart>, Repositories<Cart>>();
            //service.AddScoped<ICartRepositories<Cart>, ICartRepositories<Cart>>();

            service.AddScoped<ICartRepositories, CartRepositories>();
            service.AddScoped<IUserRepositories, UserRepositories>();

            service.AddScoped<IItemServices, ItemServices>();
            service.AddScoped<IAuthServices, AuthServices>();
            service.AddScoped<IUserRepositories, UserRepositories>();
            service.AddScoped<ICartServices, CartServices>();


        }
    }
}
