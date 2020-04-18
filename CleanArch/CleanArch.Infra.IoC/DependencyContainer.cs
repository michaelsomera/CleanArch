using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMembershipTypeService, MembershipTypeService>();
            services.AddScoped<IRentalService, RentalService>();

            //Infra.Data Layer
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            

        }
    }
}
