using LinkDev.Talabat.Infrastructure.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Presistance
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresistanceServices(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            servicesCollection.AddDbContext<StoreContext>((optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreContext"));
            });
            return servicesCollection;
        }

    }
}
