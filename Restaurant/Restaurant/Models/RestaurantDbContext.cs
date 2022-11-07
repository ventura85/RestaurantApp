﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Restaurant.Models;

namespace RestaurantMVC.Models
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;";

        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Lepiej tutaj nadawać te wszystkie atrybuty co Pan Żak dodawał w klasach. Tak się robi normalnie
            //Ale można i w klasach wtedy może dla nas będzie łatwiej ? Do wyboru

            modelBuilder.Entity<User>()
                 .Property(r => r.Email)
                 .IsRequired();

            modelBuilder.Entity<Role>()
                 .Property(r => r.Name)
                 .IsRequired();

            modelBuilder.Entity<RestaurantModel>()
                 .Property(r => r.Name)
                 .IsRequired()
                 .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(r => r.Name)
                .IsRequired();
            
            modelBuilder.Entity<Address>()
                 .Property(r => r.City)
                 .IsRequired()
                 .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                 .Property(r => r.Street)
                 .IsRequired()
                 .HasMaxLength(50);
        }



    }
}
