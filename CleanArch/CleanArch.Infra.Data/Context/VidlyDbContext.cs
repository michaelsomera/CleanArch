using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context
{
    public class VidlyDbContext : IdentityDbContext
    {
        public VidlyDbContext(DbContextOptions<VidlyDbContext> options): base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
