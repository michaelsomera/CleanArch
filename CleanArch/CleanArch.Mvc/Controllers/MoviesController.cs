using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
        public IActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        [HttpGet, Authorize(Roles = RoleName.CanManageMovies)]
        public PartialViewResult ManageMovie(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
            {
                movie = new Movie();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _genreService.Get().ToList()
            };
            return PartialView("Partials/_ManageMoviePartial", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageMovie(Movie movie)
        {
            object msg;
            var isEdit = movie.Id != 0;
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel
                    {
                        Movie = movie,
                        Genres = _genreService.Get().ToList()
                    };

                    return PartialView("Partials/_ManageMoviePartial", viewModel);
                }
                if (isEdit)
                {
                    var movieInDb = _movieService.GetById(movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.NumberAvailable = movie.NumberInStock;
                    movieInDb.DateAdded = DateTime.Now;

                }
                else
                {
                    movie.DateAdded = DateTime.Now;
                    movie.NumberAvailable = movie.NumberInStock;
                    _movieService.Insert(movie);
                }

                _movieService.Save();
                msg = new
                {
                    IsSuccess = true,
                    Message = "Movie record successfully " + (isEdit ? "updated" : "created")
                };
                return Json(msg);
            }
            catch (Exception ex)
            {
                msg = new
                {
                    IsSuccess = false,
                    Message = ex
                };
                return Json(msg);
            }
        }
    }
}