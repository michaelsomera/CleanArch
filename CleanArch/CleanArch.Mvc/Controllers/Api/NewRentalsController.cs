using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private IMovieService _movieService;
        private ICustomerService _customerService;
        private IMapper _mapper;
        private IRentalService _rentalService;

        public NewRentalsController(IMovieService movieService, ICustomerService customerService, IMapper mapper,IRentalService rentalService)
        {
            _movieService = movieService;
            _customerService = customerService;
            _mapper = mapper;
            _rentalService = rentalService;
        }
        [HttpPost]
        public ActionResult NewRentals(NewRentalDto newRental)
        {
            var customer = _customerService.GetById(newRental.CustomerId);
            var movies =_movieService.Get().Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberInStock--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _rentalService.Insert(rental);
            }
            _rentalService.Save();
            return Ok();
        }
    }
}