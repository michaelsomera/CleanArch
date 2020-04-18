using CleanArch.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Application.Services
{
    public class CustomerService : GenericRepository<Customer>, ICustomerService
    {
        public CustomerService(VidlyDbContext context) : base(context, context.Customers)
        {

        }
        public CustomerViewModel GetCustomers()
        {
            return new CustomerViewModel
            {
                Customers = Get().ToList()
            };
        }
    }
    public class MovieService : GenericRepository<Movie> , IMovieService
    {
        public MovieService(VidlyDbContext context) : base(context, context.Movies)
        {

        }

        public MovieViewModel GetMovies()
        {
            return new MovieViewModel
            {
                Movies = Get().ToList()
            };
        }
    }
    public class GenreService : GenericRepository<Genre>, IGenreService
    {
        public GenreService(VidlyDbContext context) : base(context, context.Genres)
        {

        }
    }
    public class MembershipTypeService : GenericRepository<MembershipType>, IMembershipTypeService
    {
        public MembershipTypeService(VidlyDbContext context) : base(context, context.MembershipTypes)
        {

        }
    }
    public class RentalService : GenericRepository<Rental>, IRentalService
    {
        public RentalService(VidlyDbContext context) : base(context, context.Rentals)
        {

        }
    }
}
