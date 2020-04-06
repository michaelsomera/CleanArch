using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private VidlyDbContext _ctx;

        public CustomerRepository(VidlyDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _ctx.Customers;
        }
    }
}
