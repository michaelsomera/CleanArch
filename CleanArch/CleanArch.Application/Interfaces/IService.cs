using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IRentalService : IGenericRepository<Rental>
    {
    }
    public interface IMovieService : IGenericRepository<Movie>
    {
        MovieViewModel GetMovies();
    }
    public interface IMembershipTypeService : IGenericRepository<MembershipType>
    {
    }
    public interface ICustomerService : IGenericRepository<Customer>
    {
        CustomerViewModel GetCustomers();
    }
    public interface IGenreService : IGenericRepository<Genre>
    {
    }
}
