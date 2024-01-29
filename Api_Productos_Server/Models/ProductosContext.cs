﻿using Microsoft.EntityFrameworkCore;

namespace Api_Productos_Server.Models
{
    public class ProductosContext :DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options) 
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>().HasIndex(c => c.sNombre).IsUnique();
        }
    }
}