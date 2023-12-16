using Examen.Application.Contracts;
using Examen.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infraestructure
{
    public static class InfraestructureServicesRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IMovie, MoviesRepository>();
            services.AddScoped<IBillboard, BillboardRepository>();
            services.AddScoped<IBooking, BookingRepository>();
            services.AddScoped<IBase, BaseRepository>();
            services.AddScoped<ISeat, SeatRepository>();
            services.AddScoped<IRoom, RoomRepository>();

            services.AddDbContext<ButacasContext>(options => options.UseSqlServer(configuration.GetConnectionString("butacas")));

            return services;
        }
    }
}
