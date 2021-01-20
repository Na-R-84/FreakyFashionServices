using FreakyFashionServices.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace FreakyFashionServices.Catalog.Models
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
            var products = new List<Product>
            {
            new Product(1, "Black slim T-shirt", "Lorem Ipsum dollar ", 300,"r333", 20),
            new Product(2, "Pink slim T-shirt", "Lorem Ipsum dollar ", 700,"d211", 20),
            new Product(3, "Blue slim T-shirt", "Lorem Ipsum dollar ", 500,"t55", 10),
            new Product(4, "Gold slim T-shirt", "Lorem Ipsum dollar ", 100,"qwrg", 14)
            };
            products.ForEach(x => modelBuilder.Entity<Product>().HasData(x));
        }

 

    }

}
