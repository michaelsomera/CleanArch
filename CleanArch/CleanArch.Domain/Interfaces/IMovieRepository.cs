using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
    }
}
