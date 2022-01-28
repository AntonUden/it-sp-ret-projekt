using Laboration1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.Data
{
	public class ItemDBContext : DbContext
	{
		public ItemDBContext(DbContextOptions<ItemDBContext> options): base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<PowerSource> PowerSources { get; set; }

		public DbSet<Item> Items { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Category>().HasData(new Category() { CategoryId = 1, Name = "Projektor" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 2, Name = "Bärbar dator" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 3, Name = "Trådlös hikrofon" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 4, Name = "Trådös högtala" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 5, Name = "Blädderblock" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 6, Name = "TV" });
			builder.Entity<Category>().HasData(new Category() { CategoryId = 7, Name = "Portabel projektorduk" });

			builder.Entity<PowerSource>().HasData(new PowerSource() { PowerSourceId = 1, Name = "Inget" });
			builder.Entity<PowerSource>().HasData(new PowerSource() { PowerSourceId = 2, Name = "Eluttag" });
			builder.Entity<PowerSource>().HasData(new PowerSource() { PowerSourceId = 3, Name = "Batterier" });
		}
	}
}
