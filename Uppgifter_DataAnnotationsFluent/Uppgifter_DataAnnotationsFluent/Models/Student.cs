using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_DataAnnotationsFluent.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }

		[Required]
		[MinLength(3, ErrorMessage = "Namnet är för kort, ange minst 3 tecken")]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public List<Address> Addresses { get; set; }

		public List<Enrollment> Enrollments;
	}
}
