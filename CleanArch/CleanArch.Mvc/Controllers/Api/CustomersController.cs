using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Dtos;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        private IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetCustomers(string query = null)
        {
            var customersQuery = _customerService.Get(includeProperties: "MembershipType");

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }
        //GET /api/customers/1
        [HttpGet("{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customers = _customerService.GetById(id);
            if (customers == null)
                return NotFound();
            
            return Ok(_mapper.Map<Customer, CustomerDto>(customers));
        }
        //POST /api/customers
        [HttpPost]
        public ActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _customerService.Insert(customer);
            _customerService.Save();

            customerDto.Id = customer.Id;
            return CreatedAtAction(nameof(GetCustomers), new {id = customerDto.Id}, customerDto);
        }

        //PUT /api/customers/1
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _customerService.GetById(id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map(customerDto, customerInDb);
            _customerService.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _customerService.GetById(id);

            if (customerInDb == null)
                return NotFound();

            _customerService.Delete(customerInDb);
            _customerService.Save();
            return Ok();
        }

    }
}