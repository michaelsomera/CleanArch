using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArch.Application.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte? GenresId { get; set; }

        [Required]
        [Display(Name = "Release Date")]

        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "Add Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenresId = movie.GenresId;
        }
    }
}
