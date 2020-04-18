using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        private IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetMovies(string query = null)
        {
            var moviesQuery = _movieService
                .Get(includeProperties: "Genre")
                .Where(c => c.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            var movieDtos = moviesQuery.ToList().Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }
        //GET /api/movies/1
        [HttpGet("{id}")]
        public ActionResult GetMovies(int id)
        {
            var movies = _movieService.GetById(id);
            if (movies == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movies));
        }
        //POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _movieService.Insert(movie);
            _movieService.Save();

            movieDto.Id = movie.Id;
            return CreatedAtAction(nameof(GetMovies), new{id=movieDto.Id}, movieDto);
        }

        //PUT /api/movies/1
        [HttpPut("{id}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _movieService.GetById(id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map(movieDto, movieInDb);
            _movieService.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult DeleteMovie(int id)
        {
            var movieInDb = _movieService.GetById(id);
            if (movieInDb == null)
                return NotFound();

            _movieService.Delete(movieInDb);
            _movieService.Save();
            return Ok();
        }
    }
}