using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Domain.Models;

namespace CleanArch.Application.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
