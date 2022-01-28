using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgifter_IdentityAndSession.Models;

namespace Uppgifter_IdentityAndSession.Data
{
	public class ProductDbContext : IdentityDbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Product>().HasData(new Product() { ProductId = 1, Name = "AMD Ryzen 5900X", Price = 6000 });
			builder.Entity<Product>().HasData(new Product() { ProductId = 2, Name = "NVIDIA RTX 3080", Price = 99999 });
			builder.Entity<Product>().HasData(new Product() { ProductId = 3, Name = "Samsung 970 EVO 250gb", Price = 1000 });
			builder.Entity<Product>().HasData(new Product() { ProductId = 4, Name = "Razer blackwidow chroma v3", Price = 1500 });
		}

		public DbSet<Product> Products { get; set; }
	}
}
