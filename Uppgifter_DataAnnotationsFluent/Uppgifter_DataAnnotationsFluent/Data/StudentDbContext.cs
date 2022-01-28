using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgifter_DataAnnotationsFluent.Models;

namespace Uppgifter_DataAnnotationsFluent.Data
{
	public class StudentDbContext : DbContext
	{
		public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
		{
		}

		public DbSet<Address> Addresses { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Enrollment> Enrollments { get; set; }

		public DbSet<Course> Courses { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Course>().ToTable("course");
			builder.Entity<Student>().ToTable("student");
			builder.Entity<Address>().ToTable("address");
			builder.Entity<Enrollment>().ToTable("enrollment");

			builder.Entity<Student>().HasMany<Address>().WithOne(address => address.Student).HasForeignKey(address => address.StudentId);
			
			builder.Entity<Student>().HasMany<Enrollment>().WithOne(e => e.Student).HasForeignKey(e => e.StudentId);
			builder.Entity<Course>().HasMany<Enrollment>().WithOne(c => c.Course).HasForeignKey(c => c.CourseId);
			
			builder.Entity<Enrollment>().HasKey(e => new { e.CourseId, e.StudentId });
		}
	}
}
