using FoodEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Restaurant>? Restaurants { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Cuisine>? Cuisines { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderStatus>? OrderStatuses { get; set; }
        public DbSet<OrderProduct>? OrderProducts { get; set; }
        public DbSet<RestaurantCuisine>? RestaurantCuisines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity => {
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<Cuisine>(entity => {
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<Role>(entity => {
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<Category>(entity => {
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<OrderStatus>(entity => {
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Login).IsUnique(true);
            });

        }

        // создаем базу данных при первом обращении или заполняем ее таблицами если она создана
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : 
            base(options) => Database.EnsureCreated();   
        

        
        // Настрока подключания к базе. (Сейчас работает иной вариант)
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string path = Directory.GetCurrentDirectory() + "\\FoodExBD.mdf";
        //    optionsBuilder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True;Connect Timeout=30");
        //}

    }
}
